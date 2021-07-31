using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace nxchange.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            ButtonName = "BUTOOOOON";
        }

        public string ButtonName { get; set; }
    }
}