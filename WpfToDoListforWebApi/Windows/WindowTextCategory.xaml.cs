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
        /// <summary>
        /// 
        /// </summary>
        public TodoList todoList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public WindowTextCategory()
        {
            InitializeComponent();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Categoria categoria = new()
            {
                NameCategory = text.Text,
                ListCategory = todoList
            };
            string item = JsonConvert.SerializeObject(categoria);
            RestClient client = new(url1)
            {
                Timeout = -1
            };
            RestRequest request = new RestRequest(Method.POST);
            _ = request.AddHeader("Content-Type", "application/json");
            _ = request.AddParameter("application/json",
            item, ParameterType.RequestBody);
            _ = client.Execute(request);
            Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
