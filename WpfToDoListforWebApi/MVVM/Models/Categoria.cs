using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfToDoListforWebApi.MVVM.Models
{
    /// <summary>
    /// entity to create a category
    /// </summary>
    public class Categoria
    {
        /// <summary>
        /// id category
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// name category(users settings)
        /// </summary>
        public string NameCategory { get; set; }
        /// <summary>
        /// foreign key at the table "todolist"
        /// </summary>
        public TodoList ListCategory { get; set; }
      
    }
}
