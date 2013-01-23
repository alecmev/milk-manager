using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace NotEdible
{
    public partial class SettingsPage : PhoneApplicationPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            //this.DataContext = App.DataBaseViewModel;
        }

        private void SaveClick(object sender, EventArgs e)
        {
            //App.SettingsViewModel.LearningLanguage = App.DataBaseViewModel.Languages[LearningLanguage.SelectedIndex];
            //App.SettingsViewModel.TranslationLanguage = App.DataBaseViewModel.Languages[TranslationLanguage.SelectedIndex];
            //App.SettingsViewModel.InterfaceLanguage = App.DataBaseViewModel.Languages[InterfaceLanguage.SelectedIndex];
            NavigationService.GoBack();
        }

        private void CancelClick(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ListPickerLoaded(object sender, RoutedEventArgs e)
        {
            //ListPicker listPicker = ((ListPicker)sender);
            //if (listPicker.Tag == null)
            //{
            //    listPicker.Tag = true;
            //    Binding bind = new Binding((string)listPicker.Name);
            //    bind.Source = App.SettingsViewModel;
            //    bind.Converter = new LanguageListPickerConverter();
            //    bind.Mode = BindingMode.OneWay;
            //    listPicker.SetBinding(ListPicker.SelectedIndexProperty, bind);
            //}
        }
    }

    public class Languages : ObservableCollection<string>
    {
        public Languages()
        {
            foreach (string language in new string[] { "English", "Russian", "Latvian" })
                Add(language);
        }
    }
}