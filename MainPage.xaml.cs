using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Controls.Primitives;
using Microsoft.Phone.Shell;

namespace NotEdible
{
    public partial class MainPage : PhoneApplicationPage
    {
        public static MainPage Instance;

        private bool _searchLastFocused = false;
        public Product CurrentProduct;

        public MainPage()
        {
            InitializeComponent();

            Instance = this;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Product product = (sender as Button).DataContext as Product;
            product.IsChecked = !product.IsChecked;

            UpdateApplicationBar();

            //if (_searchLastFocused)
            //    SearchBar.Focus();
        }

        private void UpdateApplicationBar()
        {
            bool binChecked = (from x in (Resources["Products"] as Products) where x.IsChecked && x.InStock select x).Count() > 0;
            bool buyChecked = (from x in (Resources["Products"] as Products) where x.IsChecked && !x.InStock select x).Count() > 0;

            (ApplicationBar.Buttons[0] as ApplicationBarIconButton).IsEnabled = binChecked;
            (ApplicationBar.Buttons[1] as ApplicationBarIconButton).IsEnabled = buyChecked;
        }

        private void Rectangle_Loaded_1(object sender, RoutedEventArgs e)
        {
            //HSBColor tmpHSB = HSBColor.FromRGB((App.Current.Resources["PhoneAccentBrush"] as SolidColorBrush).Color);
            //tmpHSB.B /= 4;
            //(sender as Rectangle).Fill = new SolidColorBrush(tmpHSB.ToRGB());
        }

        private void TextBox_GotFocus_1(object sender, RoutedEventArgs e)
        {
            TextBox senderTextBox = sender as TextBox;

            if (senderTextBox.Tag == null)
            {
                senderTextBox.Tag = senderTextBox.Text;
                senderTextBox.Text = "";
                senderTextBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void TextBox_LostFocus_1(object sender, RoutedEventArgs e)
        {
            TextBox senderTextBox = sender as TextBox;

            if (senderTextBox.Text.Trim() == "")
            {
                senderTextBox.Text = senderTextBox.Tag as string;
                senderTextBox.Tag = null;
                senderTextBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            TextBox senderTextBox = sender as TextBox;
            String customizedText = senderTextBox.Text.TrimStart().ToLower();

            if (senderTextBox.Text != customizedText)
            {
                senderTextBox.Text = customizedText;
                return;
            }

            String text = senderTextBox.Text.TrimEnd();

            if (senderTextBox.Tag == null)
                text = "";

            AddButton.IsEnabled = (text != "");
            SearchButton.IsHitTestVisible = AddButton.IsEnabled;

            if (SearchButton.IsHitTestVisible)
                SearchButtonImageBrush.ImageSource = new BitmapImage(new Uri(@"/NotEdible;component/Assets/Icons/Black/cancel.png", UriKind.Relative));
            else
                SearchButtonImageBrush.ImageSource = new BitmapImage(new Uri(@"/NotEdible;component/Assets/Icons/White/feature.search.png", UriKind.Relative));

            Products products = Resources["Products"] as Products;

            var positive = from x in products where x.Name.Contains(text) select x;
            var negative = from x in products where !x.Name.Contains(text) select x;

            foreach (Product product in positive)
                product.Visibility = System.Windows.Visibility.Visible;

            foreach (Product product in negative)
                product.Visibility = System.Windows.Visibility.Collapsed;

            (Resources["Products"] as Products).UpdateItemPositions();
        }

        private void AddButton_IsEnabledChanged_1(object sender, DependencyPropertyChangedEventArgs e)
        {
            Rectangle senderRectangle = (sender as Button).Content as Rectangle;

            if ((bool)e.NewValue == true)
                senderRectangle.Fill = new SolidColorBrush(Colors.White);
            else
                senderRectangle.Fill = new SolidColorBrush(Colors.Gray);
        }

        private void AddButton_Click_1(object sender, RoutedEventArgs e)
        {
            ProductListBox.ScrollIntoView((Resources["Products"] as Products).Add(new Product() { Name = SearchBar.Text.TrimEnd(), ExpirationDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) + TimeSpan.FromDays(5) }));
            SearchBar.Text = "";
            SearchBar.Focus();
            AddButton.Focus();
        }

        private void SearchButton_Click_1(object sender, RoutedEventArgs e)
        {
            SearchBar.Text = "";
            SearchBar.Focus();
        }

        private void LayoutRoot_LostFocus_1(object sender, RoutedEventArgs e)
        {
            _searchLastFocused = e.OriginalSource.Equals(SearchBar);
        }

        private Product _currentProduct = null;

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            _currentProduct = ((sender as Button).DataContext as Product);
            GlobalDatePicker.Value = _currentProduct.ExpirationDate;
            GlobalDatePicker.Header = "EXPIRATION DATE FOR " + _currentProduct.Name.ToUpper();
            GlobalDatePicker.Click();
        }

        void GlobalDatePicker_ValueChanged(object sender, DateTimeValueChangedEventArgs e)
        {
            _currentProduct.ExpirationDate = e.NewDateTime.Value;
        }

        private void SearchBar_KeyUp_1(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
                AddButton_Click_1(sender, null);
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri(@"/SettingsPage.xaml", UriKind.Relative));
        }

        private void BinChecked(object sender, EventArgs e)
        {
            foreach (Product product in new List<Product>(from x in (Resources["Products"] as Products) where x.IsChecked && x.InStock select x))
            {
                product.IsChecked = false;
                product.InStock = false;
                (Resources["Products"] as Products).UpdateProduct(product);
                ProductListBox.ScrollIntoView(product);
            }

            UpdateApplicationBar();
        }

        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new EventHandler(BinChecked), new object[] { sender, e });
        }

        private void BuyChecked(object sender, EventArgs e)
        {
            foreach (Product product in new List<Product>(from x in (Resources["Products"] as Products) where x.IsChecked && !x.InStock select x))
            {
                product.IsChecked = false;
                product.InStock = true;
                (Resources["Products"] as Products).UpdateProduct(product);
                ProductListBox.ScrollIntoView(product);
            }

            UpdateApplicationBar();
        }

        private void ApplicationBarIconButton_Click_3(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new EventHandler(BuyChecked), new object[] { sender, e });
        }

        private void Grid_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            CurrentProduct = (sender as Grid).DataContext as Product;
            NavigationService.Navigate(new Uri(@"/ProductPage.xaml", UriKind.Relative));
        }

        public void UpdateProduct(object sender, EventArgs e)
        {
            (Resources["Products"] as Products).UpdateProduct(sender as Product);
        }
    }

    public class Product : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { UpdateProperty(ref _name, ref value, "Name"); }
        }

        private DateTime _expirationDate;
        public DateTime ExpirationDate
        {
            get { return _expirationDate; }
            set { UpdateProperty(ref _expirationDate, ref value, "ExpirationDate"); }
        }
        public bool InStock
        {
            get { return ExpirationDate != DateTime.MinValue; }
            set
            {
                if (InStock != value)
                {
                    if (value)
                        ExpirationDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) + TimeSpan.FromDays(5);
                    else
                        ExpirationDate = DateTime.MinValue;

                    PropertyChanged(this, new PropertyChangedEventArgs("InStock"));
                }
            }
        }

        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set { UpdateProperty(ref _isChecked, ref value, "IsChecked"); }
        }

        private ItemPosition _position;
        public ItemPosition Position
        {
            get { return _position; }
            set { UpdateProperty(ref _position, ref value, "Position"); }
        }

        private Visibility _visibility;
        public Visibility Visibility
        {
            get { return _visibility; }
            set
            {
                UpdateProperty(ref _visibility, ref value, "Visibility");

                if (value == System.Windows.Visibility.Visible)
                    Position &= ~ItemPosition.Collapsed;
                else
                    Position |= ItemPosition.Collapsed;
            }
        }

        public Product()
        {
            _visibility = System.Windows.Visibility.Visible;
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void UpdateProperty<T>(ref T property, ref T value, string propertyName)
        {
            if (property == null || !property.Equals(value))
            {
                property = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        } 
        #endregion
    }

    public class CaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (parameter as string)
            {
                case "upper":
                    return (value as string).ToUpper();
                default:
                    return (value as string).ToLower();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class Products : ObservableCollection<Product>
    {
        public Products()
        {
            CollectionChanged += ProductsCollectionChanged;

            Random rnd = new Random();

            foreach (string name in new string[] { "carrots", "apples", "milk", "sweet pepper", "eggs", "sour cream", "ketchup", "bacon", "meat balls" })
                Add(new Product() { Name = name, ExpirationDate = new DateTime(2012, rnd.Next(11, 13), rnd.Next(1, 31)) });
        }

        public new Product Add(Product product)
        {
            Insert(GetTargetIndex(product), product);
            return product;
        }

        public void UpdateProduct(Product product)
        {
            Remove(product);
            Add(product);
        }

        private int GetTargetIndex(Product product)
        {
            int targetIndex = Count;
            int i = 0;

            for (i = 0; i < Count; ++i)
                if (!this[i].InStock)
                    break;

            if (product.InStock)
            {
                targetIndex = i;
                i = 0;
            }

            for (; i < targetIndex; ++i)
                if (product.Name.CompareTo(this[i].Name) < 0)
                {
                    targetIndex = i;
                    break;
                }

            return targetIndex;
        }

        private void ProductsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateItemPositions();
        }

        public void UpdateItemPositions()
        {
            ItemPosition clean = ~ItemPosition.First & ~ItemPosition.Last;

            Product first = null, last = null;

            foreach (Product tmpProduct in this)
            {
                tmpProduct.Position &= clean;

                if (!tmpProduct.Position.HasFlag(ItemPosition.Collapsed))
                {
                    last = tmpProduct;

                    if (first == null)
                        first = tmpProduct;
                }
            }

            if (first == null)
                return;

            first.Position |= ItemPosition.First;
            last.Position |= ItemPosition.Last;
        }
    }

    [Flags]
    public enum ItemPosition
    {
        First = 0x1,
        Last = 0x2,
        Collapsed = 0x4
    }

    public class ListBoxItemPositionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ItemPosition position = (ItemPosition)value;

            Int32 verticalOffset = (Int32)Application.Current.Resources["ListBoxItemVerticalOffset"];
            Int32 leftOffset = (Int32)Application.Current.Resources["ListBoxItemLeftOffset"];
            Int32 rightOffset = (Int32)Application.Current.Resources["ListBoxItemRightOffset"];

            Thickness tmp = new Thickness(
                leftOffset, position.HasFlag(ItemPosition.Collapsed) ? 0 : position.HasFlag(ItemPosition.First) ? 0 : verticalOffset,
                rightOffset, position.HasFlag(ItemPosition.Collapsed) ? 0 : position.HasFlag(ItemPosition.Last) ? verticalOffset * 2 + 72 : verticalOffset);

            return tmp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class ProductIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime expirationDate = (DateTime)value;
            int daysLeft = (expirationDate - DateTime.Now).Days;
            string imagePath = "/Assets/Products/";

            if (expirationDate == DateTime.MinValue)
                imagePath += "shopping-cart";
            else if (daysLeft < 0)
                imagePath += "biohazard";
            else if (daysLeft < 3)
                imagePath += "warning";
            else
                imagePath += "thumbsup";

            return new BitmapImage(new Uri(imagePath + "-inverse-128.png", UriKind.Relative));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class InStockConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType == typeof(Visibility))
            {
                if ((bool)value)
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }
            else
            {
                if ((bool)value)
                    return new Thickness(12, -16, 0, 0);
                else
                    return new Thickness(12, 4, 0, 0);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class IsCheckedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType == typeof(Brush))
            {
                if ((bool)value)
                    return App.Current.Resources["PhoneAccentBrush"] as SolidColorBrush;
                else
                    return new SolidColorBrush(Colors.Transparent);
            }
            else
            {
                if ((bool)value)
                    return 1.0;
                else
                    return 0.5;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}