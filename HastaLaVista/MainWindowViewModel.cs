using HastaLaVista.Badminton;
using HastaLaVista.Helpers;
using HastaLaVista.Maps;
using HastaLaVista.Models;
using HastaLaVista.Services;
using HastaLaVista.Squash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace HastaLaVista
{
    public class MainWindowViewModel : BindableBase
    {
        private IHastaLaVistaRepository repo = new HastaLaVistaRepository();
        private SquashViewModel squashViewModel = new SquashViewModel();
        private BadmintonViewModel badmintonViewModel = new BadmintonViewModel();
        private HastaLaVistaView hastaLaVistaPlan;

        public MainWindowViewModel()
        {
            squashViewModel.ShowMapRequest += NavToHastaLaVistaPlan;
            squashViewModel.SearchForSquashCourtsRequest += SearchForSquashCourts;
        }

        private async void SearchForSquashCourts(List<Court> selectedCourts)
        {
            Task<string> response = repo.GetSquashCourst(SelectedDate, GodzinaOd, GodzinaDo, Length, selectedCourts);
            squashViewModel.Courts = new ObservableCollection<Court>(HastaHelper.GetFreeSquashCourts(await response));
        }

        private void NavToHastaLaVistaPlan()
        {
            if (hastaLaVistaPlan == null)
            {
                hastaLaVistaPlan = new HastaLaVistaView();
            }

            if(hastaLaVistaPlan.WindowState == System.Windows.WindowState.Minimized)
            {
                hastaLaVistaPlan.WindowState = System.Windows.WindowState.Normal;
            }

            hastaLaVistaPlan.Show();
            hastaLaVistaPlan.Focus();
        }

        public void LoadStartingData()
        {
            Activities = new List<string>()
            {
                "Badminton",
                "Squash"
            };

            SelectedDate = DateTime.Now;

            GodzinaOd = DateTime.Parse("18:00");
            GodzinaDo = DateTime.Parse("19:00");

            Length = 2;

        }

        private IList<double> timeToPlay;
        public double TimeToPlay
        {
            get
            {
                if (timeToPlay == null)
                {
                    timeToPlay = new List<double>() { 0.5, 1, 1.5, 2 };
                }

                try
                {
                    return timeToPlay[Length - 1];
                }
                catch (Exception)
                {
                    return timeToPlay[0];
                }

            }
        }

        private IList<string> activities;
        public IList<string> Activities
        {
            get { return activities; }
            set { SetProperty(ref activities, value); }
        }
        private string selectedActivity;
        public string SelectedActivity
        {
            get { return selectedActivity; }
            set
            {
                SetProperty(ref selectedActivity, value);
                OnNav(selectedActivity);
            }
        }

        private void OnNav(string selectedActivity)
        {
            switch (selectedActivity)
            {
                case "Badminton":
                    CurrentActivity = badmintonViewModel;
                    break;
                case "Squash":
                    CurrentActivity = squashViewModel;
                    break;
            }

        }

        private DateTime selectedDate;
        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set { SetProperty(ref selectedDate, value); }
        }
        private DateTime godzinaOd;
        public DateTime GodzinaOd
        {
            get { return godzinaOd; }
            set { SetProperty(ref godzinaOd, value); }
        }
        private DateTime godzinaDo;
        public DateTime GodzinaDo
        {
            get { return godzinaDo; }
            set { SetProperty(ref godzinaDo, value); }
        }
        private int length;
        public int Length
        {
            get { return length; }
            set
            {
                SetProperty(ref length, value);
                OnPropertyChanged("TimeToPlay");
            }
        }

        private BindableBase currentActivity;
        public BindableBase CurrentActivity
        {
            get { return currentActivity; }
            set { SetProperty(ref currentActivity, value); }
        }

    }
}
