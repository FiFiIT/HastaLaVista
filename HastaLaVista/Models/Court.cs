using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaLaVista.Models
{
    public class Court
    {
        public Court(int number)
        {
            Number = number;
            Active = true;
        }

        public Court(int number, IList<CourtHours> courtHours)
            :this(number)
        {
            HoursOpen = courtHours;
        }

        public int Number { get; set; }
        public string Name
        {
            get { return $"Kort {Number}"; }
        }
        public bool Active { get; set; }

        public IList<CourtHours> HoursOpen { get; set; }

        public string ReservedFrom
        {
            get
            {
                if(HoursOpen != null && HoursOpen.Count > 0)
                {
                    return HoursOpen.First().TimeFrom.ToShortTimeString();
                }
                else
                {
                    return String.Empty;
                }

            }
        }
        public string ReservedTo
        {
            get
            {
                if (HoursOpen != null && HoursOpen.Count > 0)
                {
                    return HoursOpen.Last().TimeTo.ToShortTimeString();
                }
                else
                {
                return String.Empty;
            }
        }
        }

        public override string ToString()
        {
            return $"{Number}_{HoursOpen.First().From}_";
        }
    }
}
