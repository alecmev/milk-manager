using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace NotEdible
{
    public partial class CaptionControl : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(CaptionControl), null);
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set
            {
                if (value != Text)
                {
                    SetValue(TextProperty, value);
                    NotifyPropertyChanged("Text");
                }
            }
        }

        public CaptionControl()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
