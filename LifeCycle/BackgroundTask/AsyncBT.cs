using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.UI.Notifications;

namespace BackgroundTask
{
    public sealed class AsyncBT : IBackgroundTask
    {
        BackgroundTaskDeferral _deferral;
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            var cost = BackgroundWorkCost.CurrentBackgroundWorkCost;

            if (cost != BackgroundWorkCostValue.High)
            {
                taskInstance.Canceled += (s, e) => {
                    Debug.WriteLine("Tache de fond annulé");
                };

                _deferral = taskInstance.GetDeferral();

                // Méthode asynchrone ici
                HttpClient client = new HttpClient();

                var content = await client.GetStringAsync("http://www.microsoft.com");

                DisplayToastNotification(content);

                _deferral.Complete();

            }
        }

        public void DisplayToastNotification(string value)
        {
            var template = ToastTemplateType.ToastText01;
            var xml = ToastNotificationManager.GetTemplateContent(template);
            var text = xml.CreateTextNode(value);
            var elements = xml.GetElementsByTagName("text");
            elements[0].AppendChild(text);

            var toast = new ToastNotification(xml);
            var notifier = ToastNotificationManager.CreateToastNotifier();
            notifier.Show(toast);
        }
    }
}
