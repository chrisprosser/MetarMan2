using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace MetarMan2
{
    public sealed class PreferencesData
    {
        // preferences so far just consist of the stations array

        public List<string> stationsArr_ = new List<string>();

    }

    public sealed class Preferences
    {
        private static readonly Preferences instance = new Preferences();
        
        private PreferencesData data_ = new PreferencesData();

        public Preferences() { 
        }

        public Preferences(string xmlData)
        {
            LoadFromString(xmlData);
        }

        public static Preferences Instance
        {
            get
            {
                return instance;
            }
        }


        public List<string> GetStationsList()
        {
            return data_.stationsArr_;
        }

        public void AddStation(string newStation)
        {
            data_.stationsArr_.Add(newStation);
        }

        public string SaveToString()
        {
             XmlSerializer serializer = new XmlSerializer(typeof(PreferencesData));
             StringWriter textWriter = new StringWriter();
             serializer.Serialize(textWriter, data_);
            
            return textWriter.ToString();

        }

        public void LoadFromString(string loadFrom)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(PreferencesData));
            StringReader textReader = new StringReader(loadFrom);
            data_ = (PreferencesData)deserializer.Deserialize(textReader);
        }

        public void SaveToRegistry()
        {
            Windows.Storage.ApplicationDataContainer roamingSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;

            roamingSettings.Values["StationsList"] = SaveToString();
        }

        public void LoadFromRegistry()
        {

            Windows.Storage.ApplicationDataContainer roamingSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;

            string savedXml = (string)roamingSettings.Values["StationsList"];
            if (savedXml != null)
            {
                LoadFromString(savedXml);
            }
            else
            {
                data_.stationsArr_ = new List<string>();

                string[] stationsTemp = new string[]{ "KBFI", 
                                    "KAWO", 
                                    "KPWT", 
                                    "PABR", 
                                    "PACZ",
                                    "KIWA",
                                    "KHII",
                                    "KGEU","KBLI","KCLS","KHQM","KRNT","KSHN","KATX","KNOW", "KVUO", "KTIW", "KSFF"};
                data_.stationsArr_.AddRange(stationsTemp);
            }

            //stationsArr_ = stationsArr;
        }

    }
}
