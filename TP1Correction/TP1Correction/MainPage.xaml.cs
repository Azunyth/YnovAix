using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TP1Correction.Models;
using TP1Correction.ViewModels;
using TP1Correction.Views;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TP1Correction
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPageViewModel MPViewModel { get; set; }
        public MessageDialog MdSave { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            this.MPViewModel = new MainPageViewModel();
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            this.MdSave = new MessageDialog(loader.GetString("MdSaveSuccess"));
        }

        #region Events
        private async void SaveList_Click(object sender, RoutedEventArgs e)
        {
            // Sauvegarde dans le local storage de la liste 
            ApplicationData.Current.LocalSettings.Values["toDoList"] = JsonConvert.SerializeObject(this.MPViewModel.Tasks);

            await this.MdSave.ShowAsync();
        }

        private void AddTodo_Click(object sender, RoutedEventArgs e)
        {
            AddToDo();
        }

        private void AddToDo_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                AddToDo();
                e.Handled = true;
            }
            
        }

        private async void DeleteToDo_Click(object sender, RoutedEventArgs e)
        {
            // Recuperation du bouton qui a levé l'évènement
            var btn = (Button)e.OriginalSource;

            // Récuperation de l'item bindé sur le bouton
            this.MPViewModel.TaskSelected = (ToDoTask)btn.CommandParameter;

            // Création d'une boite de dialogue
            DeleteConfirmation dc = new DeleteConfirmation();
            // Affectation du viewmodel de cette page, à la page de la boite de dialogue
            // On "partage" le viewmodel
            dc.MainPageVM = this.MPViewModel;

            // Affichge de la boite de dialogue
            await dc.ShowAsync();
        }
        #endregion

        #region Methods
        private void AddToDo()
        {
            // Recupération du contenu de la textbox
            // Trim : supprime les espaces
            var tbToDoItemText = tbToDoItem.Text.Trim();

            // Le ViewModel gère la logique de la fonction d'ajout
            this.MPViewModel.AddTask(tbToDoItemText);

            // Le textbox est vidé
            tbToDoItem.Text = "";
        }
        #endregion

        #region Style
        private void SymbolIcon_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            ((SymbolIcon)sender).Opacity = 1;
        }

        private void SymbolIcon_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            ((SymbolIcon)sender).Opacity = 0.5;
        }
        #endregion
        
    }
}
