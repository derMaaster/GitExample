using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace ClassLibraryNetStandard
{
    public class NotificationBaseHelper:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // SetProperty helper functions to implement getters and setters of iheritance classes:
        // SetField (Name, value); // where there is a data member
        protected bool SetProperty<T>(
            ref T field,
            T value,
            [CallerMemberName] string property = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            RaisePropertyChanged(property);
            return true;
        }
        // SetField(()=> somewhere.Name = value; somewhere.Name,value)
        // Advanced case where you rely on another property
        protected bool SetProperty<T>(
            T currentValue,
            T newValue,
            Action DoSet,
            [CallerMemberName] string property = null)
        {
            if (EqualityComparer<T>.Default.Equals(currentValue, newValue)) return false;
            DoSet.Invoke();
            RaisePropertyChanged(property);
            return true;
        }

        protected void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }

    /*  Using the NotificationBase<T> is a convenient way to wrap existing business objects that don’t already support INPC (INotifyPropertyChanged), like your Person Class or whatever
    *  It is a good approach especially when the business objects are large – as the pass through capability doesn’t require duplicating fields.
    */
    public class NotificationBaseHelper<T> : NotificationBaseHelper where T : class, new()
    {
        protected T This;

        /* user defined type conversion operator:
         * this gives the power to your C# class, which can accept any reasonably convertible data type without type casting
         * convertible type         :       NotificationBaseHelper<T>
         * converting (into) type   :       T
         */
        public static implicit operator T(NotificationBaseHelper<T> thing)
        {
            return thing.This;
        }
        public NotificationBaseHelper(T thing = null)
        {
            This = (thing == null) ? new T() : thing;
        }

    }
}
