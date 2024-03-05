using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ValutaValto;

namespace ValutaValto
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<Valuta> valutavalto = new List<Valuta>();
            valutavalto = await ValutavaloAdatok();
            Console.WriteLine($"1 {valutavalto[0].Base} - {valutavalto[0].Rates["HUF"]} HUF - {valutavalto[0].Rates["USD"]} USD");
            
            await Console.Out.WriteLineAsync("Program vége");
            Console.ReadLine();
        }

        private static async Task<List<Valuta>> ValutavaloAdatok()
        {
            List<Valuta> valutavalto = new List<Valuta>();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://infojegyzet.hu/webszerkesztes/php/valuta/api/v1/arfolyam/");
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                valutavalto.Add(Valuta.FromJson(jsonString));
                
                
            }
            return valutavalto;
        }
    }
}
