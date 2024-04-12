using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace WPFArchitecturePractice.UI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public new static App Current => (App)Application.Current;

    public IServiceProvider Services { get; }

    public App()
    {
        Services = ConfigureServices();
        this.InitializeComponent();
    }

    private static IServiceProvider ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        // 分别注册 ViewModel 和 服务
        ServiceLocator.RegisterServices(ref services);
        ViewModelLocator.RegisterViewModels(ref services);

        IServiceProvider serviceProvider = services.BuildServiceProvider();

        ServiceLocator.SetServiceProvider(serviceProvider);
        ViewModelLocator.SetServiceProvider(serviceProvider);

        return serviceProvider;
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var MainWindow = Services.GetRequiredService<MainWindow>();
        MainWindow.Show();
    }
}
