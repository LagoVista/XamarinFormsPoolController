using LagoVista.PoolController.Utilities;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LagoVista.PoolController.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        Services.PoolService _poolService;

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            //TODO: Should be a design time check and not run this.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainViewModel()
        {
            RefreshCommand = RelayCommand.Create(Refresh);
            _poolService = new Services.PoolService();
            Pool = new Models.Pool(_poolService);
        }

        public MainViewModel(Models.Pool pool)
        {
            RefreshCommand = RelayCommand.Create(Refresh);
            _poolService = new Services.PoolService();
            Pool = pool;
        }

        public async void Refresh()
        {
            await Pool.RefreshAsync();
        }

        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value;  RaisePropertyChanged(); }
        }
        
        public Models.Pool Pool { get; private set; }

        public RelayCommand RefreshCommand { get; private set; }
    }
}
