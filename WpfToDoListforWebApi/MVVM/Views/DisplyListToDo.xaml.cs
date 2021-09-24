using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfToDoListforWebApi.MVVM.Models;
using WpfToDoListforWebApi.MVVM.ModelViews;
using WpfToDoListforWebApi.Windows;

namespace WpfToDoListforWebApi.MVVM.Views
{
    /// <summary>
    /// Interaction logic for DisplyListToDo.xaml
    /// </summary>
    public partial class DisplyListToDo : UserControl
    {
        private const string url1 = "https://localhost:44344/apiMylist/GetAll";
        private const string url2 = "https://localhost:44344/apiMylist/create";
        private const string url3 = "https://localhost:44344/apiMylist/getById?ID=1";
        private const string url4 = "https://localhost:44344/apiMylist/delete?ID=";

        public static BindingList<TodoList> todolist = new BindingList<TodoList>();
      
        public DisplyListToDo()
        {
            InitializeComponent();
           
        }


        private async void delete_ClickAsync(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem == null)
            {
                MessageBox.Show("You need selecte row");
                return;
            }
            else
            {

                dynamic row = dataGrid.SelectedItem as TodoList;
                if (row is null)
                {
                    MessageBox.Show("Row is emty");
                    return;
                }
                await Task.Run(() =>
                {

                   var client = new RestClient(url4 + $"{row.Id}");
                   client.Timeout = -1;
                   var request = new RestRequest(Method.POST);
                   request.AddHeader("Content-Type", "application/json");
                   client.Execute(request);
                    MessageBox.Show($"Task by {row.Id} deleted");
                });

            }
            todolist = await GetListTodoAsync ();
            dataGrid.ItemsSource = todolist;
        }

        private async void Cheng_ClickAsync(object sender, RoutedEventArgs e)
        {

            if (dataGrid.SelectedItem != null)
            {
                dynamic row = dataGrid.SelectedItem as TodoList;
                if (row is null)
                {
                    MessageBox.Show("row is emty");
                    return;
                }

                var lin = new TodoList()
                {
                    Id = row.Id,
                    Text = row.Text,
                    IsDone = row.IsDone,
                    Mark = row.Mark,
                    Priority = row.Priority,
                    CreationDate =DateTime.Now,
                    Deadline = row.Deadline

                };
                await Task.Run(() =>
                {

                    var item = JsonConvert.SerializeObject(lin);
                    var client = new RestClient(url2);
                    client.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("Content-Type", "application/json");
                    request.AddParameter("application/json",
                    item, ParameterType.RequestBody);
                    client.Execute(request);

                });

            }
            else
            {
                MessageBox.Show("You need select row in the table");
            }
            todolist = await GetListTodoAsync();
            dataGrid.ItemsSource = todolist;
        }

        private async Task<BindingList<TodoList>> GetListTodoAsync()
        {
           
            var listtodo = new BindingList<TodoList>();
            var client = new RestClient(url1);        
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var body = @"";          
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var collection =  JsonConvert.DeserializeObject<List<TodoList>>(response.Content);
            if (collection is null)
            {
                MessageBox.Show(" 404 (Server don't work) or last connection");
                return  listtodo;
            }

            foreach (var item in collection)
            {
                listtodo.Add(item);             
            }

           await Task.WhenAll();
           return listtodo;
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var helper = Dispatcher.CurrentDispatcher;
            StartWindow start = new StartWindow();

           await Task.Run(()=>{

               helper.Invoke(() =>
               {
                   start.Show();
               });

           });

            todolist = await GetListTodoAsync();
            start.Close();
            dataGrid.ItemsSource = todolist;
        }
        private void category_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem == null)
            {
                MessageBox.Show("You need select row in the table");
                return;
            }
            dynamic row = dataGrid.SelectedItem as TodoList;
            if(row is null)
            {
                MessageBox.Show("Row is emty");
                return;
            }
            TodoList lin = new TodoList()
            {
                Id = row.Id,
                Text = row.Text,
                IsDone = row.IsDone,
                Mark = row.Mark,
                Priority = row.Priority,
                CreationDate = DateTime.Now,
                Deadline = row.Deadline

            };
            WindowTextCategory window = new WindowTextCategory();
            window.todoList = lin;
            window.ShowDialog();

        }

       

        private void show_Click(object sender, RoutedEventArgs e)
        {
            if (byPriority.IsChecked == true)
            {
                var qury = from s in todolist where (s.Priority == Priority.Hight)select s;
               
                dataGrid.ItemsSource = qury;
            }
            if (byChek.IsChecked == true)
            {
                var qury = from s in todolist where (s.IsDone == true)select s;
                dataGrid.ItemsSource = qury;
            }
            if (byData.IsChecked == true)
            {
                var today = DateTime.Now;
                var qury = from s in todolist where (s.Deadline >= today)select s;

                for (int i = 0; i < todolist.Count; i++)
                {
                    if (todolist[i].Deadline < today)
                    {
                        MessageBox.Show($"Attantion!!! {todolist[i].Id} overdue","",MessageBoxButton.OK);
                    }
                }
                
                dataGrid.ItemsSource = qury;
            }
            if (byPriority.IsChecked == false && byChek.IsChecked == false && byData.IsChecked == false)
            {
                dataGrid.ItemsSource = todolist;
            }
        }
    }
}
