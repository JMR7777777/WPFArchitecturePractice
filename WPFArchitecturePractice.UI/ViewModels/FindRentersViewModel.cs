using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFArchitecturePractice.UI.Messages;

namespace WPFArchitecturePractice.UI.ViewModels
{
    partial class FindRentersViewModel: ObservableObject
    {
        [RelayCommand]
        public void SetAsCurrentRenter()
        {
            WeakReferenceMessenger.Default.Send(new ChangePageMessage("Views\\RentRecordsPage.xaml"));
        }
    }
}
