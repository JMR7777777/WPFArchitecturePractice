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
    partial class RentRecordsViewModel:ObservableObject
    {
        [ObservableProperty]
        private string? renterId;

        [ObservableProperty]
        private string? bookId;

        [ObservableProperty]
        private string? latestReturnDate;

        [ObservableProperty]
        private int? longestRenturnDay;

        [RelayCommand]
        public void SearchRenterId()
        {
            WeakReferenceMessenger.Default.Send(new ChangePageMessage("Views\\FindRentersPage.xaml"));
        }

        [RelayCommand]
        public void SearchBookId()
        {
            WeakReferenceMessenger.Default.Send(new ChangePageMessage("Views\\FindBooksPage.xaml"));
        }

        [RelayCommand]
        public void RentConfirm()
        {
        }
        
    }
}
