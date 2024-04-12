using CommunityToolkit.Mvvm.Messaging.Messages;

namespace WPFArchitecturePractice.UI.Messages
{
    public class ChangePageMessage : ValueChangedMessage<string?>
    {
        public ChangePageMessage(string? pagePath) : base(pagePath)
        {
        }
    }
}
