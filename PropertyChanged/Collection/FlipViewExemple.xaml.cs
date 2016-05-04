using Collection.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Collection
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FlipViewExemple : Page
    {
        public FlipViewExemple()
        {
            this.InitializeComponent();
            List<CustomImage> images = new List<CustomImage>() {
                new CustomImage(new BitmapImage(new Uri(@"ms-appx:///Assets/html-code.jpg")), "HTML"),
                new CustomImage(new BitmapImage(new Uri(@"ms-appx:///Assets/java.jpg")), "Java"),
                new CustomImage(new BitmapImage(new Uri(@"ms-appx:///Assets/windows.jpg")), "UWP"),
            };
            this.fvExample.DataContext = images;
        }
    }
}
