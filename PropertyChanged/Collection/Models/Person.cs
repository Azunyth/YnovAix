using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic.Models
{
    public class Person : INotifyPropertyChanged
    {
        private string firstname;
        private string lastname;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Firstname
        {
            get { return firstname; }
            set {
                firstname = value;
                NotifyPropertyChanged("Firstname");
            }
        }
    

        public string Lastname
        {
            get { return lastname; }
            set {
                lastname = value;
                NotifyPropertyChanged("Lastname");
            }
        }

        private void NotifyPropertyChanged(string property)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }




    }
}
