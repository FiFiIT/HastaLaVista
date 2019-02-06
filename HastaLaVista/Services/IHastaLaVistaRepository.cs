using HastaLaVista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaLaVista.Services
{
    public interface IHastaLaVistaRepository
    {
        Task<string> GetSquashCourst(DateTime when, DateTime from, DateTime to, int duration, IList<Court> courst);
    }
}
