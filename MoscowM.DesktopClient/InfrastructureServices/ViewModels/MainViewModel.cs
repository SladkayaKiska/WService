using MoscowM.ApplicationServices.GetInOutMetroListUseCase;
using MoscowM.ApplicationServices.Ports;
using MoscowM.DomainObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MoscowM.DesktopClient.InfrastructureServices.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IGetInOutMetroListUseCase _getInOutMetroListUseCase;

        public MainViewModel(IGetInOutMetroListUseCase getInOutMetroListUseCase)
            => _getInOutMetroListUseCase = getInOutMetroListUseCase;

        private Task<bool> _loadingTask;
        private InOutMetro _currentInOutMetro;
        private ObservableCollection<InOutMetro> _inoutmetros;

        public event PropertyChangedEventHandler PropertyChanged;

        public InOutMetro CurrentInOutMetro
        {
            get => _currentInOutMetro; 
            set
            {
                if (_currentInOutMetro != value)
                {
                    _currentInOutMetro = value;
                    OnPropertyChanged(nameof(CurrentInOutMetro));
                }
            }
        }

        private async Task<bool> LoadInOutMetros()
        {
            var outputPort = new OutputPort();
            bool result = await _getInOutMetroListUseCase.Handle(GetInOutMetroListUseCaseRequest.CreateAllInOutMetrosRequest(), outputPort);
            if (result)
            {
                InOutMetros = new ObservableCollection<InOutMetro>(outputPort.InOutMetros);
            }
            return result;
        }

        public ObservableCollection<InOutMetro> InOutMetros
        {
            get 
            {
                if (_loadingTask == null)
                {
                    _loadingTask = LoadInOutMetros();
                }
                
                return _inoutmetros; 
            }
            set
            {
                if (_inoutmetros != value)
                {
                    _inoutmetros = value;
                    OnPropertyChanged(nameof(InOutMetros));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private class OutputPort : IOutputPort<GetInOutMetroListUseCaseResponse>
        {
            public IEnumerable<InOutMetro> InOutMetros { get; private set; }

            public void Handle(GetInOutMetroListUseCaseResponse response)
            {
                if (response.Success)
                {
                    InOutMetros = new ObservableCollection<InOutMetro>(response.InOutMetros);
                }
            }
        }
    }
}
