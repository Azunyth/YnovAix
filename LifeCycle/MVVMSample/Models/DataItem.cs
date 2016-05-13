using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSample.Models
{
    public class DataItem
    {
        public string Title { get; set; }

        public DataItem(string title)
        {
            this.Title = title;
        }
    }
}
