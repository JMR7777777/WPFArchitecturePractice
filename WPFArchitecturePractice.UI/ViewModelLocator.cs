using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using WPFArchitecturePractice.UI.ViewModels;

namespace WPFArchitecturePractice.UI
{
    // ViewModelLocator 用来配置所有的 View 和它们的 ViewModel
    public class ViewModelLocator
    {
        private static IServiceProvider _serviceProvider;
        public static void SetServiceProvider(IServiceProvider provider) { _serviceProvider = provider; }
        public static IServiceProvider GetServiceProvider() { return _serviceProvider; }

        // 注册所有的 ViewModel， 便于让每个 view 在 xaml 里面去绑定自己对应的 ViewModel
        public static void RegisterViewModels(ref IServiceCollection serviceCollection)
        {
            // Views和ViewModel
            serviceCollection.AddSingleton<MainWindow>();
            serviceCollection.AddSingleton<MainWindowViewModel>();

            serviceCollection.AddSingleton<FindBooksViewModel>();
            serviceCollection.AddSingleton<FindRentersViewModel>();
            serviceCollection.AddSingleton<RentRecordsViewModel>();
            serviceCollection.AddSingleton<RibbonViewModel>();
        }

        // ViewModelLocator 将被用作资源从而实现 xaml 里面的 datacontext 绑定。 使用 GetRequiredService 方法把全部的ViewModel给拿到，让它们被作为资源管理。
        public MainWindow MainWindow => _serviceProvider.GetRequiredService<MainWindow>();
        public MainWindowViewModel MainWindowViewModel => _serviceProvider.GetRequiredService<MainWindowViewModel>();
        public FindBooksViewModel FindBooksViewModel => _serviceProvider.GetRequiredService<FindBooksViewModel>();

        public FindRentersViewModel FindRentersViewModel => _serviceProvider.GetRequiredService<FindRentersViewModel>();
        public RentRecordsViewModel RentRecordsViewModel => _serviceProvider.GetRequiredService<RentRecordsViewModel>();
        public RibbonViewModel RibbonViewModel => _serviceProvider.GetRequiredService<RibbonViewModel>();
    }

}
