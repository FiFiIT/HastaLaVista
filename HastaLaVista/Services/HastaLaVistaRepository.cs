using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HastaLaVista.Models;
using System.Net.Http;

namespace HastaLaVista.Services
{
    public class HastaLaVistaRepository : IHastaLaVistaRepository
    {
        private HttpClient client = new HttpClient();

        public async Task<string> GetSquashCourst(DateTime when, DateTime from, DateTime to, int duration, IList<Court> courst)
        {
            var hours = new List<OpenHours>(){
                new OpenHours() { From = 6, To = 15},
                new OpenHours() { From = 11, To = 20},
                new OpenHours() { From = 15, To = 0}
            };

            var selectedHour = hours.FirstOrDefault(h => h.To >= from.Hour && h.To >= to.Hour);
            string data = when.Year + "-" + when.Month.ToString("00") + "-" + when.Day.ToString("00");

            var values = new Dictionary<string, string>
            {
                { "operacja", "ShowRezerwacjeTable" },
                { "action", "ShowRezerwacjeTable" },
                { "data", $"{data}" },
                { "obiekt_typ", "squash" },
                { "godz_od", $"{selectedHour.FromTime}" },
                { "godz_do", $"{selectedHour.ToTime}" }
            };
            
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("http://hastalavista.pl/squash/klub/rezerwacje-2/", content);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
