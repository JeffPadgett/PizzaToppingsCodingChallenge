using static System.Console;
using JsonParserLib;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PizzaToppingsDisplay
{
    class Program
    {
        static async Task Main()
        {
            var pizzaService = new PizzaService();
            List<Pizza> AllPizzas = await pizzaService.GetPizzas();
            Dictionary<string,int> TopPizzaConfigurations = pizzaService.GetTopPizzaConfigurations(AllPizzas);

            WriteLine(" - Top 20 Pizza configurations - ");
            WriteLine("Pizza Configuration | Order Count");
            foreach (var pizza in TopPizzaConfigurations)
            {          
                WriteLine($"{pizza.Key} | {pizza.Value}");
                //TODO : Refactor to handle pinapple exception - kidding
            }
            ReadLine();
        }
    }
}
