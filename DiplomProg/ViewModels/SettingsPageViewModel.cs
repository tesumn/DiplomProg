using DiplomProg.Services;
using DiplomProg.ViewModels;

namespace DiplomProg.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        public string Test { get; } = "Welcome to settings page!";

        public SettingsPageViewModel(IDataService dataService) : base(dataService)
        {
        }
    }
}