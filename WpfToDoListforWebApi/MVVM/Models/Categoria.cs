using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfToDoListforWebApi.MVVM.Models
{
   public  class Categoria
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }
        public TodoList ListCategory { get; set; }
      
    }
}
