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


            Metar metar = new Metar("KROW");
        }
    }
}
