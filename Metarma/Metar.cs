﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel;

//"METAR KBFI 021953Z 19009KT 10SM SCT047 SCT060 OVC075 17/09 A2992 RMK AO2 SLP133 T01670089";
namespace Metarma
{
    public class Metar : INotifyPropertyChanged
    {
        private string encodedDescription;

        public string EncodedDescription { 
            get{
                return encodedDescription;
            }
            set
            {
                encodedDescription = value;
                RaisePropertyChanged("EncodedDescription");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public Metar()
        {
            EncodedDescription = "";
        }

        public Metar(string rawMetar)
        { 
            metar_ = rawMetar;
            EncodedDescription = GetMetarOnly();
        }


        public static string StripString(string inputStr)
        {
        // Replace invalid characters with empty strings.
            return Regex.Replace(inputStr, @"[^\w\/ \.@\-\$\(\)\+]", ""); 
        }

        public string GetRawMetar()
        {
            return metar_;
        }

        public string GetMetarOnly()
        {
            string[] splitString = StripString(GetRawMetar()).Split(' ');
            // 0 is METAR
            // 1 is STATION
            // return everything else
            return String.Join(" ", splitString.Skip(2));
        }

        public string GetStation()
        {
            // will be second item after a split in ""
            string[] splitString = metar_.Split(' ');
            return splitString[1];
        }


        private string metar_;
    
    }
}
