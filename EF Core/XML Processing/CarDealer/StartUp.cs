using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using var context = new CarDealerContext();

            //09. Import Suppliers
            //string suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //Console.WriteLine(ImportSuppliers(context, suppliersXml));

            //10. Import Parts
            //string partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            //Console.WriteLine(ImportParts(context, partsXml));

            //11. Import Cars
            //string carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            //Console.WriteLine(ImportCars(context, carsXml));

            //12. Import Customers
            //string customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            //Console.WriteLine(ImportCustomers(context, customersXml));

            //13. Import Sales
            //string salesXml = File.ReadAllText("../../../Datasets/sales.xml");
            //Console.WriteLine(ImportSales(context, salesXml));

            //14. Export Cars With Distance
            //Console.WriteLine(GetCarsWithDistance(context));

            //15.Export Cars From Make BMW
            //Console.WriteLine(GetCarsFromMakeBmw(context));

            //16. Export Local Suppliers
            //Console.WriteLine(GetLocalSuppliers(context));

            //17.Export Cars With Their List Of Parts
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));

            //18. Export Total Sales By Customer
            //Console.WriteLine(GetTotalSalesByCustomer(context));

            //19. Export Sales With Applied Discount
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        //09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(List<SupplierImportDto>),
                new XmlRootAttribute("Suppliers"));

            using var reader = new StringReader(inputXml);
            List<SupplierImportDto> importDtos = (List<SupplierImportDto>)serializer.Deserialize(reader);

            List<Supplier> suppliers = importDtos
                .Select(dto => new Supplier
                {
                    Name = dto.Name,
                    IsImporter = dto.IsImporter
                })
                .ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        //10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(List<PartImportDto>),
                new XmlRootAttribute("Parts"));

            using var reader = new StringReader(inputXml);
            List<PartImportDto> importDtos = (List<PartImportDto>)serializer.Deserialize(reader);

            var validSupplierIds = context.Suppliers.Select(s => s.Id).ToHashSet();

            List<Part> parts = importDtos
                .Where(dto => validSupplierIds.Contains(dto.SupplierId))
                .Select(dto => new Part
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    Quantity = dto.Quantity,
                    SupplierId = dto.SupplierId
                })
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        //11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(List<CarImportDto>),
                new XmlRootAttribute("Cars"));

            using var reader = new StringReader(inputXml);
            List<CarImportDto> importDtos = (List<CarImportDto>)serializer.Deserialize(reader);

            var cars = new List<Car>();
            foreach (var dto in importDtos)
            {
                var car = new Car
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TraveledDistance = dto.TraveledDistance
                };

                var validPartIds = dto.PartIds
                    .Select(s => s.Id)
                    .ToHashSet();

                var carParts = new List<PartCar>();
                foreach (var id in validPartIds)
                {
                    carParts.Add(new PartCar
                    {
                        Car = car,
                        PartId = id
                    });
                }

                car.PartsCars = carParts;
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(List<CustomerImportDto>),
                new XmlRootAttribute("Customers"));

            using var reader = new StringReader(inputXml);
            List<CustomerImportDto> importDtos = (List<CustomerImportDto>)serializer.Deserialize(reader);

            List<Customer> customers = importDtos
                .Select(dto => new Customer
                {
                    Name = dto.Name,
                    BirthDate = dto.BirthDate,
                    IsYoungDriver = dto.IsYoungDriver
                })
                .ToList();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        //13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(List<SalesImportDto>),
                new XmlRootAttribute("Sales"));

            using var reader = new StringReader(inputXml);
            List<SalesImportDto> importDtos = (List<SalesImportDto>)serializer.Deserialize(reader);

            var validCarIds = context.Cars.Select(c => c.Id).ToHashSet();

            List<Sale> sales = importDtos
                .Where(dto => validCarIds.Contains(dto.CarId))
                .Select(dto => new Sale
                {
                    CarId = dto.CarId,
                    CustomerId = dto.CustomerId,
                    Discount = dto.Discount
                })
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //14. Export Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var requiredDistance = 2_000_000;

            var cars = context.Cars
                .Where(c => c.TraveledDistance > requiredDistance)
                .Select(c => new CarExportDto
                {
                    Model = c.Model,
                    Make = c.Make,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToList();

            return SerializeToXml(cars, "cars");
        }

        //15.Export Cars From Make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var requiredMake = "BMW";

            var cars = context.Cars
                .Where(c => c.Make.Equals(requiredMake))
                .Select(c => new BmwExportDto()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ToList();

            return SerializeToXml(cars, "cars", true);
        }

        //16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new LocalSupplierExportDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            return SerializeToXml(suppliers, "suppliers");
        }

        //17.Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .Select(c => new CarWithPartsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                    Parts = c.PartsCars
                        .OrderByDescending(p => p.Part.Price)
                        .Select(pc => new PartExportDto
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price
                        })
                        .ToArray()
                })
                .ToList();

            return SerializeToXml(carsWithParts, "cars");
        }

        //18. Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var temp = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SalesInfo = c.Sales.Select(s => new
                    {
                        Prices = c.IsYoungDriver
                            ? s.Car.PartsCars.Sum(pc => Math.Round((double)pc.Part.Price * 0.95, 2))
                            : s.Car.PartsCars.Sum(pc => (double)pc.Part.Price)
                    }).ToArray()
                }).ToList();

            var customerSalesInfo = temp
                .OrderByDescending(x =>
                    x.SalesInfo.Sum(y => y.Prices))
                .Select(a => new CustomerExportDto
                {
                    FullName = a.FullName,
                    CarsBought = a.BoughtCars,
                    MoneySpent = a.SalesInfo.Sum(b => (decimal)b.Prices)
                })
                .ToArray();

            return SerializeToXml(customerSalesInfo, "customers");
        }

        //19. Export Sales With Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new SaleExportDto
                {
                    Car = new CarAttributesExportDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars
                        .Sum(pc => pc.Part.Price),
                    PriceWithDiscount = (double)(s.Car.PartsCars
                        .Sum(pc => pc.Part.Price) * (1 - s.Discount / 100))
                })
                .ToArray();

            return SerializeToXml(sales, "sales");
        }

        //Helper method from lecturer
        private static string SerializeToXml<T>(T dto, string xmlRootAttribute, bool omitDeclaration = false)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));
            StringBuilder stringBuilder = new StringBuilder();

            XmlWriterSettings settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = omitDeclaration,
                Encoding = new UTF8Encoding(false),
                Indent = true
            };

            using (StringWriter stringWriter = new StringWriter(stringBuilder, CultureInfo.InvariantCulture))
            using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings))
            {
                XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
                xmlSerializerNamespaces.Add(string.Empty, string.Empty);

                try
                {
                    xmlSerializer.Serialize(xmlWriter, dto, xmlSerializerNamespaces);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return stringBuilder.ToString();
        }
    }
}