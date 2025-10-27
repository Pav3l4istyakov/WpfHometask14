using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfHometask14
{
    /// <summary>
    /// Логика взаимодействия для NewTaskWindow.xaml
    /// </summary>
    public partial class NewTaskWindow : Window
    {
        public NewTaskWindow()
        {
            InitializeComponent();
        }

        //Удалите этот метод AddButton_Click, он не нужен
        /*private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NewTaskWindow addToDoWindow = new NewTaskWindow();
            addToDoWindow.Owner = this;
            addToDoWindow.ShowDialog();
        }*/

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text;
            DateTime? dueDate = DueDatePicker.SelectedDate;
            string description = DescriptionTextBox.Text;

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show(" введите название задачи.");
                return;
            }

            ToDo newItem = new ToDo(title, dueDate.GetValueOrDefault(), false, description);
            MainWindow.TodoList.Add(newItem);

            this.Close();
        }
    }
}







