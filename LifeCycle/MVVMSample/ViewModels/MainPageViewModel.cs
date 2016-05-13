using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using MVVMSample.Services.DataServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSample.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public const string ClockPropertyName = "Clock";
        public const string WelcomeTitlePropertyName = "WelcomeTitle";
        private string clock = "Démarrage";

        private readonly IDataService dataService;
        private readonly INavigationService navigationService;


        private int counter;
        private RelayCommand incrementCommand;
        private RelayCommand<string> navigateCommand;
        private bool clockRunning;
        private RelayCommand sendMessageCommand;
        private RelayCommand showDialogCommand;
        private string welcomeTitle = string.Empty;

        public string Clock
        {
            get
            {
                return clock;
            }
            set
            {
                Set(ClockPropertyName, ref clock, value);
            }
        }

        public RelayCommand IncrementCommand
        {
            get
            {
                return incrementCommand ??
                    (incrementCommand = new RelayCommand(
                    () =>
                    {
                        WelcomeTitle = string.Format("Compteur de clic = {0}", ++counter);
                    }));
            }
        }

        public RelayCommand<string> NavigateCommand
        {
            get
            {
                return navigateCommand ??
                       (navigateCommand = new RelayCommand<string>(
                           p => navigationService.NavigateTo(ViewModelLocator.SecondPageKey, p),
                           p => !string.IsNullOrEmpty(p)));
            }
        }

        public RelayCommand SendMessageCommand
        {
            get
            {
                return sendMessageCommand
                    ?? (sendMessageCommand = new RelayCommand(
                    () =>
                    {
                        Messenger.Default.Send(
                            new NotificationMessageAction<string>(
                                "Test",
                                reply =>
                                {
                                    WelcomeTitle = reply;
                                }));
                    }));
            }
        }

        public RelayCommand ShowDialogCommand
        {
            get
            {
                return showDialogCommand
                       ?? (showDialogCommand = new RelayCommand(
                           async () =>
                           {
                               var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                               await dialog.ShowMessage("Hello World depuis une Universal App !", "Ca marche !");
                           }));
            }
        }

        public string WelcomeTitle
        {
            get
            {
                return welcomeTitle;
            }

            set
            {
                Set(ref welcomeTitle, value);
            }
        }

        public MainPageViewModel(
            IDataService dataService,
            INavigationService navigationService)
        {
            this.dataService = dataService;
            this.navigationService = navigationService;
            Task.Run(() => initialize()).Wait();
        }

        public void RunClock()
        {
            clockRunning = true;

            Task.Run(async () =>
            {
                while (clockRunning)
                {
                    DispatcherHelper.CheckBeginInvokeOnUI(() =>
                    {
                        Clock = DateTime.Now.ToString("HH:mm:ss");
                    });

                    await Task.Delay(1000);
                }
            });
        }

        public void StopClock()
        {
            clockRunning = false;
        }

        private async Task initialize()
        {
            try
            {
                var item = await dataService.GetData();
                WelcomeTitle = item.Title;
            }
            catch (Exception ex)
            {
                WelcomeTitle = ex.Message;
            }
        }
    }
}

