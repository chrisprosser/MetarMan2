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
        public ObservableCollection<List<Metar>> stations_ = new ObservableCollection<List<Metar>>();

        public Stations() 
        {

        }
    }
}
