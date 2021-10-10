using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfToDoListforWebApi.MVVM.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TodoList
    {
        public int Id { get; set; }
        /// <summary>
        /// this text general task
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// marks were done or not
        /// </summary>
        public bool IsDone { get; set; }
        /// <summary>
        /// this point name category
        /// </summary>
        public string Mark { get; set; }
        public Priority Priority { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime Deadline { get; set; }

    }
}
