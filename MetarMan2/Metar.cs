using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarMan2
{
    class Metar
    {
        public Metar(String rawMetar)
        { }

        private String metar_;

        public String GetRawMetar()
        {
            return metar_;
        }
    }
}
