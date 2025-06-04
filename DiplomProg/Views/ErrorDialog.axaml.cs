using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;

namespace DiplomProg.Views
{
    public partial class ErrorDialog : Window
    {
        public string ErrorMessage { get; }
        public IRelayCommand CloseCommand { get; }

        public ErrorDialog(string message)
        {
            InitializeComponent();
            ErrorMessage = message;
            CloseCommand = new RelayCommand(Close);
            DataContext = this;
        }
    }
}