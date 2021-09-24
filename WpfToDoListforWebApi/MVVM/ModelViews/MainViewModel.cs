using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfToDoListforWebApi.Core;
using WpfToDoListforWebApi.MVVM.Views;

namespace WpfToDoListforWebApi.MVVM.ModelViews
{
   public class MainViewModel:ObservableObjects
   {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public HomeView homeView { get; set; }
        public DisplylListToDoModel displayToDo { get; set; }
        public DisplyCategoriesModel displycategory { get; set; }
        public RellayCommand DisplyHomeView { get; set; }
        public RellayCommand DisplayListToDoCommand { get; set; }
       
        public RellayCommand DisplyCategoryCommand { get; set; }
        public MainViewModel()
        {
            homeView = new HomeView();
            CurrentView = homeView;

            DisplyHomeView = new RellayCommand(d => 
            {
                CurrentView = homeView;
            });

            displayToDo = new DisplylListToDoModel();
            DisplayListToDoCommand = new RellayCommand(f =>
            {
                CurrentView = displayToDo;
            });

            displycategory = new DisplyCategoriesModel();

            DisplyCategoryCommand = new RellayCommand(q =>
            {
                CurrentView = displycategory;
            });
        }
   }
}
