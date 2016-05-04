using CollectionChanged.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionChanged.ViewModels
{
    public class MainPageViewModel
    {

        //public ObservableCollection<Person> Persons { get; set; }
        public CustomCollection Persons { get; set; }

        public MainPageViewModel() {
            //this.Persons = new ObservableCollection<Person>();
            this.Persons = new CustomCollection();
            this.Persons.Add(new Person() { Firstname = "Ted", Lastname = "Mosby" });
            
        }
    }
}
