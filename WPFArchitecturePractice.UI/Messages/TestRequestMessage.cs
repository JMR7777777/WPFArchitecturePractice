using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFArchitecturePractice.UI.Messages
{
    internal class TestRequestMessage: RequestMessage<string>
    {
        public string? FieldName;

        public TestRequestMessage(string? fieldName)
        {
            FieldName = fieldName;
        }
    }


}
