using System.Collections.ObjectModel;
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
            TodoList = new ObservableCollection<ToDo>(TodoList.OrderBy(x => x.DueDate));
            TaskListDataGrid.ItemsSource = TodoList;
            DataContext = this;  
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NewTaskWindow addToDoWindow = new NewTaskWindow();
            addToDoWindow.Owner = this;
            addToDoWindow.ShowDialog(); 
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            ToDo itemToRemove = button?.DataContext as ToDo;
            if (itemToRemove != null)
            {
                TodoList.Remove(itemToRemove);
            }
        }

        private void DeleteSelectedTask_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = TaskListDataGrid.SelectedItem as ToDo;
            if (selectedItem != null)
            {
                TodoList.Remove(selectedItem);
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (TaskListDataGrid.SelectedItem is ToDo selectedTask)
            {
                selectedTask.Doing = true;

            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (TaskListDataGrid.SelectedItem is ToDo selectedTask)
            {
                selectedTask.Doing = false;
            }
        }
    }
}