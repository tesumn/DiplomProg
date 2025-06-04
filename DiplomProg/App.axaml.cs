using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DiplomProg.Services;
using DiplomProg.ViewModels;
using DiplomProg.Views;
using Microsoft.Extensions.DependencyInjection;

namespace DiplomProg
{
    public partial class App : Application
    {
        public static IServiceProvider? ServiceProvider { get; private set; }
        public static Window? MainWindow { get; private set; }

        public override void Initialize() => AvaloniaXamlLoader.Load(this);

        public override void OnFrameworkInitializationCompleted()
        {
            // Создаем контейнер DI
            var services = new ServiceCollection();

            // Регистрируем сервисы
            services.AddSingleton<IDataService, FileStorageService>();

            // Регистрируем ViewModels
            services.AddSingleton<MainWindowViewModel>();
            services.AddTransient<HomePageViewModel>();
            services.AddTransient<ClientsPageViewModel>();
            services.AddTransient<EmployeesPageViewModel>();
            services.AddTransient<OrdersPageViewModel>();
            services.AddTransient<HistoryPageViewModel>();
            services.AddTransient<SettingsPageViewModel>();

            ServiceProvider = services.BuildServiceProvider();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                MainWindow = new MainWindow
                {
                    DataContext = ServiceProvider.GetRequiredService<MainWindowViewModel>()
                };
                desktop.MainWindow = MainWindow;
            }

            // Инициализация логгера
            LoggerService.InitializeLogger();

            base.OnFrameworkInitializationCompleted();
        }
    }
}