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
        public ObservableCollection<Station> stations_ = new ObservableCollection<Station>();

        public Stations() 
        {

        }

        // does this interface really provide much, or should I just make people modify stations_ directly.
        // old c++ programmer wants a function on everything because my language can't hook things in.
        public void AddStation(string newStation)
        {
            // create a new metar and fire off the asynchronous read.
            stations_.Add(new Station(newStation));
        }
    }
}
