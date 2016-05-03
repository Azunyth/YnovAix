using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingObject.Models
{
    public class Person
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public Person(string firstname, string lastname) {
            this.Firstname = firstname;
            this.Lastname = lastname;
        }

        // Decommenter cette section pour afficher le prénom et la nom au lieu de la classe
        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    return sb.AppendFormat("{0} {1}", this.Firstname, this.Lastname).ToString();
        //}
    }
}
