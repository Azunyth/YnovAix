using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Maps
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            GetCurrentPosition();
        }

        public async void GetCurrentPosition() {

            var accessStatus = await Geolocator.RequestAccessAsync();

            if (accessStatus == GeolocationAccessStatus.Allowed)
            {
                Geolocator locator = new Geolocator { DesiredAccuracy = PositionAccuracy.Default, ReportInterval = 5000 };

                locator.PositionChanged += OnPositionChanged;

                var pos = await locator.GetGeopositionAsync();
                AddPointOnMap(pos.Coordinate.Latitude, pos.Coordinate.Longitude, "Votre position");
            }
            else if (accessStatus == GeolocationAccessStatus.Denied) {
                bool result = await Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-location"));
                if(result)
                {
                    GetCurrentPosition();
                }
            }
        }

        private async void OnPositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var latitude = args.Position.Coordinate.Latitude;
                var longitude = args.Position.Coordinate.Longitude;
                AddPointOnMap(latitude, longitude, "Nouvelle position");
            });
        }

        private void AddPoint_Click(object sender, RoutedEventArgs e)
        {
            double latitude = 45.757198;
            double longitude = 4.83121879;

            AddPointOnMap(latitude, longitude, "Place Bellecour");
        }

        private void AddPointOnMap(double latitude, double longitude, string label)
        {
            BasicGeoposition snPosition = new BasicGeoposition() { Latitude = latitude, Longitude = longitude };
            Geopoint snPoint = new Geopoint(snPosition);

            // Create a MapIcon.
            MapIcon mapIcon1 = new MapIcon();
            mapIcon1.Location = snPoint;
            mapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
            mapIcon1.Title = label;
            mapIcon1.ZIndex = 0;

            mcMap.MapElements.Add(mapIcon1);

            mcMap.Center = snPoint;
            mcMap.ZoomLevel = 17;
        }

        private async void SearchAddress_Click(object sender, RoutedEventArgs e)
        {
            string addressToGeocode = tbFindAddress.Text;
            
            BasicGeoposition queryHint = new BasicGeoposition();
            queryHint.Latitude = 45.75801;
            queryHint.Longitude = 4.8001016;
            Geopoint hintPoint = new Geopoint(queryHint);
            
            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAsync(addressToGeocode, hintPoint, 3);

            var latitude = result.Locations[0].Point.Position.Latitude;
            var longitude = result.Locations[0].Point.Position.Longitude;

            BasicGeoposition resPosition = new BasicGeoposition() {
                Latitude = result.Locations[0].Point.Position.Latitude,
                Longitude = result.Locations[0].Point.Position.Longitude
            };
            Geopoint resPoint = new Geopoint(resPosition);

            if (result.Status == MapLocationFinderStatus.Success)
            {
                mcMap.Center = resPoint;
                mcMap.ZoomLevel = 17;
            }
        }
    }
}
