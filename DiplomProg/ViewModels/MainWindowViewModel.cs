using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiplomProg.Models;
using DiplomProg.Services;
using DiplomProg.ViewModels;
using System.Collections.Generic;

namespace DiplomProg.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SomeWidth))]
        private bool _sideMenu;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HomePageIsActive))]
        [NotifyPropertyChangedFor(nameof(ClientsPageIsActive))]
        [NotifyPropertyChangedFor(nameof(EmployeesPageIsActive))]
        [NotifyPropertyChangedFor(nameof(OrdersPageIsActive))]
        [NotifyPropertyChangedFor(nameof(HistoryPageIsActive))]
        [NotifyPropertyChangedFor(nameof(SettingsPageIsActive))]
        private ViewModelBase _currentPage;

        public bool HomePageIsActive => CurrentPage == _homePage;
        public bool ClientsPageIsActive => CurrentPage == _clientsPage;
        public bool EmployeesPageIsActive => CurrentPage == _employeesPage;
        public bool OrdersPageIsActive => CurrentPage == _ordersPage;
        public bool HistoryPageIsActive => CurrentPage == _historyPage;
        public bool SettingsPageIsActive => CurrentPage == _settingsPage;

        private readonly HomePageViewModel _homePage;
        private readonly ClientsPageViewModel _clientsPage;
        private readonly EmployeesPageViewModel _employeesPage;
        private readonly OrdersPageViewModel _ordersPage;
        private readonly HistoryPageViewModel _historyPage;
        private readonly SettingsPageViewModel _settingsPage;

        public MainWindowViewModel(
            IDataService dataService,
            HomePageViewModel homePage,
            ClientsPageViewModel clientsPage,
            EmployeesPageViewModel employeesPage,
            OrdersPageViewModel ordersPage,
            HistoryPageViewModel historyPage,
            SettingsPageViewModel settingsPage) : base(dataService)
        {
            _homePage = homePage;
            _clientsPage = clientsPage;
            _employeesPage = employeesPage;
            _ordersPage = ordersPage;
            _historyPage = historyPage;
            _settingsPage = settingsPage;

            CurrentPage = _homePage;
        }

        // Конструктор для дизайнера
        public MainWindowViewModel() : this(new DesignDataService(),
            new HomePageViewModel(new DesignDataService()),
            new ClientsPageViewModel(new DesignDataService()),
            new EmployeesPageViewModel(new DesignDataService()),
            new OrdersPageViewModel(new DesignDataService()),
            new HistoryPageViewModel(new DesignDataService()),
            new SettingsPageViewModel(new DesignDataService()))
        {
            SideMenu = true;
        }

        [RelayCommand]
        private void GoToHome() => CurrentPage = _homePage;

        [RelayCommand]
        private void GoToClients() => CurrentPage = _clientsPage;

        [RelayCommand]
        private void GoToEmployees() => CurrentPage = _employeesPage;

        [RelayCommand]
        private void GoToOrders() => CurrentPage = _ordersPage;

        [RelayCommand]
        private void GoToHistory() => CurrentPage = _historyPage;

        [RelayCommand]
        private void GoToSettings() => CurrentPage = _settingsPage;

        public int SomeWidth => SideMenu ? 163 : 64;

        [RelayCommand]
        private void SideMenuResize() => SideMenu = !SideMenu;
    }

    // Заглушка для дизайнера
    public class DesignDataService : IDataService
    {
        public void SaveData<T>(IEnumerable<T> data, string fileName) { }
        public List<T> LoadData<T>(string fileName) => new List<T>();
        public void LogAction(string action, string details) { }
        public List<LogEntry> LoadLogs() => new List<LogEntry>();
    }
}