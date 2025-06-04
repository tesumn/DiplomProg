using Avalonia.Controls;
using Avalonia.Input;
using DiplomProg.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace DiplomProg.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = App.ServiceProvider?.GetRequiredService<MainWindowViewModel>();
        }

        private void Image_PointerPressed(object? sender, PointerPressedEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                (DataContext as MainWindowViewModel)?.SideMenuResizeCommand?.Execute(null);
            }
        }
    }
}