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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Collection
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GridViewExemple : Page
    {
        public GridViewExemple()
        {
            this.InitializeComponent();
            List<CustomColor> colors = new List<CustomColor>() {
                new CustomColor("Aqua"),
                new CustomColor("Coral"),
                new CustomColor("Chocolate"),
                new CustomColor("Cornsilk"),
                new CustomColor("Crimson"),
                new CustomColor("Yellow"),
                new CustomColor("LawnGreen"),
                new CustomColor("DarkBlue"),
                new CustomColor("Indigo"),
                new CustomColor("Ivory"),
            };

            this.gvColors.DataContext = colors;
        }
    }
}
