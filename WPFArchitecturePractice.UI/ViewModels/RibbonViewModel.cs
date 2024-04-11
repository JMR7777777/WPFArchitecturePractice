using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using WPFArchitecturePractice.UI.Messages;

namespace WPFArchitecturePractice.UI.ViewModels
{
    public partial class RibbonViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? pagePath;


        [RelayCommand]
        void RentRecordsClicked()
        {
            PagePath = "Views\\RentRecordsPage.xaml";
            WeakReferenceMessenger.Default.Send(new ChangePageMessage(PagePath));
        }

        [RelayCommand]
        void FindBooksClicked()
        {
            PagePath = "Views\\FindBooksPage.xaml";
            WeakReferenceMessenger.Default.Send(new ChangePageMessage(PagePath));
        }


        [RelayCommand]
        void FindRentersClicked()
        {
            PagePath = "Views\\FindRentersPage.xaml";
            WeakReferenceMessenger.Default.Send(new ChangePageMessage(PagePath));
        }
    }

}
