using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingHelperApp;

namespace HastaLaVista.Models
{
    public class Court
    {
        public Court(int number)
        {
            Number = number;
        }

        public int Number { get; set; }

        public string Name
        {
            get { return $"Kort {Number}"; }
        }
        public bool Active { get; set; }

        public IList<CourtHours> HoursOpen { get; set; }
    }
}
