using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Diagnostics;
using WPFArchitecturePractice.UI.Config;
using WPFArchitecturePractice.UI.Messages;

namespace WPFArchitecturePractice.UI.ViewModels
{
    public partial class FindRentersViewModel : ObservableObject
    {
        [RelayCommand]
        public void SetAsCurrentRenter()
        {
            WeakReferenceMessenger.Default.Send(new ChangePageMessage(ViewPathMapper.RentRecordsPage));
        }
        [RelayCommand]
        public void SearchRenters()
        {
            Debug.WriteLine("Test!!!!!!!!");
        }
    }
}
