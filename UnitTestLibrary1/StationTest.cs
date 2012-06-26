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
    class StationTest
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
    }
}
