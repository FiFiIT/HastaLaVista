using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using HastaLaVista.Helpers;
using System.Collections.Generic;
using HastaLaVista.Models;
using System.Linq;

namespace HastaLaVista.Test
{
    [TestClass]
    public class HastaHelper_Test
    {
        private List<Court> foudCourst;
        private string response; 
        [TestInitialize]
        public void InitializeValues()
        {
            response = File.ReadAllText(@"D:\nauka\GitHub\HastaLaVista\HastaLaVista.Test\response.txt");
            foudCourst = new List<Court>()
            {
                new Court(2,
                    new List<CourtHours>(){
                        new CourtHours(){From = "15:00", To ="15:30" }
                    }),
                new Court(25,
                    new List<CourtHours>(){
                        new CourtHours(){From = "15:00", To ="15:30" },
                        new CourtHours(){From = "15:30", To ="16:00" },
                        new CourtHours(){From = "16:00", To ="16:30" },
                        new CourtHours(){From = "16:30", To ="17:00" },
                        new CourtHours(){From = "17:30", To ="14:00" }
                    }),
                new Court(26,
                    new List<CourtHours>(){
                        new CourtHours(){From = "09:00", To ="09:30" },
                        new CourtHours(){From = "10:00", To ="10:30" },
                        new CourtHours(){From = "10:30", To ="11:00" },
                        new CourtHours(){From = "12:00", To ="12:30" }
                    }),
                new Court(29,
                    new List<CourtHours>(){
                        new CourtHours(){From = "08:00", To ="08:30" },
                        new CourtHours(){From = "08:30", To ="09:00" },
                        new CourtHours(){From = "16:00", To ="16:30" },
                        new CourtHours(){From = "16:30", To ="17:00" },
                        new CourtHours(){From = "17:00", To ="17:30" }
                    }),
            };
        }

        [TestMethod]
        public void GetFreeSquashCourts_ValidRequest_ReturnCourts()
        {
            var freecourts = HastaHelper.GetFreeSquashCourts(response, new List<Court>() { new Court(2) });

            Assert.AreEqual(32, freecourts.Count);
        }

        [TestMethod]
        public void FilterByTimeRange_ValidRequest_Return1Court()
        {
            DateTime timeFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15, 0, 0);
            DateTime timeTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0);
            int length = 1; //1 hour between 15:00 and 17:00 date should not matter at this point

            var courtsToPlay = HastaHelper.FilterByTimeRange(foudCourst, timeFrom, timeTo, length);

            Assert.AreEqual(courtsToPlay.Count, 1);
            Assert.AreEqual(courtsToPlay[0].Number, 25);
        }

        [TestMethod]
        public void FilterByTimeRange_ValidRequest_Return2Courts()
        {
            DateTime timeFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15, 0, 0);
            DateTime timeTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0);
            int length = 1; //1 hour between 15:00 and 17:00 date should not matter at this point

            var courtsToPlay = HastaHelper.FilterByTimeRange(foudCourst, timeFrom, timeTo, length, 2);

            Assert.AreEqual(courtsToPlay.Count, 2);
            Assert.AreEqual(courtsToPlay[0].Number, 25);
            Assert.AreEqual(courtsToPlay[1].Number, 29);
        }
    }
}
