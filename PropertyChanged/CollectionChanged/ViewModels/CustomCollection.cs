using CollectionChanged.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionChanged.ViewModels
{
    public class CustomCollection : INotifyCollectionChanged, IEnumerable
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private List<Person> persons = new List<Person>();

        public void Add(Person item)
        {
            this.persons.Add(item);
            this.OnCollectionChanged(
              new NotifyCollectionChangedEventArgs(
                NotifyCollectionChangedAction.Add, item));
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));

        }

        public void Remove(Person item)
        {
            this.persons.Remove(item);
            this.OnCollectionChanged(
              new NotifyCollectionChangedEventArgs(
                NotifyCollectionChangedAction.Remove, item));
        }

        public Person this[Int32 index]
        {
            get
            {
                return this.persons[index];
            }
            set
            {
                Object oldValue = null; 
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace,
                    value, oldValue));
            }

        }

        private void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            if (this.CollectionChanged != null)
            {
                this.CollectionChanged(this, args);
            }
        }

        public List<Person>.Enumerator GetEnumerator()
        {
            return this.persons.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this.GetEnumerator();
        }
    }
}
