using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows;
using System;
using WPFArchitecturePractice.UI.Config;
using WPFArchitecturePractice.UI.Messages;
using System.Collections.Generic;
using System.Linq;

namespace WPFArchitecturePractice.UI.ViewModels
{
    public partial class RibbonViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? pagePath;

        private string selectedLanguage = "CN";


        [RelayCommand]
        void RentRecordsClicked()
        {
            PagePath = ViewPathMapper.RentRecordsPage;
            WeakReferenceMessenger.Default.Send(new ChangePageMessage(PagePath));
        }

        [RelayCommand]
        void FindBooksClicked()
        {
            PagePath = ViewPathMapper.FindBooksPage;
            WeakReferenceMessenger.Default.Send(new ChangePageMessage(PagePath));
        }


        [RelayCommand]
        void FindRentersClicked()
        {
            PagePath = ViewPathMapper.FindRentersPage;
            WeakReferenceMessenger.Default.Send(new ChangePageMessage(PagePath));
        }

        //todo 点击切换语言后更改app.xaml里面的语言资源文件内容
        private void ChangeUILanguage(string targetLanguage)
        {
            List<ResourceDictionary> dictionaryList = new List<ResourceDictionary>();
            foreach (ResourceDictionary dictionary in Application.Current.Resources.MergedDictionaries)
            {
                dictionaryList.Add(dictionary);
            }

            string requestedCulture = @"Resources\Languages\" + targetLanguage + ".xaml";
            var resourceDictionary = dictionaryList.FirstOrDefault(d => d.Source.OriginalString.Equals(requestedCulture));

            if (resourceDictionary != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(resourceDictionary);
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
            }
            else
            {
                MessageBox.Show("Can not load the language resources.");
                return;
            }
        }

        [RelayCommand]
        void GlobalLanguageChoosed()
        {

        }
    }

}
