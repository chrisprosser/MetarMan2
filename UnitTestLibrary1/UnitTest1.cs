using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

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
        public void GetStationTest()
        {
            string testRawMetar = "METAR KBFI 021953Z 19009KT 10SM SCT047 SCT060 OVC075 17/09 A2992 RMK AO2 SLP133 T01670089";

            Metar metar = new Metar(testRawMetar);

            Assert.AreEqual<string>("KBFI", metar.GetStation());

        }
    }

    [TestClass]
    public class NOAAServiceTest
    {
        [TestMethod]
        public void CurrentObsTest()
        {
            NOAAMetarService  noaa = new NOAAMetarService();

            Metar theMetar = noaa.GetCurrentObs("KBFI");

            Assert.AreEqual<string>("KBFI", theMetar.GetStation() );
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
