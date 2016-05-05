using JFPMultiple.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFPMultiple.ViewModels
{
    public class MainPageViewModel : Base
    {
        private ObservableCollection<Movie> movies;

        public ObservableCollection<Movie> Movies
        {
            get { return movies; }
            set {
                movies = value;
                OnPropertyChanged("Movies");
            }
        }
        
        
        public MainPageViewModel()
        {
            this.Movies = new ObservableCollection<Movie>();
        }

        public void ParseJson(string json) {
            this.Movies = JsonConvert.DeserializeObject<ObservableCollection<Movie>>(json);

            this.LoadImages();
        }

        public void LoadImages() {
            this.Movies.ToList().ForEach((m) => { m.PictureUri = @"ms-appx:///Images/" + m.PictureUri; });
        }
    }
}
