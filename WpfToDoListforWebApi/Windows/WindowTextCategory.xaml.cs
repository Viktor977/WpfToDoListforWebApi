using Newtonsoft.Json;
using RestSharp;
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
    /// Interaction logic for WindowTextCategory.xaml
    /// </summary>
    public partial class WindowTextCategory : Window
    {
       
        private const string url1 = "https://localhost:44344/apiCategory/createCategoria";
        public  TodoList todoList { get; set; }
        public  WindowTextCategory()
        {
            InitializeComponent();
        }
       

        private void save_Click(object sender, RoutedEventArgs e)
        {

            var categoria = new Categoria() {


                NameCategory = text.Text,
                ListCategory = todoList
            };
            var item = JsonConvert.SerializeObject(categoria);
            var client = new RestClient(url1);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json",
            item, ParameterType.RequestBody);
            client.Execute(request);
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
