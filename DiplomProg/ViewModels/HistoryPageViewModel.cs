using DiplomProg.Services;
using DiplomProg.ViewModels;

namespace DiplomProg.ViewModels
{
    public class HistoryPageViewModel : ViewModelBase
    {
        public string Test { get; } = "History";

        public HistoryPageViewModel(IDataService dataService) : base(dataService)
        {
        }
    }
}