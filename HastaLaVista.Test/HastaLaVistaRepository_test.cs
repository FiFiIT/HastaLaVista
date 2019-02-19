using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HastaLaVista.Services;
using HastaLaVista.Models;

namespace HastaLaVista.Test
{
    /// <summary>
    /// Summary description for HastaLaVistaRepository_test
    /// </summary>
    [TestClass]
    public class HastaLaVistaRepository_test
    {
        private HastaLaVistaRepository repo;
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
    }
}
