using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfToDoListforWebApi.MVVM.Models;

namespace WpfToDoListforWebApi.MVVM.Views
{
    /// <summary>
    /// Interaction logic for DisplyCtegories.xaml
    /// </summary>
    public partial class DisplyCategories : UserControl
    {
        private const string url = "https://localhost:44344/apiCategory/getAllCategories";
        private const string url2 = "https://localhost:44344/apiCategory/deleteByIdCategory?Id=";
        private const string url3 = "https://localhost:44344/apiMylist/getById?ID=";
        private BindingList<Categoria> categories;
        private Dispatcher _dispatcher;
        public DisplyCategories()
        {
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            categories = new BindingList<Categoria>();
            await Task.Run(()=>{
            
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                var body = @"";
                request.AddParameter("text/plain", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                var collection = JsonConvert.DeserializeObject<List<Categoria>>(response.Content);

                if (collection is null)
                {
                    MessageBox.Show(" 404 (Server don't work)");
                    return ;
                }
                foreach (var item in collection)
                {
                   categories.Add(item);
                }
            });
           
           
            dataGrid.ItemsSource = categories;

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            _dispatcher = Dispatcher.CurrentDispatcher;
            
            if (dataGrid.SelectedItem == null)
            {
                MessageBox.Show("Select a row in the table");
            }
            else
            {
                await Task.Run(()=> {

                    _dispatcher.Invoke(new Action(() => {
                                     
                        var item = dataGrid.SelectedItem as Categoria;
                        var client = new RestClient(url2+$"{item.Id}");
                        client.Timeout = -1;
                        var request = new RestRequest(Method.POST);
                        client.Execute(request);
                        MessageBox.Show($"Categoria by id={item.Id} deleted ");
                    
                    }));
                   
                });
                
               
                this.UserControl_Loaded(null, null);
            }
        }

       

        private void show_Click(object sender, RoutedEventArgs e)
        {
            var todolist = DisplyListToDo.todolist;
            var newlist =new List<TodoList>();         
            var category = dataGrid.SelectedItem as Categoria;
            if(category is  null)
            {
                MessageBox.Show(" You Need Select Row");
                return;
            }
            foreach(var item in todolist)
            {
                if (item.Mark == category.NameCategory)
                { 
                    newlist.Add(item);                 
                }
            } 
            ComentCategory coments = new ComentCategory(newlist);       
            coments.Show();         

        }
    }
}
