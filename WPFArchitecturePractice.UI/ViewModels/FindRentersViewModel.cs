using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Diagnostics;
using WPFArchitecturePractice.UI.Messages;

namespace WPFArchitecturePractice.UI.ViewModels
{
    partial class FindRentersViewModel : ObservableObject
    {
        [RelayCommand]
        public void SetAsCurrentRenter()
        {
            WeakReferenceMessenger.Default.Send(new ChangePageMessage("Views\\RentRecordsPage.xaml"));
        }
        [RelayCommand]
        public void SearchRenters()
        {
            Debug.WriteLine("Test!!!!!!!!");
        }
    }
}
