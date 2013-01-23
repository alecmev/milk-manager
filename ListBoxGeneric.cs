using System.Collections.Specialized;
using System.Windows.Controls;

namespace NotEdible
{
    public class ListBoxGeneric : ListBox
    {
        public ListBoxGeneric()
            : base()
        {
        }

        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);
            OnItemsChangedEvent(e);
        }

        public delegate void ItemsChangedEventHandler(object sender, NotifyCollectionChangedEventArgs e);
        public event ItemsChangedEventHandler ItemsChanged;

        private void OnItemsChangedEvent(NotifyCollectionChangedEventArgs e)
        {
            if (ItemsChanged != null)
                ItemsChanged(this, e);
        }
    }
}