using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Threading.Tasks;

using MetarMan2;

namespace UnitTestLibrary1
{
    [TestClass]
    public class MetarTest
    {
        [TestMethod] 
        public void CtorTest()
        {
            string testRawMetar = "METAR KBFI 021953Z 19009KT 10SM SCT047 SCT060 OVC075 17/09 A2992 RMK AO2 SLP133 T01670089";

            Metar metar = new Metar(testRawMetar);

            Assert.AreEqual<string>(testRawMetar, metar.GetRawMetar());
        }

        [TestMethod]
        public void GetKBFIStationTest()
        {
            string testRawMetar = "METAR KBFI 021953Z 19009KT 10SM SCT047 SCT060 OVC075 17/09 A2992 RMK AO2 SLP133 T01670089";

            Metar metar = new Metar(testRawMetar);

            Assert.AreEqual<string>("KBFI", metar.GetStation());

        }

        [TestMethod]
        public void TestBadMetar()
        {
            Metar metar = new Metar();

            Assert.IsTrue(metar.IsBad());
        }

        [TestMethod]
        public void TestBadStation()
        {
            Metar metar = new Metar();
            metar.SetBadStation("KLLL");

            Assert.AreEqual<string>("KLLL", metar.GetStation());
            Assert.IsTrue(metar.IsBad());
        }

        [TestMethod]
        public void TestGetMetarOnly()
        {
            string testRawMetar = "METAR KBFI 021953Z 19009KT 10SM SCT047 SCT060 OVC075 17/09 A2992 RMK AO2 SLP133 T01670089";

            Metar metar = new Metar(testRawMetar);
            Assert.AreEqual<string>("021953Z 19009KT 10SM SCT047 SCT060 OVC075 17/09 A2992 RMK AO2 SLP133 T01670089", metar.GetMetarOnly());
        }

        [TestMethod]
        public void TestStrip()
        {
            string stripped = Metar.StripString("METAR KBFI 021953Z 19009KT 10SM SCT047 SCT060 OVC075 17/09 A2992 RMK AO2 SLP133 T01670089\r\n\t");

            Assert.AreEqual<string>("METAR KBFI 021953Z 19009KT 10SM SCT047 SCT060 OVC075 17/09 A2992 RMK AO2 SLP133 T01670089", stripped);

        }

    }

    [TestClass]
    public class NOAAServiceTest
    {
        [TestMethod]
        public void CurrentKBFIObsTest()
        {
            NOAAMetarService  noaa = new NOAAMetarService();

            Task<Metar> theMetar = noaa.GetCurrentObsAsync("KBFI");

            Assert.AreEqual<string>("KBFI", theMetar.Result.GetStation() );
        }

        [TestMethod]
        public void ConformOnlyAlpha()
        {
            NOAAMetarService noaa = new NOAAMetarService();

            Task<Metar> theMetar = noaa.GetCurrentObsAsync("KBFI");

            string rawMetar = theMetar.Result.GetRawMetar();
            //rawMetar.
            Assert.AreEqual<string>("KBFI", theMetar.Result.GetStation());
        }

        [TestMethod]
        public void CurrentKAWOObsTest()
        {
            NOAAMetarService noaa = new NOAAMetarService();

            Task<Metar> theMetar = noaa.GetCurrentObsAsync("KAWO");

            Assert.AreEqual<string>("KAWO", theMetar.Result.GetStation());
        }

        [TestMethod]
        public void GoodStationObsTest()
        {
            NOAAMetarService noaa = new NOAAMetarService();

            Task<Metar> theMetar = noaa.GetCurrentObsAsync("KAWO");

            Assert.IsTrue(!theMetar.Result.IsBad());
        }


        [TestMethod]
        public void BadStationObsTest()
        {
            NOAAMetarService noaa = new NOAAMetarService();

            Task<Metar> theMetar = noaa.GetCurrentObsAsync("XXXX");

            Assert.IsTrue( theMetar.Result.IsBad());
            Assert.AreEqual<string>("XXXX", theMetar.Result.GetStation());
        }

        [TestMethod]
        public void ParseLineTest()
        {
            string line = @"000
                SAUS70 KWBC 030000 RRC
                MTRBFI
                METAR KBFI 022353Z 22010G15KT 10SM FEW040 BKN080 18/07 A2993 RMK AO2 SLP134 T01830072 10189 20144 50001";
            NOAAMetarService noaa = new NOAAMetarService();

            string result = noaa.ParseResultForMetarLine(line);
            Assert.AreEqual<string>("METAR KBFI 022353Z 22010G15KT 10SM FEW040 BKN080 18/07 A2993 RMK AO2 SLP134 T01830072 10189 20144 50001", result);


        }
    }
}
