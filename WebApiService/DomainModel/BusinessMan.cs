using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class BusinessMan : Person
    {
        public double NetWorth { get; set; }

        public string MainCompany { get; set; }

        public bool IsRetired { get; set; }

    }
}
