using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metarma
{
    class Station
    {
        public string StationID { get; set; }
        public Metar LocalMetar { get; set; }

        public Station(string stationID)
        {
            StationID = stationID;
            LocalMetar = new Metar(); // start with an empty one?

            bad_ = true;
        }

        public void SetBadStation(string station)
        {
            bad_ = true;
        }

        public bool IsBad()
        {
            return bad_;
        }

       /* public Task GetCurrentObsAsync()
        {
           // Task t = new Task(GetCurrentObsAsyncWorker);
          //  t.Start();
          //  return t;
        }
        */
        public async Task GetCurrentObsAsyncWorker()
        {
            NOAAMetarService service = new NOAAMetarService();

            Metar m = await service.GetCurrentObsAsync(StationID);
            if (m != null)
            {
                LocalMetar.EncodedDescription = m.EncodedDescription;
            }
        }

        
        private bool bad_;
    }
}
