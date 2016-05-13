using MVVMSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSample.Services.DataServices
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}
