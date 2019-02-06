using HastaLaVista.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HastaLaVista.Squash
{
    public class SquashViewModel : BindableBase
    {
        public SquashViewModel()
        {
            ShowMapCommand = new RelayCommand(OnShowMap);
            SearchForSquashCourtsCommand = new RelayCommand(OnSearchForSquashCourts);
        }

        private void OnSearchForSquashCourts()
        {
            SearchForSquashCourtsRequest?.Invoke(new List<Court>(Courts));
        }

        public void LoadCourts()
        {
            Courts = new ObservableCollection<Court>();

            for (int i = 1; i < 33; i++)
            {
                Courts.Add(new Court(i));
            }
        }
        private ObservableCollection<Court> courts;
        public ObservableCollection<Court> Courts
        {
            get { return courts; }
            set { SetProperty(ref courts, value); }
        }

        private void OnShowMap()
        {
            ShowMapRequest?.Invoke();
        }

        public RelayCommand ShowMapCommand { get; set; }

        public event Action ShowMapRequest;

        public RelayCommand SearchForSquashCourtsCommand { get; set; }

        public event Action<List<Court>> SearchForSquashCourtsRequest;
    }
}
