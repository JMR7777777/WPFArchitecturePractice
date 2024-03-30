using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFArchitecturePractice.UI.Messages
{
    public class ChangePageMessage : ValueChangedMessage<string?>
    {
        public ChangePageMessage(string? pagePath) : base(pagePath)
        {
        }
    }
}
