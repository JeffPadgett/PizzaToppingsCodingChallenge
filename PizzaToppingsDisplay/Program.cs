using static System.Console;
using JsonParserLib;
using System.Threading.Tasks;

namespace PizzaToppingsDisplay
{
    class Program
    {
        static async Task Main()
        {
            var pizzaService = new PizzaService();
            var AllPizzas = await pizzaService.GetPizzas();
            var Toppings = pizzaService.GetTopPizzaConfigurations(AllPizzas);

            WriteLine(" - Top 20 Pizza configurations - ");
            WriteLine("Pizza Configuration | Order Count");
            foreach (var topping in Toppings)
            {          
                WriteLine($"{topping.Key} | {topping.Value}");
                //TODO : Refactor to handle pinapple exception
            }
            ReadLine();
        }
    }
}
