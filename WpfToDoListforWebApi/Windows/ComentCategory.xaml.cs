using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfToDoListforWebApi.MVVM.Models;

namespace WpfToDoListforWebApi
{
    /// <summary>
    /// Interaction logic for ComentCategory.xaml
    /// </summary>
    public partial class ComentCategory : Window
    {
        private List<TodoList> _todoList;
        public ComentCategory(List<TodoList> todoList)
        {
            InitializeComponent();
            _todoList = todoList;
            DisplayComment();

        }

        private void DisplayComment() 
        {


            foreach (var item in _todoList)
            {
                listBox.Items.Add($"You need {item.Text} from {item.CreationDate} to {item.Deadline}");
            }
        }
    }
}
