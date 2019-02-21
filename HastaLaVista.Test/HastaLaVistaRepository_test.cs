using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HastaLaVista.Services;
using HastaLaVista.Models;
using System.Threading.Tasks;
using System.IO;

namespace HastaLaVista.Test
{
    /// <summary>
    /// Summary description for HastaLaVistaRepository_test
    /// </summary>
    [TestClass]
    public class HastaLaVistaRepository_test
    {
        private HastaLaVistaRepository repo;
        private string[] polskieDni = { "Niedziela", "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek", "Sobota" };
        private string[] polskieMiesiace = { "Styczeń", "Luty", "Marzec", "Kwicień", "Maj", "Czerwiec", "Licpiec", "Sierpień", "Wrzesień", "Październik", "Listopad", "Grudzień" };
        public HastaLaVistaRepository_test()
        {
            repo = new HastaLaVistaRepository();


        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            
        }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ReserveCourts_validInput_returnOK()
        {
            //DateTime when = new DateTime(2019, 02, 19);
            ////42_17:30_18:00
            ////42_18:00_18:30

            //var Reservations = new List<Court>()
            //{
            //    new Court(29,
            //        new List<CourtHours>(){
            //            new CourtHours(){From = "08:00", To ="08:30" },
            //            new CourtHours(){From = "08:30", To ="09:00" }
            //        }),
            //   new Court(25,
            //        new List<CourtHours>(){
            //            new CourtHours(){From = "15:00", To ="15:30" },
            //            new CourtHours(){From = "15:30", To ="16:00" }
            //         })
            //};


            //repo.ReserveCourts(when);
        }

        [TestMethod]
        public void GetSquoushCourts_NoInternetConnectivity_ReturnsErrorButWillNotFailed()
        {
            DateTime tomorrow = DateTime.Now.AddDays(1);
            DateTime fromTime = new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, 13, 0, 0);
            DateTime toTime = new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, 13,30, 0);

            //string expected = $"{polskieDni[(int)tomorrow.DayOfWeek]}, {tomorrow.Day} {polskieMiesiace[tomorrow.Month]}, {tomorrow.Year}"; // "Wtorek, 19 Luty, 2019";

            Task<string> response = repo.GetSquashCourst(tomorrow, fromTime, toTime);
            //response.Wait();

            //HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //doc.LoadHtml(response.Result.ToString());

            //var actual = doc.GetElementbyId("rez_wybrana_data").GetAttributeValue("value", "");

            //Assert.AreEqual(expected, actual);
            Assert.Fail();
        }
    }
}
