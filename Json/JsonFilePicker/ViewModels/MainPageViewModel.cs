using Newtonsoft.Json;
using Parse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonFilePicker.ViewModels
{
    public class MainPageViewModel
    {
        public Movie Movie { get; set; }

        public void ParseJson(string json) {
            Movie m = JsonConvert.DeserializeObject<Movie>(json);

            this.Movie = m;
        }
    }
}
