using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Actor : Person
    {
        public string RealFirstname { get; set; }

        public string RealLastname { get; set; }

        public string MainShow { get; set; }
    }
}
