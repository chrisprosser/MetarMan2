using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//"METAR KBFI 021953Z 19009KT 10SM SCT047 SCT060 OVC075 17/09 A2992 RMK AO2 SLP133 T01670089";
namespace MetarMan2
{
    class Metar
    {
        public Metar()
        {
            bad_ = true;
        }

        public Metar(string rawMetar)
        { 
            metar_ = rawMetar;
            bad_ = false;
        }

        public bool IsBad()
        {
            return bad_;
        }

        public string GetRawMetar()
        {
            return metar_;
        }

        public string GetStation()
        {
            // will be second item after a split in ""
            string[] splitString = metar_.Split(' ');
            return splitString[1];
        }

        private string metar_;
        private bool bad_;
    
    }
}
