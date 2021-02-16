using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Specialized;

namespace ClassLibraryNetStandard.Helpers
{
    public sealed class ExObservableCollection<T>:ObservableCollection<T> where T: INotifyPropertyChanged
    {
        // comments:
        // This class just effectively adds ItemPropertyChanged() method to run when CollectionChanged event fires?

        public ExObservableCollection()
        {
            CollectionChanged += AllObservableCollectionChanged;
        }
        public ExObservableCollection(IEnumerable<T> pItems) : this()
        {
            foreach(var item in pItems)
            {
                this.Add(item);
            }
        }

        // Register ItemPropertyChanged() to each item when added, and de-register when removed, ?
        private void AllObservableCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.NewItems != null)
            {
                foreach(Object item in e.NewItems)
                {
                    ((INotifyPropertyChanged)item).PropertyChanged += ItemPropertyChanged;
                }
            }
            if(e.OldItems != null)
            {
                foreach(Object item in e.OldItems)
                {
                    ((INotifyPropertyChanged)item).PropertyChanged -= ItemPropertyChanged;
                }
            }
        }

        // I presume this does INPC when an item within the observableCollection changes?
        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyCollectionChangedEventArgs args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace,sender,sender,IndexOf((T)sender));
            OnCollectionChanged(args);
        }
    }
}
