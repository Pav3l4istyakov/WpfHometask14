using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHometask14
{
    public class ToDo
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public bool Doing { get; set; }
        public string Description { get; set; }

        public ToDo(string title, DateTime dueDate, bool doing, string description)
        {
            Title = title;
            DueDate = dueDate;
            Doing = doing;
            Description = description;
        }
    }
}

