using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHometask14
{
    public class ToDo : INotifyPropertyChanged
    {
        private string title;
        private DateTime dueDate;
        private bool doing;
        private string description;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public DateTime DueDate
        {
            get { return dueDate; }
            set
            {
                dueDate = value;
                OnPropertyChanged(nameof(DueDate));
            }
        }

        public bool Doing
        {
            get { return doing; }
            set
            {
                doing = value;
                OnPropertyChanged(nameof(Doing)); 
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public ToDo(string title, DateTime dueDate, bool doing, string description)
        {
            Title = title;
            DueDate = dueDate;
            Doing = doing;
            Description = description;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

