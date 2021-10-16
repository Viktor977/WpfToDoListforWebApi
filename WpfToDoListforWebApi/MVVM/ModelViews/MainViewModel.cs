using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfToDoListforWebApi.Core;
using WpfToDoListforWebApi.MVVM.Views;

namespace WpfToDoListforWebApi.MVVM.ModelViews
{
    /// <summary>
    /// 
    /// </summary>
   public class MainViewModel:ObservableObjects
   {
        private object _currentView;
        /// <summary>
        /// 
        /// </summary>
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public HomeView homeView { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DisplylListToDoModel displayToDo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DisplyCategoriesModel displycategory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RellayCommand DisplyHomeView { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RellayCommand DisplayListToDoCommand { get; set; }
        /// <summary>
        /// 
        /// </summary>
       
        public RellayCommand DisplyCategoryCommand { get; set; }
        /// <summary>
        /// Constructor  without parameters 
        ///  which creates object 
        /// with specified :HomeNiew,DisplayListToDoWiev,DisplyCategoriesModel 
        /// </summary>
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
