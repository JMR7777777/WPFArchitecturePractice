using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFArchitecturePractice.UI.Messages;

namespace WPFArchitecturePractice.UI.ViewModels
{
    partial class MainWindowViewModel : ObservableObject, IRecipient<ChangePageMessage>
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
