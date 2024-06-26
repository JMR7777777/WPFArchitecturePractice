﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using WPFArchitecturePractice.UI.Messages;

namespace WPFArchitecturePractice.UI.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject, IRecipient<ChangePageMessage>
    {
        [ObservableProperty]
        private string? pagePath;

        public MainWindowViewModel()
        {

            WeakReferenceMessenger.Default.Register<ChangePageMessage>(this);
            //WeakReferenceMessenger.Default.Register<ChangePageMessage>(this, (r, m) =>{});
        }

        public void Receive(ChangePageMessage message)
        {
            try
            {
                PagePath = message.Value;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

    }
}
