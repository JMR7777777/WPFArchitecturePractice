using CommunityToolkit.Mvvm.Messaging.Messages;

namespace WPFArchitecturePractice.UI.Messages
{
    internal class TestRequestMessage : RequestMessage<string>
    {
        public string? FieldName;

        public TestRequestMessage(string? fieldName)
        {
            FieldName = fieldName;
        }
    }


}
