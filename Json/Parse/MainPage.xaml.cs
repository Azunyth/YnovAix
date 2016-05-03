using Newtonsoft.Json;
using Parse.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Parse
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            //var uri = new System.Uri(@"ms-appx:///Parse/Data/movies.json");

            loadJson();
        }

        public async void loadJson() {

            StorageFile sampleFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri(@"ms-appx:///Data/movie.json")); 

            string text = await FileIO.ReadTextAsync(sampleFile);

            Movie m = JsonConvert.DeserializeObject<Movie>(text);

            this.spData.DataContext = m;

        }
    }
}
