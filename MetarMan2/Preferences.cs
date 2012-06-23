using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarMan2
{
    class Preferences
    {
        public static List<string> GetStationsList()
        {
            List<string> stationsArr;

            Windows.Storage.ApplicationDataContainer roamingSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;

            Object savedList = roamingSettings.Values["StationsList"];
            if (savedList != null)
            {
                stationsArr = (List<string>)savedList;
            }
            else
            {
                stationsArr = new List<string>();

                string[] stationsTemp = new string[]{ "KBFI", 
                                    "KAWO", 
                                    "KPWT", 
                                    "PABR", 
                                    "PACZ",
                                    "KIWA",
                                    "KHII",
                                    "KGEU","KBLI","KCLS","KHQM","KRNT","KSHN","KATX","KNOW", "KVUO", "KTIW", "KSFF"};
                stationsArr.AddRange(stationsTemp);
            }

            return stationsArr;
        }

        public static void AddStation(string newStation)
        {
            Windows.Storage.ApplicationDataContainer roamingSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;

            List<string> stations = Preferences.GetStationsList();

            stations.Add(newStation);

            roamingSettings.Values["StationsList"] = stations;
    
        }
    }
}
