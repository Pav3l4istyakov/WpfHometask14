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

            // Добавляем тестовые задачи
            TodoList.Add(new ToDo("Приготовить покушать", new DateTime(2024, 1, 15), true, "Нет описания"));
            TodoList.Add(new ToDo("Поработать", new DateTime(2024, 1, 20), false, "Съездить на совещание в Москву"));
            TodoList.Add(new ToDo("Отдохнуть", new DateTime(2024, 2, 1), false, "Съездить в отпуск в Сочи"));

            // Привязка к источнику данных
            TaskListDataGrid.ItemsSource = TodoList;

            // Обновляем прогресс при изменении свойств задач
            foreach (var todo in TodoList)
            {
                todo.PropertyChanged += TodoItem_PropertyChanged;
            }

            // Первоначальная настройка прогресса
            UpdateProgress();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NewTaskWindow addToDoWindow = new NewTaskWindow();
            addToDoWindow.Owner = this;
            addToDoWindow.ShowDialog();

            // Обновляем прогресс после добавления задачи
            UpdateProgress();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            ToDo itemToRemove = button?.DataContext as ToDo;
            if (itemToRemove != null)
            {
                TodoList.Remove(itemToRemove);
                UpdateProgress(); // Обновляем прогресс после удаления задачи
            }
        }

        private void DeleteSelectedTask_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = TaskListDataGrid.SelectedItem as ToDo;
            if (selectedItem != null)
            {
                TodoList.Remove(selectedItem);
                UpdateProgress(); // Обновляем прогресс после удаления выбранной задачи
            }
        }

        private void TodoItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ToDo.Doing))
            {
                UpdateProgress(); // Обновляем прогресс при изменении статуса задачи
            }
        }

        private void UpdateProgress()
        {
            int totalTasks = TodoList.Count;
            int completedTasks = TodoList.Count(x => x.Doing);

            // Обновляем прогресс бар
            TaskProgressBar.Minimum = 0;
            TaskProgressBar.Maximum = totalTasks;
            TaskProgressBar.Value = completedTasks;

            // Обновляем текст прогресса
            ProgressText.Text = $"{completedTasks} / {totalTasks}";
        }
    }

}