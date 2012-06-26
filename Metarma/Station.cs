using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metarma
{
    class Station
    {
        public string StationID;
        public Metar LocalMetar;

        public Station(string stationID)
        {
            StationID = stationID;
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

        public Task GetCurrentObsAsync()
        {
            Task t = new Task(GetCurrentObsAsyncWorker);

            return t;
        }

        public async void GetCurrentObsAsyncWorker()
        {
            NOAAMetarService service = new NOAAMetarService();

            Metar m = await service.GetCurrentObsAsync(StationID);

            LocalMetar = m;
        }

        
        private bool bad_;
    }
}
