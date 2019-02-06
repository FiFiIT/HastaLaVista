using HastaLaVista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HastaLaVista.Helpers
{
    public class HastaHelper
    {
        public static List<Court> GetFreeSquashCourts(string hastaResponse)
        {
            const string startText = "<tr  data-obie_id=\"1\">";
            const string endText = "32</td></tr>";

            var start = hastaResponse.IndexOf(startText);
            var end = hastaResponse.IndexOf(endText, start) + endText.Length;
            var length = end - start;
            var result = hastaResponse.Substring(start, length);

            List<Court> squash = new List<Court>();

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            HtmlAgilityPack.HtmlDocument docHelp = new HtmlAgilityPack.HtmlDocument();

            doc.LoadHtml(result);

            foreach (var node in doc.DocumentNode.SelectNodes($"//tr"))
            {
                docHelp.LoadHtml(node.InnerHtml);
                string v = docHelp.DocumentNode.SelectSingleNode("td").InnerText;

                if (String.IsNullOrEmpty(v) || !Int32.TryParse(v, out int courtNumber))
                {
                    continue;
                }

                Court court = new Court(courtNumber);

                var inputNodes = docHelp.DocumentNode.SelectNodes("//td/input");

                if(!inputNodes.Any())
                {
                    continue;
                }

                List<CourtHours> hours = inputNodes
                    .Select(i => new CourtHours { From = i.Attributes["data-godz_od"].Value, To = i.Attributes["data-godz_do"].Value }).ToList();

                court.HoursOpen = hours;
                squash.Add(court);
            }

            return squash;
        }
    }
}
