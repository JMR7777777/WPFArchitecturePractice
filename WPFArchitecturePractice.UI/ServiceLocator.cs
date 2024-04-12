using Microsoft.Extensions.DependencyInjection;
using System;
using WPFArchitecturePractice.BLL.Service.Rent;
using WPFArchitecturePractice.DAL;
using WPFArchitecturePractice.DAL.DataAccess.Rent;

namespace WPFArchitecturePractice.UI
{
    // 这里的 ServiceLocator 不同于广泛定义的 服务定位模式 的设计模式，而是相对于 ViewModelLocator 的一个用于区分 ViewModel 依赖注入注册和 Service 依赖注入注册的用来逻辑拆分模块的类。
    // 因此，禁止在需要调用服务的时候使用 ServiceLocator.GetService<>() 的方式调用服务。为保证依赖注入的思想， App.current.Service.GetService<>()来获取服务也应该被禁止。 
    public class ServiceLocator
    {
        // _serviceProvider 目前没有被用到，因为使用 ServiceLocator 来调用服务是被禁止的
        private static IServiceProvider _serviceProvider;
        public static void SetServiceProvider(IServiceProvider serviceProvider) { _serviceProvider = serviceProvider; }
        public static IServiceProvider GetServiceProvider() { return _serviceProvider; }

        // 在这里面注册各种 service， 如果后面服务较多，可以把 DAL层 的服务和 BLL层 的服务拆分到两个函数里面
        public static void RegisterServices(ref IServiceCollection serviceCollection)
        {
            // 注册 DbContext 服务
            serviceCollection.AddDbContext<WPFArchitecturePraticeContext>();
            //注册 DAL层 的服务
            serviceCollection.AddScoped<IBookDataAccess, BookDataAccess>();
            //注册 BLL层 的服务
            serviceCollection.AddScoped<IBookService, BookService>();
        }
    }
}
