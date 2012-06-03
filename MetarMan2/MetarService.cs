using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarMan2
{
    interface MetarService
    {
        Metar GetCurrentObs(string icao);
    }
}
