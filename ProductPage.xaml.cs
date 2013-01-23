using System;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace NotEdible
{
    public partial class ProductPage : PhoneApplicationPage
    {
        public ProductPage()
        {
            InitializeComponent();

            //this.DataContext = App.DataBaseViewModel;

            Loaded += ProductPage_Loaded;
        }

        void ProductPage_Loaded(object sender, RoutedEventArgs e)
        {
            ProductName.Focus();
            ProductName.SelectionStart = ProductName.Name.Length;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ProductName.Text = MainPage.Instance.CurrentProduct.Name;
            base.OnNavigatedTo(e);
        }

        private void SaveClick(object sender, EventArgs e)
        {
            //App.SettingsViewModel.LearningLanguage = App.DataBaseViewModel.Languages[LearningLanguage.SelectedIndex];
            //App.SettingsViewModel.TranslationLanguage = App.DataBaseViewModel.Languages[TranslationLanguage.SelectedIndex];
            //App.SettingsViewModel.InterfaceLanguage = App.DataBaseViewModel.Languages[InterfaceLanguage.SelectedIndex];
            MainPage.Instance.CurrentProduct.Name = ProductName.Text;
            MainPage.Instance.Dispatcher.BeginInvoke(new EventHandler(MainPage.Instance.UpdateProduct), new object[] { MainPage.Instance.CurrentProduct, e });
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
}