using static Newtonsoft.Json.JsonConvert;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Threading.Tasks;

namespace JsonParserLib
{
    public class PizzaService
    {
        // The current standard is HttpClient https://docs.microsoft.com/en-us/dotnet/api/system.net.httpwebrequest?view=net-5.0
        public async Task<List<Pizza>> GetPizzas(string strUri = "https://www.brightway.com/CodeTests/pizzas.json")
        {
            var Client = new WebClient();
            var Json = await Client.DownloadStringTaskAsync(strUri);
            return DeserializeObject<List<Pizza>>(Json);
        }

        public Dictionary<string, int> GetTopPizzaConfigurations(List<Pizza> pizzas)
        {
            return pizzas.GroupBy(n => string.Join("|", n.Toppings.OrderBy(s => s)))
                .Select(g => new
                {
                    Name = string.Join(",", g.First().Toppings.OrderBy(n => n)).ToString()
                    ,
                    Count = (int)g.Count()
                }).OrderByDescending(g => g.Count).Take(20).ToDictionary(n => n.Name, n => n.Count);
        }

       
    }
}
