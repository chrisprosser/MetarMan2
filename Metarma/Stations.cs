using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Metarma
{
    class Stations
    {
        public ObservableCollection<Station> StationsList = new ObservableCollection<Station>();

        // ohh boy, another singleton, but don't restrict the pattern to allow for testability.
        private static readonly Stations instance_ = new Stations();
        
        public static Stations Instance
        {
            get
            {
                return instance_;
            }
        }

        public Stations() 
        {

        }

        // does this interface really provide much, or should I just make people modify stations_ directly.
        // old c++ programmer wants a function on everything because my language can't hook things in.
        public void AddStation(string newStation)
        {
            // create a new metar and fire off the asynchronous read.
            Station st = new Station(newStation);
            StationsList.Add(st);

            if (true)
            {
                // only update after attaching the UI so it knows to redraw
                //Task t = System.Threading.Tasks.Task.Run(async () => await st.GetCurrentObsAsyncWorker());
                //t.Wait();
            }
            Task ignoreTheWarningIWantToRunFree = st.GetCurrentObsAsyncWorker();
            //ignoreTheWarningIWantToRunFree.Wait();
        }
    }
}
