using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFPMultiple.Models
{
    public class Movie : Base
    {
        private string id;

        [JsonProperty("_id")]
        public string Id
        {
            get { return id; }
            set {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string name;

        [JsonProperty("name")]
        public string Name
        {
            get { return name; }
            set {
                name = value;
                OnPropertyChanged("Id");
            }
        }

        private string pictureUri;

        [JsonProperty("picture")]
        public string PictureUri
        {
            get { return pictureUri; }
            set {
                pictureUri = value;
                OnPropertyChanged("PictureUri");
            }
        }

        private int year;

        [JsonProperty("year")]
        public int Year
        {
            get { return year; }
            set {
                year = value;
                OnPropertyChanged("Year");
            }
        }

        private string about;

        [JsonProperty("about")]
        public string About
        {
            get { return about; }
            set {
                about = value;
                OnPropertyChanged("About");
            }
        }

        private ObservableCollection<string> tags;

        [JsonProperty("tags")]
        public ObservableCollection<string> Tags
        {
            get { return tags; }
            set {
                tags = value;
                OnPropertyChanged("Tags");
            }
        }


        private ObservableCollection<Actor> actors;

        [JsonProperty("actors")]
        public ObservableCollection<Actor> Actors
        {
            get { return actors; }
            set {
                actors = value;
                OnPropertyChanged("Actors");
            }
        }



    }
}
