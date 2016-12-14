using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LagoVista.PoolController
{
    public static class ViewModelLocator
    {
        static Models.Pool _poolSampleData = new Models.Pool(null)
        {
            FlowStatus = "warning",
            HighPressureStatus = "ok",
            LowPressureStatus = "ok",
            Mode = "off",
            Temperature = "85",
            Output = "Spa",
            Source = "Spa",
            PoolSetpoint = "90",
            SpaMode = "Jets",
            SpaSetpoint = "103"
        };

        static ViewModels.MainViewModel _mainViewModel;

        public static ViewModels.MainViewModel MainViewModel => _mainViewModel ?? (_mainViewModel =  Application.Current == null ? new ViewModels.MainViewModel(_poolSampleData) : new ViewModels.MainViewModel());
    }
}
