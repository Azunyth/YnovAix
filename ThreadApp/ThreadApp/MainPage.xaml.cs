using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ThreadApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var watch = Stopwatch.StartNew();

            // VERSION SYNCHRONE

            //for (int i = 2; i < 20; i++)
            //{
            //    var result = SumRootN(i);
            //    Debug.WriteLine("root " + i.ToString() + " : " + result.ToString() + Environment.NewLine);
            //    //this.tb1.Text += "root " + i.ToString() + " : " + result.ToString() + Environment.NewLine;
            //}

            // VERSION ASYNCHRONE

            //Parallel.For(2, 20, (i) =>
            //{
            //    var result = SumRootN(i);
            //    Debug.WriteLine("root " + i.ToString() + " : " + result.ToString());
            //});

            Debug.WriteLine(watch.ElapsedMilliseconds);
        }

        public static double SumRootN(int root)
        {
            double result = 0;
            for (int i = 1; i < 10000000; i++)
            {
                result += Math.Exp(Math.Log(i) / root);
            }
            return result;
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {

            var watch = Stopwatch.StartNew();

            List<Task> tasks = new List<Task>();
            for (int i = 2; i < 20; i++)
            {
                var j = i;
                var t = Task.Factory.StartNew(async () =>
                {
                    var result = SumRootN(j);
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                     {
                         tb1.Text += "root " + j.ToString() + " : " + result.ToString() + Environment.NewLine;
                     });
                });
                tasks.Add(t);
            }

            Task.Factory.ContinueWhenAll(tasks.ToArray(),
                async result =>
                {
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                     {
                         timeSpent.Text += watch.ElapsedMilliseconds.ToString();
                     });
                }
            );


            //Parallel.For(2, 20, async (i) =>
            //{
            //    var result = SumRootN(i);
            //    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            //     {
            //         tb1.Text += "root " + i.ToString() + " : " + result.ToString() + Environment.NewLine;
            //     });
            //});

            //timeSpent.Text += watch.ElapsedMilliseconds.ToString();



            //tb1.Text += "root " + i.ToString() + " : " + result.ToString() + Environment.NewLine

            //for (int i = 2; i < 20; i++)
            //{
            //  var result = SumRootN(i);
            //  this.tb1.Text += "root " + i.ToString() + " : " + result.ToString() + Environment.NewLine;
            //}


        }


        //async Task<int> AccessTheWebAsync()
        //{
        //    HttpClient client = new HttpClient();
            
        //    Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");
            
        //    string urlContents = await getStringTask;
            
        //    return urlContents.Length;
        //}
    }
}
