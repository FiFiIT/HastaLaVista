using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaLaVista.Models
{
    public class HastLaVistaPageOpenHours
    {
        public HastLaVistaPageOpenHours()
        {

        }

        public HastLaVistaPageOpenHours(int from, int to)
        {
            From = from;
            To = to;
        }

        public int From { get; set; }
        public string FromTime
        {
            get { return $"{From.ToString("00")}:00"; }
        }
        public int To { get; set; }
        public string ToTime
        {
            get { return $"{To.ToString("00")}:00"; }
        }
    }
}
