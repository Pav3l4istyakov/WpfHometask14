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
        private string _title;
        private DateTime _dueDate;
        private bool _doing;
        private string _description;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public DateTime DueDate
        {
            get { return _dueDate; }
            set
            {
                _dueDate = value;
                OnPropertyChanged(nameof(DueDate));
            }
        }

        public bool Doing
        {
            get { return _doing; }
            set
            {
                _doing = value;
                OnPropertyChanged(nameof(Doing));
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
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

