using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfHometask14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<ToDo> TodoList { get; set; } = new ObservableCollection<ToDo>();

        public MainWindow()
        {
            InitializeComponent();

          
            TodoList.Add(new ToDo("Приготовить покушать", new DateTime(2024, 1, 15), true, "Нет описания"));
            TodoList.Add(new ToDo("Поработать", new DateTime(2024, 1, 20), false, "Съездить на совещание в Москву"));
            TodoList.Add(new ToDo("Отдохнуть", new DateTime(2024, 2, 1), false, "Съездить в отпуск в Сочи"));

            
            TaskListDataGrid.ItemsSource = TodoList;

           
            foreach (var todo in TodoList)
            {
                todo.PropertyChanged += TodoItemPropertyChanged;
            }

            
            UpdateProgress();
        }

        
        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            NewTaskWindow addToDoWindow = new NewTaskWindow();
            addToDoWindow.Owner = this;
            addToDoWindow.ShowDialog();

           
            foreach (var todo in TodoList)
            {
                todo.PropertyChanged -= TodoItemPropertyChanged;
                todo.PropertyChanged += TodoItemPropertyChanged;
            }

            
            UpdateProgress();
        }

        
        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            ToDo itemToRemove = button.DataContext as ToDo;
            if (itemToRemove != null)
            {
                TodoList.Remove(itemToRemove);
                UpdateProgress();
            }
        }

        
        private void TodoItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ToDo.Doing)) 
            {
                UpdateProgress(); 
            }
        }

      
        private void UpdateProgress()
        {
            int totalTasks = TodoList.Count;
            int completedTasks = TodoList.Count(x => x.Doing); 

           
            TaskProgressBar.Minimum = 0;
            TaskProgressBar.Maximum = totalTasks;
            TaskProgressBar.Value = completedTasks;

           
            ProgressText.Text = $"{completedTasks} / {totalTasks}";
        }
    }

}