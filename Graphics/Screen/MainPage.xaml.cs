﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System.UserProfile;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Screen
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        private async void ChangeLockScreenBackground_Click(object sender, RoutedEventArgs e)
        {
            if (UserProfilePersonalizationSettings.IsSupported())
            {
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(@"ms-appx:///Assets/SplashScreen.png"));
                UserProfilePersonalizationSettings settings = UserProfilePersonalizationSettings.Current;
                await settings.TrySetLockScreenImageAsync(file);
            }
        }
    }
}
