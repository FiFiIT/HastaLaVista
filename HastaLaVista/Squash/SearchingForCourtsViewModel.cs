using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HastaLaVista.Models;
using System.Windows.Forms;
using HastaLaVista.Helpers;
using HastaLaVista.Services;

namespace HastaLaVista.Squash
{
    public class SearchingForCourtsViewModel : BindableBase
    {
        private Timer aTimer;
        private int timerCountdown = 1 * 10;
        private int counter;
        private IHastaLaVistaRepository repo;
        private MainWindowViewModel viewModel;

        public SearchingForCourtsViewModel(MainWindowViewModel vm, IHastaLaVistaRepository repository)
        {
            viewModel = vm;
            repo = repository;

            StopSearchingCommand = new RelayCommand(OnStopSearching);
            counter = timerCountdown;

            aTimer = new Timer();
            aTimer.Interval = 1000;
            aTimer.Tick += ATimer_Tick;
        }

        public async void CheckForCourts()
        {
            Task<string> response = repo.GetSquashCourst(viewModel.SelectedDate, viewModel.GodzinaOd, viewModel.GodzinaDo);
            var freeCourts = HastaHelper.GetFreeSquashCourts(await response, selectedCourts);
            var availableReservations = HastaHelper.FilterByTimeRange(freeCourts, viewModel.GodzinaOd, viewModel.GodzinaDo, viewModel.Length - 1);

            if (availableReservations.Count > 0)
            {
                aTimer.Stop();
                Reservations = availableReservations;
            }
            else
            {
                ResetTime();
                aTimer.Start();
            }

            //Reservations = new List<Court>()
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
        }

        public void StartCounting()
        {
            aTimer.Start();
        }

        private void ATimer_Tick(object sender, EventArgs e)
        {
            TimeLeft = GetCountdownTimer(counter);

            if (counter <= 0)
            {
                CheckForCourts();
            }
            else
            {
                counter--;
            }
        }

        private IList<Court> reservations;
        public IList<Court> Reservations
        {
            get { return reservations; }
            set { SetProperty(ref reservations, value); }
        }

        private void OnStopSearching()
        {
            aTimer.Stop();
            ResetTime();
        }

        private string GetCountdownTimer(int counter)
        {
            string minutes = (counter / 60).ToString("d2");
            string seconds = (counter - (counter / 60) * 60).ToString("d2");

            return $"{minutes}:{seconds}";
        }

        private void ResetTime()
        {
            counter = timerCountdown;
            TimeLeft = GetCountdownTimer(counter);
        }

        private IEnumerable<Court> selectedCourts;
        public IEnumerable<Court> SelectedCourts
        {
            get { return selectedCourts; }
            set { SetProperty(ref selectedCourts, value); }
        }

        private string timeLeft;
        public string TimeLeft
        {
            get { return timeLeft; }
            set { SetProperty(ref timeLeft, value); }
        }

        public RelayCommand StopSearchingCommand { get; set; }
    }
}
