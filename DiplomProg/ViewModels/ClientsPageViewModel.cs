using DiplomProg.Models;
using DiplomProg.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System;

namespace DiplomProg.ViewModels
{
    public partial class ClientsPageViewModel : ViewModelBase
    {
        private const string ClientsFile = "clients.json";

        [ObservableProperty]
        private ObservableCollection<Client> _clients = new();

        [ObservableProperty]
        private Client? _selectedClient;

        public ClientsPageViewModel(IDataService storage) : base(storage)
        {
            LoadClients();
        }

        private void LoadClients()
        {
            Clients = new ObservableCollection<Client>(
                DataService.LoadData<Client>(ClientsFile)
            );
        }

        [RelayCommand]
        private void AddClient()
        {
            var newClient = new Client
            {
                FullName = "Новый клиент",
                Email = $"client_{Guid.NewGuid().ToString("N")[..8]}@example.com",
                Phone = "+7 (999) 000-00-00"
            };

            Clients.Add(newClient);
            SaveClients();
        }

        [RelayCommand]
        private void DeleteClient()
        {
            if (SelectedClient != null)
            {
                Clients.Remove(SelectedClient);
                SaveClients();
            }
        }

        private void SaveClients()
        {
            DataService.SaveData(Clients, ClientsFile);
        }
    }
}