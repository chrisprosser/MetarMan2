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
    public class StationTest
    {
        [TestMethod]
        public void BasicIDTest()
        {
            Station st = new Station("KBFI");

            Assert.AreEqual<string>("KBFI", st.StationID);
        }

        [TestMethod]
        public void TestBadStation()
        {
            Station s = new Station("KAWO");

            Assert.IsTrue(s.IsBad());
        }

        [TestMethod]
        public void AsyncMetarGet()
        {
            Station s = new Station("KAWO");
            Task t = s.GetCurrentObsAsyncWorker();
            t.Wait();

            Assert.IsNotNull(s.LocalMetar);
        }
    }
}
