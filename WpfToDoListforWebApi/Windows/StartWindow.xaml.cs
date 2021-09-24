using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfToDoListforWebApi.Windows
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();          
            progrBar.Maximum =500;
          
        }

       
        

        private void Window_ContentRendered(object sender, EventArgs e)
        {
             progrBar.Value = 1;

            while (progrBar.Value < 490)
            {
                progrBar.Value++;
               
            }
        }
    }
}
