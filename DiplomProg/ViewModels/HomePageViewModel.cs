using DiplomProg.Services;
using DiplomProg.ViewModels;

namespace DiplomProg.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public string Test { get; } = "Home";

        public HomePageViewModel(IDataService dataService) : base(dataService)
        {
        }
    }
}