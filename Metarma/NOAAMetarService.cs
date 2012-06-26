using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Diagnostics;
using System.Xml;

namespace Metarma
{
    class NOAAMetarService
    {
        //http://www.weather.gov/data/METAR/KBFI.1.txt
        //http://www.weather.gov/xml/current_obs/KAWO.xml

        class BadStringInParseResultForMetarLine : System.Exception { }

        public string ParseResultForMetarLine(string rawQueryResult)
        {
            /*000
                SAUS70 KWBC 030000 RRC
                MTRBFI
                METAR KBFI 022353Z 22010G15KT 10SM FEW040 BKN080 18/07 A2993 RMK AO2
                SLP134 T01830072 10189 20144 50001
            */
            // return everything from METAR to the end of data
            int index = rawQueryResult.IndexOf("METAR");
            if (index == -1)
            {
                throw new ArgumentOutOfRangeException();
            }

            return rawQueryResult.Substring(index);
        }

        public async Task<Metar> GetCurrentObsAsync(string icao)
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                // Add a user agent header in case the 
                // requested URI contains a query.

                //client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                httpClient.MaxResponseContentBufferSize = 256000;
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
                /*
               // use the XML stuff. I all really care about is the uri for the raw metar.
               Task<string> response = httpClient.GetStringAsync("http://www.weather.gov/xml/current_obs/KBFI.xml");

               string s = response.Result;
               XmlReader   xmlReader = new XmlReader()


               Debug.WriteLine(s);
               */

                string requestURI = "http://www.weather.gov/data/METAR/" + icao + ".1.txt";

                string response = await httpClient.GetStringAsync(requestURI);

                return new Metar(ParseResultForMetarLine(response));
            }
            catch (Exception )
            {
                return null;
            }
        }
    }
}
