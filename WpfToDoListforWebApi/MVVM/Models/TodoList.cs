using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfToDoListforWebApi.MVVM.Models

{
    public class TodoList
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsDone { get; set; }
        public string Mark { get; set; }
        public Priority Priority { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime Deadline { get; set; }

    }
}
