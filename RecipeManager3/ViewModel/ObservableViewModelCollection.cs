using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RecipeManager3.ViewModel
{
    /// <summary>
    /// A collection that removes an item on Deleted property changes to true.
    /// </summary>
    /// <remarks>
    /// I don't like this solution either.
    /// </remarks>
    class ObservableViewModelCollection<TItem> : ObservableCollection<TItem>
        where TItem : class, INotifyPropertyChanged
    {

        public ObservableViewModelCollection(string removePropertyName = "Deleted")
        {
            this.RemovePropertyName = removePropertyName;
        }

        public string RemovePropertyName { get; set; }

        protected override void InsertItem(int index, TItem item)
        {
            base.InsertItem(index, item);
            item.PropertyChanged += ItemPropertyChanged;
        }

        protected override void RemoveItem(int index)
        {
            this.ElementAt(index).PropertyChanged -= ItemPropertyChanged;
            base.RemoveItem(index);
        }

        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var item = sender as TItem;
            if (e.PropertyName == this.RemovePropertyName)
            {
                if (true == (bool)typeof(TItem).GetProperty(this.RemovePropertyName).GetValue(item, null))
                {
                    this.Remove(item);
                }
            }
        }
    }
}
