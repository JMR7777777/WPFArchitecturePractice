using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WPFArchitecturePractice.BLL.Service.Rent;
using WPFArchitecturePractice.DAL;
using WPFArchitecturePractice.DAL.DataAccess.Rent;
using WPFArchitecturePractice.UI.ViewModels;
using WPFArchitecturePractice.UI.Views;

namespace WPFArchitecturePractice.UI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        Services = ConfigureServices();
        this.InitializeComponent();
    }

    public new static App Current => (App)Application.Current;

    public IServiceProvider Services { get; }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Views和ViewModel
        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainWindowViewModel>();

        services.AddSingleton<FindBooksViewModel>();
        services.AddSingleton<FindRentersViewModel>();
        services.AddSingleton<RentRecordsViewModel>();
        services.AddSingleton<RibbonViewModel>();


        // 注册 DbContext 服务
        services.AddDbContext<WPFArchitecturePraticeContext>();

        //注册 DAL层 的服务
        services.AddScoped<IBookDataAccess, BookDataAccess>();

        //注册 BLL层 的服务
        services.AddScoped<IBookService, BookService>();

        return services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var MainWindow = Services.GetRequiredService<MainWindow>();
        MainWindow.Show();
    }
}
