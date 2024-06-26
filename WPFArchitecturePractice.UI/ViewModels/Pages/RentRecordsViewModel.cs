﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using WPFArchitecturePractice.UI.Config;
using WPFArchitecturePractice.UI.Messages;

namespace WPFArchitecturePractice.UI.ViewModels
{
    public partial class RentRecordsViewModel : ObservableObject
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
            WeakReferenceMessenger.Default.Send(new ChangePageMessage(ViewPathMapper.FindRentersPage));
        }

        [RelayCommand]
        public void SearchBookId()
        {
            WeakReferenceMessenger.Default.Send(new ChangePageMessage(ViewPathMapper.FindBooksPage));
        }

        [RelayCommand]
        public void RentConfirm()
        {
        }

    }
}
