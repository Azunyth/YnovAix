using BindingVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingVM.ViewModels
{
    public class MainPageViewModel
    {
        public Person Person { get; set; }

        public MainPageViewModel()
        {
            this.Person = new Person() { Firstname = "Ted", Lastname = "Mosby" };
        }
    }
}
