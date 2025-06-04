using DiplomProg.Models;
using DiplomProg.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System;

namespace DiplomProg.ViewModels
{
    public partial class EmployeesPageViewModel : ViewModelBase
    {
        private const string EmployeesFile = "employees.json";

        [ObservableProperty]
        private ObservableCollection<Employee> _employees = new();

        [ObservableProperty]
        private Employee? _selectedEmployee;

        public EmployeesPageViewModel(IDataService storage) : base(storage)
        {
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            Employees = new ObservableCollection<Employee>(
                DataService.LoadData<Employee>(EmployeesFile)
            );
        }

        [RelayCommand]
        private void AddEmployee()
        {
            var newEmployee = new Employee
            {
                FullName = "Новый сотрудник",
                Position = "Техник",
                Phone = "+7 (999) 000-00-00"
            };

            Employees.Add(newEmployee);
            SaveEmployees();
        }

        [RelayCommand]
        private void DeleteEmployee()
        {
            if (SelectedEmployee != null)
            {
                Employees.Remove(SelectedEmployee);
                SaveEmployees();
            }
        }

        private void SaveEmployees()
        {
            DataService.SaveData(Employees, EmployeesFile);
        }
    }
}