using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using WPFArchitecturePractice.UI.ViewModels;
using WPFArchitecturePractice.UI.Views;

namespace WPFArchitecturePractice.UI
{
    // ViewModelLocator 用来配置所有的 View 和它们的 ViewModel
    public class ViewModelLocator
    {
        public ViewModelLocator() { 
        //config viewModels here
        }

        public MainWindowViewModel MainWindowViewModel => App.Current.Services.GetRequiredService<MainWindowViewModel>();
        public FindBooksViewModel FindBooksViewModel => App.Current.Services.GetRequiredService<FindBooksViewModel>();

        public FindRentersViewModel FindRentersViewModel => App.Current.Services.GetRequiredService<FindRentersViewModel>();
        public RentRecordsViewModel RentRecordsViewModel => App.Current.Services.GetRequiredService<RentRecordsViewModel>();
        public RibbonViewModel RibbonViewModel => App.Current.Services.GetRequiredService<RibbonViewModel>();
    }

}
