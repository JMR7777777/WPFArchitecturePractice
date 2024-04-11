using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;
using WPFArchitecturePractice.UI.ViewModels;

namespace WPFArchitecturePractice.UI.Views
{
    /// <summary>
    /// FindBooksPage.xaml 的交互逻辑
    /// </summary>
    public partial class FindBooksPage : UserControl
    {
        public FindBooksPage()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService<FindBooksViewModel>();
        }
    }
}
