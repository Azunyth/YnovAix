using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Media.Capture;
using Windows.Media.Devices;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Medias
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page1 : Page
    {
        public MediaCapture MediaCaptureMgr { get; set; }
        public Page1()
        {
            this.InitializeComponent();
            StartLive();
        }

        private async void StartLive()
        {
            MediaCaptureMgr = new MediaCapture();
            await MediaCaptureMgr.InitializeAsync();

            cePreview.Source = MediaCaptureMgr;

            await MediaCaptureMgr.StartPreviewAsync();
        }

        private async void TakePhoto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StorageFolder picturesFolder = KnownFolders.PicturesLibrary;
                StorageFile photoStorageFile = await picturesFolder.CreateFileAsync("photo.jpg", CreationCollisionOption.GenerateUniqueName);
                ImageEncodingProperties imageProperties = ImageEncodingProperties.CreateJpeg();
                await MediaCaptureMgr.CapturePhotoToStorageFileAsync(imageProperties, photoStorageFile);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception when taking a photo: {0}", ex.ToString());
            }
        }

        private void StartVideo_Click(object sender, RoutedEventArgs e)
        {
            if (btnStartVideo.IsChecked.Value)
            {
                StartVideo();
            }
            else
            {
                StopVideo();
            }
        }

        private async void StartVideo() {

            btnStartVideo.Icon = new SymbolIcon(Symbol.Stop);
            btnPause.Visibility = Visibility.Visible;

            StorageFile recordStorageFile = await KnownFolders.VideosLibrary.CreateFileAsync("video.mp4", CreationCollisionOption.GenerateUniqueName);
            MediaEncodingProfile recordProfile = MediaEncodingProfile.CreateMp4(VideoEncodingQuality.Auto);

            await MediaCaptureMgr.StartRecordToStorageFileAsync(recordProfile, recordStorageFile);
        }

        private async void StopVideo()
        {
            btnStartVideo.Icon = new SymbolIcon(Symbol.Video);
            btnPause.Visibility = Visibility.Collapsed;

            await MediaCaptureMgr.StopRecordAsync();
        }

        private async void PauseVideo_Click(object sender, RoutedEventArgs e)
        {
            if (!btnPause.IsChecked.Value)
            {
                btnPause.Icon = new SymbolIcon(Symbol.Pause);
                await MediaCaptureMgr.ResumeRecordAsync();
            }
            else {
                btnPause.Icon = new SymbolIcon(Symbol.Play);
                await MediaCaptureMgr.PauseRecordAsync(MediaCapturePauseBehavior.RetainHardwareResources);
            }
        }

        private async void RecordSound_Click(object sender, RoutedEventArgs e)
        {
            if (btnRecordAudio.IsChecked.Value)
            {
                StorageFile recordStorageFile = await KnownFolders.VideosLibrary.CreateFileAsync("audio.m4a", CreationCollisionOption.GenerateUniqueName);
                MediaEncodingProfile recordProfile = MediaEncodingProfile.CreateM4a(AudioEncodingQuality.Auto);
                await MediaCaptureMgr.StartRecordToStorageFileAsync(recordProfile, recordStorageFile);
            }else
            {
                await MediaCaptureMgr.StopRecordAsync();
            }
        }
    }
}
