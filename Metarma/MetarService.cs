using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metarma
{
    interface MetarService
    {
        Task<Metar> GetCurrentObsAsync(string icao);
    }
}
