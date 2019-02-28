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
        private string[] Links = { "http://hastalavista.pl/squash/klub/rezerwacje-2/", "http://hastalavista.pl/wp-admin/admin-ajax.php" };

        public async Task<string> GetSquashCourst(DateTime when, DateTime from, DateTime to)
        {
            int requestforToday = 0; //0: for Today and 1 for future dates
            var hours = new List<HastLaVistaPageOpenHours>(){
                new HastLaVistaPageOpenHours() { From = 6, To = 15},
                new HastLaVistaPageOpenHours() { From = 11, To = 20},
                new HastLaVistaPageOpenHours() { From = 15, To = 0}
            };

            var selectedHour = hours.FirstOrDefault(h => h.To >= from.Hour && h.To >= to.Hour);
            string data = when.Year + "-" + when.Month.ToString("00") + "-" + when.Day.ToString("00");

            if(when > DateTime.Now)
            {
                requestforToday = 1;
            }

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

            var response = await client.PostAsync(Links[requestforToday], content);

            return await response.Content.ReadAsStringAsync();
        }
        //public async Task<string> ReserveCourts(DateTime when)
        //{
            //string data = when.Year + "-" + when.Month.ToString("00") + "-" + when.Day.ToString("00");

            //Dictionary<string, string> values;
            //try
            //{
            //    values = new Dictionary<string, string>
            //{
            //    { "action", "RezerwujWybraneZapisz" },
            //    { "data", $"{data}" },
            //    { "REZ", "7_20:00_20:30" },
            //    { "REZ[]", "7_20:30_21:00" }
            //};
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}

            //return await response.Content.ReadAsStringAsync();
        //}
    }
}
