using LagoVista.PoolController.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.PoolController.Models
{
    public class Pool : INotifyPropertyChanged
    {
        PoolService _service;

        public event PropertyChangedEventHandler PropertyChanged;

        public Pool(PoolService service)
        {
            _service = service;
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            //TODO: Should be a design time check and not run this.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private String _mode;
        public String Mode
        {
            get { return _mode;  }
            set { _mode = value; RaisePropertyChanged(); }
        }

        private String _lowPressureStatus;
        public String LowPressureStatus
        {
            get { return _lowPressureStatus; }
            set { _lowPressureStatus = value; RaisePropertyChanged(); }
        }

        private String _hightPressureStatus;
        public String HighPressureStatus
        {
            get { return _hightPressureStatus; }
            set { _hightPressureStatus = value; RaisePropertyChanged(); }
        }

        private String _flowStatus;
        public String FlowStatus
        {
            get { return _flowStatus; }
            set { _flowStatus = value; RaisePropertyChanged(); }
        }

        private String _spaSeppoint;
        public String SpaSetpoint
        {
            get { return _spaSeppoint; }
            set { _spaSeppoint = value; RaisePropertyChanged(); }
        }

        private String _poolSetpoint;
        public String PoolSetpoint
        {
            get { return _poolSetpoint; }
            set { _poolSetpoint = value; RaisePropertyChanged(); }
        }

        private String _source;
        public String Source
        {
            get { return _source; }
            set { _source = value; RaisePropertyChanged(); }
        }

        private String _spaMode;
        public String SpaMode
        {
            get { return _spaMode; }
            set { _spaMode = value; RaisePropertyChanged(); }
        }

        private String _output;
        public String Output
        {
            get { return _output; }
            set { _output = value; RaisePropertyChanged(); }
        }

        private String _temperature;
        public String Temperature
        {
            get { return _temperature; }
            set { _temperature = value;  RaisePropertyChanged(); }
        }

        public async Task<bool> RefreshAsync()
        {
            Output = await _service.GetOutputAsync();
            SpaMode = await _service.GetSpaModeAsync();
            Source = await _service.GetSourceAsync();
            PoolSetpoint = await _service.GetPoolSetpointAsync();
            SpaSetpoint = await _service.GetSpaSetpointAsync();
            FlowStatus = await _service.GetFlowAsync();
            HighPressureStatus = await _service.GetHighPressureAsync();
            LowPressureStatus = await _service.GetLowerPressureAsync();
            Mode = await _service.GetModeAsync();
            Temperature = await _service.GetTemperatureAsync();

            return true;
        }
    }
}
