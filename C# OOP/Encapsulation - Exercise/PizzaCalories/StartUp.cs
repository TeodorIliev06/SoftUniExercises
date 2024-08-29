namespace PizzaCalories;

internal class StartUp
{
    static void Main(string[] args)
    {
        try
        {
            string[] pizzaTokens = Console.ReadLine().Split(' ');
            string pizzaName = pizzaTokens[1];
            Pizza pizza = new(pizzaName);

            string[] doughTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string flourType = doughTokens[1];
            string bakingTechnique = doughTokens[2];
            double doughWeight = double.Parse(doughTokens[3]);
            pizza.Dough = new Dough(flourType, bakingTechnique, doughWeight);

            string input;
            while ((input = Console.ReadLine()) is not "END")
            {
                string[] toppingTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string toppingType = toppingTokens[1];
                double toppingWeight = double.Parse(toppingTokens[2]);
                pizza.AddToping(new Topping(toppingType, toppingWeight));
            }
            Console.WriteLine(pizza);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
