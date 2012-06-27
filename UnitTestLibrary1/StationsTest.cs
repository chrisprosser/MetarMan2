using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;


using Metarma;

namespace UnitTestLibrary1
{
    [TestClass]
    public class StationsTest
    {

        [TestMethod]
        public void SingletonWorks()
        {
            Assert.IsNotNull(Stations.Instance);
            Assert.IsNotNull(Stations.Instance.StationsList);
        }
    }
}
