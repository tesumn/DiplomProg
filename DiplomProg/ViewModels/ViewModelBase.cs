using CommunityToolkit.Mvvm.ComponentModel;
using DiplomProg.Services;
using DiplomProg.Views;

namespace DiplomProg.ViewModels
{
    public partial class ViewModelBase : ObservableObject
    {
        protected readonly IDataService DataService;

        protected ViewModelBase(IDataService dataService)
        {
            DataService = dataService;
        }

        protected async void ShowError(string message)
        {
            var dialog = new ErrorDialog(message);
            if (App.MainWindow != null)
                await dialog.ShowDialog(App.MainWindow);
        }
    }
}