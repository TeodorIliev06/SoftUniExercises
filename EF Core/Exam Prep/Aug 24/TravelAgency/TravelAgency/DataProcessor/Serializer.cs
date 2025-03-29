namespace TravelAgency.DataProcessor
{
    using TravelAgency.Data;
    using TravelAgency.Data.Models.Enums;
    using TravelAgency.DataProcessor.ExportDtos;

    using static Common.Utilities;
    using static Common.EntityValidationConstants.Booking;
    using Newtonsoft.Json;

    public class Serializer
    {
        private static XmlHelper? xmlHelper;

        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            xmlHelper = new XmlHelper();
            var bookings = context.Guides
                .Where(g => g.Language == Language.Spanish)
                .Select(g => new GuideExportDto()
                {
                    FullName = g.FullName,
                    TourPackages = g.TourPackagesGuides.Select(tp => new TourPackageDto()
                    {
                        Name = tp.TourPackage.PackageName,
                        Description = tp.TourPackage.Description,
                        Price = tp.TourPackage.Price
                    })
                    .OrderByDescending(tpDto => tpDto.Price)
                    .ThenBy(tpDto => tpDto.Name)
                    .ToArray()
                })
                .OrderByDescending(guideDto => guideDto.TourPackages.Length)
                .ThenBy(guideDto => guideDto.FullName)
            .ToArray();

            return xmlHelper.Serialize(bookings, "Guides");
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            var requiredPackageName = "Horse Riding Tour";

            var customers = context.Customers
                .Where(c => c.Bookings
                    .Any(b => b.TourPackage.PackageName == requiredPackageName))
                .ToArray()
                .Select(c => new CustomerExportDto()
                {
                    FullName = c.FullName,
                    PhoneNumber = c.PhoneNumber,
                    Bookings = c.Bookings
                        .Where(b => b.TourPackage.PackageName == requiredPackageName)
                        .OrderBy(b => b.BookingDate)
                        .Select(b => new BookingExportDto()
                        {
                            TourPackageName = b.TourPackage.PackageName,
                            Date = b.BookingDate.ToString(BookingDateFormat)
                        })
                        .OrderBy(bookingDto => bookingDto.Date)
                        .ToArray()
                })
                .OrderByDescending(customerDto => customerDto.Bookings.Length)
                .ThenBy(customerDto => customerDto.FullName)
                .ToArray();

            return JsonConvert.SerializeObject(customers, JsonHelper.Settings);
        }
    }
}
