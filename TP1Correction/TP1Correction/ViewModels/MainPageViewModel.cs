using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Correction.Models;
using Windows.Storage;

namespace TP1Correction.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {

        #region Properties
        private ObservableCollection<ToDoTask> _tasks;

        public ObservableCollection<ToDoTask> Tasks
        {
            get { return this._tasks; }
            set {
                SetProperty(ref this._tasks, value);
            }
        }

        private ToDoTask _taskSelected;

        public ToDoTask TaskSelected
        {
            get { return _taskSelected; }
            set {
                SetProperty(ref this._taskSelected, value);
            }
        }
        #endregion

        #region Constructor
        public MainPageViewModel()
        {
            // Instanciation de la liste
            this.Tasks = LoadToDoList();
        }
        #endregion

        #region Add/Delete Functions
        public void AddTask(string taskName)
        {
            // Vérification si le contenu n'est pas vide
            if (!string.IsNullOrWhiteSpace(taskName))
            {
                //Création d'un nouvel item
                ToDoTask task = new ToDoTask() { Id = GenerateId(), Name = taskName };

                // Ajout de l'item à la liste
                this.Tasks.Add(task);
            }
        }

        public void DeleteTask()
        {
            if (this.TaskSelected != null)
            {
                // Si l'item existe dans la liste
                if (this.Tasks.Contains(this.TaskSelected))
                {
                    // Suppression de l'item
                    this.Tasks.Remove(this.TaskSelected);
                }
            }
        }
        #endregion

        #region Utils Functions
        private ObservableCollection<ToDoTask> LoadToDoList()
        {
            // Vérification si une liste existe dans le local storage
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("toDoList"))
            {
                // Récupération de la string json
                // Attention, Values est une collection d'objet, il est donc important de caster la variable
                var toDoListJson = (string)ApplicationData.Current.LocalSettings.Values["toDoList"];

                // Désérialisation du json
                return JsonConvert.DeserializeObject<ObservableCollection<ToDoTask>>(toDoListJson);
            }else
            {
                // Si le local storage n'existe pas, création d'une nouvelle collection
                return new ObservableCollection<ToDoTask>();
            }
        }

        private int GenerateId()
        {
            // Retoure l'id du dernier élèment +1 ou 1 si la liste est vide
            return (this.Tasks.Count > 0) ? this.Tasks.Last().Id++ : 1;
        }
        #endregion

    }
}
