using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaLaVista.Models
{
    public class CourtHours
    {
        public CourtHours()
        {}

        public string From { get; set; }
        public DateTime TimeFrom
        {
            get { return DateTime.ParseExact(From, "HH:mm", CultureInfo.InvariantCulture); }
        }
        public string To { get; set; }
        public DateTime TimeTo
        {
            get { return DateTime.ParseExact(To, "HH:mm", CultureInfo.InvariantCulture); }
        }
    }
}
