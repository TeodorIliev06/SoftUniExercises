namespace Zad_28
{
    internal class Program
    {
        private static List<Furniture> furnitures;

        static void Main(string[] args)
        {
            /*
               Table 100
               Table 120.50
               Cabinet 200 10
               Table 80
               Cabinet 220.50 5
               Cabinet 300 10
               Table 95
               END
             */

            Console.WriteLine("When entering a furniture type make sure it is in PascalCase.");

            var furnitures = new List<Furniture>();

            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                var tokens = line.Split();
                var typeProduct = tokens[0];
                var productionPrice = double.Parse(tokens[1]);

                Furniture furniture = typeProduct switch
                {
                    nameof(Table) => new Table(typeProduct, productionPrice),
                    nameof(Cabinet) => new Cabinet(typeProduct, productionPrice, int.Parse(tokens[2]))
                };

                furnitures.Add(furniture);
            }

            Console.WriteLine("All tables:");
            foreach (var table in furnitures.Where(f => f.TypeProduct == nameof(Table)))
            {
                Console.WriteLine(table);
            }

            Console.WriteLine("All cabinets:");
            foreach (var cabinet in furnitures.Where(f => f.TypeProduct == nameof(Cabinet)))
            {
                Console.WriteLine(cabinet);
            }
        }
    }
}
