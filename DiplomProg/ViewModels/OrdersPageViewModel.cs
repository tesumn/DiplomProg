using DiplomProg.Models;
using DiplomProg.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DiplomProg.ViewModels;

public partial class OrdersPageViewModel : ViewModelBase
{
    // Константы файлов
    private const string OrdersFile = "orders.json";
    private const string ClientsFile = "clients.json";
    private const string EmployeesFile = "employees.json";
    private const string ServicesFile = "services.json";

    // Коллекции данных
    [ObservableProperty] private ObservableCollection<Order> _orders = new();
    [ObservableProperty] private Order? _selectedOrder;
    [ObservableProperty] private ObservableCollection<Client> _clients = new();
    [ObservableProperty] private Client? _selectedClient;
    [ObservableProperty] private ObservableCollection<Employee> _employees = new();
    [ObservableProperty] private Employee? _selectedEmployee;
    [ObservableProperty] private ObservableCollection<Service> _services = new();
    [ObservableProperty] private Service? _selectedService;
    [ObservableProperty] private string _deviceType = "Компьютер";
    [ObservableProperty] private string _problemDescription = "";

    public OrdersPageViewModel(IDataService storage) : base(storage)
    {
        LoadAllData();
    }

    /// <summary>
    /// Загрузка всех необходимых данных
    /// </summary>
    private void LoadAllData()
    {
        Clients = new ObservableCollection<Client>(DataService.LoadData<Client>(ClientsFile));
        Employees = new ObservableCollection<Employee>(DataService.LoadData<Employee>(EmployeesFile));
        Services = new ObservableCollection<Service>(DataService.LoadData<Service>(ServicesFile));

        var orders = DataService.LoadData<Order>(OrdersFile);

        // Заполнение навигационных свойств
        foreach (var order in orders)
        {
            order.Client = Clients.FirstOrDefault(c => c.Id == order.ClientId);
            order.Employee = Employees.FirstOrDefault(e => e.Id == order.EmployeeId);
            order.Service = Services.FirstOrDefault(s => s.Id == order.ServiceId);
        }

        Orders = new ObservableCollection<Order>(orders);
    }

    /// <summary>
    /// Добавление нового заказа
    /// </summary>
    [RelayCommand]
    private void AddOrder()
    {
        // Валидация данных
        if (SelectedClient == null || SelectedEmployee == null || SelectedService == null)
        {
            ShowError("Выберите клиента, сотрудника и услугу");
            return;
        }

        if (string.IsNullOrWhiteSpace(DeviceType) || string.IsNullOrWhiteSpace(ProblemDescription))
        {
            ShowError("Заполните тип устройства и описание проблемы");
            return;
        }

        var newOrder = new Order
        {
            ClientId = SelectedClient.Id,
            ServiceId = SelectedService.Id,
            EmployeeId = SelectedEmployee.Id,
            DeviceType = DeviceType,
            ProblemDescription = ProblemDescription,
            // Установка навигационных свойств
            Client = SelectedClient,
            Employee = SelectedEmployee,
            Service = SelectedService
        };

        Orders.Add(newOrder);
        DataService.SaveData(Orders, OrdersFile);
        DataService.LogAction("Заказ создан", $"ID: {newOrder.Id}, Услуга: {SelectedService.Name}");

        // Сброс полей
        DeviceType = "Компьютер";
        ProblemDescription = "";
    }

    /// <summary>
    /// Сохранение изменений в заказе
    /// </summary>
    [RelayCommand]
    private void SaveOrderChanges(Order order)
    {
        if (order == null) return;

        // Обновляем ID перед сохранением
        order.ClientId = order.Client?.Id ?? 0;
        order.EmployeeId = order.Employee?.Id ?? 0;
        order.ServiceId = order.Service?.Id ?? 0;

        DataService.SaveData(Orders, OrdersFile);
        DataService.LogAction("Изменения сохранены", $"Заказ ID: {order.Id}");
    }
}