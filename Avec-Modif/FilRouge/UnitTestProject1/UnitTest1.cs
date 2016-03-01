using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vérif_Email;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Boolean attendu = false;

            Boolean resultat;

            String intru = "";


            resultat = Program.Verification(intru);

            Assert.AreEqual(attendu, resultat);



        }
        [TestMethod]
        public void TestMethod2()
        {
            Boolean attendu = false;

            Boolean resultat;

            String intru = "@@@";


            resultat = Program.Verification(intru);

            Assert.AreEqual(attendu, resultat);



        }
        [TestMethod]
        public void TestMethod3()
        {
            Boolean attendu = false;

            Boolean resultat;

            String intru = "m@";


            resultat = Program.Verification(intru);

            Assert.AreEqual(attendu, resultat);



        }
        [TestMethod]
        public void TestMethod4()
        {
            Boolean attendu = true;

            Boolean resultat;

            String intru = "mm@";


            resultat = Program.Verification(intru);

            Assert.AreEqual(attendu, resultat);



        }
    }
}
