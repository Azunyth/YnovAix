using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace Collection.Models
{
    public class CustomImage
    {
        public ImageSource ImageUri { get; set; }

        public string Title { get; set; }

        public CustomImage(ImageSource s, string t)
        {
            this.ImageUri = s;
            this.Title = t;
        }
    }
}
