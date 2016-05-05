using ObservableSample.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableSample.ViewModels
{
    public class MainPageViewModel
    {
        public ObservableCollection<Person> Persons { get; set; }

        public MainPageViewModel() {
            Persons = new ObservableCollection<Person>();
            // Ajout de quelques personnes dans la liste
            this.Persons.Add(new Person() { Firstname = "Ted", Lastname = "Mosby" });
            this.Persons.Add(new Person() { Firstname = "Barney", Lastname = "Stinson" });
            this.Persons.Add(new Person() { Firstname = "Marshall", Lastname = "Eriksen" });
        }
    }
}
