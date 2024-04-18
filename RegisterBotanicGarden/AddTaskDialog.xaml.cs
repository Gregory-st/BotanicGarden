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
using DataBaseWorker;
using System.Data;
using System.Data.OleDb;

namespace RegisterBotanicGarden
{
    /// <summary>
    /// Логика взаимодействия для AddTaskDialog.xaml
    /// </summary>
    public partial class AddTaskDialog : Window
    {
        int iduser;
        DataBaseApplication application;
        DataTable userMain;
        DataTable TypeOfTask;
        public AddTaskDialog()
        {
            InitializeComponent();
        }
        public AddTaskDialog(int iduser)
        {
            InitializeComponent();
            this.iduser = iduser;
            application = new DataBaseApplication();
            application.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Ботанический_сад.accdb";

            userMain = application.GetDataTableOn("Пользователь", $"Код<>{iduser}");

            foreach (DataRow i in userMain.Rows)
                MainUser1.Items.Add($"{i["Фамилия"]} {i["Имя"]} {i["Отчество"]}");

            for (int i = 1; i <= userMain.Rows.Count; i++)
                CountUsers1.Items.Add(i);

            UpdateTypeTask();
        }

        public void UpdateTypeTask()
        {
            if(TypeOfTask != null)
                TypeOfTask.Dispose();    
            
            TypeOfTask = application.GetDataTable("ТипЗадания");

            for (int i = 1; i < TypeTasks.Items.Count; i++)
                TypeTasks.Items.RemoveAt(i);

            foreach(DataRow i in TypeOfTask.Rows)
                TypeTasks.Items.Add(i["Название"]);

            TypeTasks.SelectedIndex = 0;
        }

        private void TypeTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Border border = TypeTaskAdd1.Parent as Border;
            border.Visibility = (Visibility)(Convert.ToInt32(TypeTasks.SelectedIndex != 0) * 2);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UIElement[] Validation = new UIElement[] 
            {
                TypeTaskAdd1,
                TargetTask1,
                MessageTask1,
                CountDay1,
                MainUser1,
                CountUsers1
            };

            bool error = false;

            foreach(var i in Validation)
            {
                if(i is TextBox textBox)
                {
                    if (textBox.Text.Length == 0 && textBox.Visibility == Visibility.Visible)
                    {
                        error = true;
                        Border border = textBox.Parent as Border;
                        border.Background = (Brush)new BrushConverter().ConvertFrom("#FFFF9595");
                    }
                    else
                    {
                        Border border = textBox.Parent as Border;
                        border.Background = (Brush)new BrushConverter().ConvertFrom("#FFE975");
                    }
                }
                else if(i is ComboBox comboBox)
                {
                    if (comboBox.SelectedIndex == -1)
                    {
                        error = true;
                        Border border = comboBox.Parent as Border;
                        border.Background = (Brush)new BrushConverter().ConvertFrom("#FFFF9595");
                    }
                    else
                    {
                        Border border = comboBox.Parent as Border;
                        border.Background = (Brush)new BrushConverter().ConvertFrom("#FFE975");
                    }
                }
            }

            if(error)
            {
                MessageBox.Show("Не все поля были заполнены", "Система", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int idtypetask = TypeTasks.SelectedIndex;
            int idtask = application.GetDataTable("Задание").Rows.Count + 1;

            string[] person = MainUser1.SelectedItem.ToString().Split();
            string command = $"SELECT Код FROM Пользователь WHERE Фамилия = '{person[0]}' AND Имя = '{person[1]}' AND Отчество = '{person[2]}'";

            int idmain = Convert.ToInt32(application.GetDataTableOn(command).Rows[0][0]);
            if(idtypetask == 0)
            {
                idtypetask = TypeOfTask.Rows.Count + 1;
                application.AddDataRow("ТипЗадания", idtypetask, TypeTaskAdd1.Text);
            }

            application.AddDataRow("Задание", idtask, iduser, idmain, idtypetask, Convert.ToInt32(CountDay1.Text), "Wait", DateTime.Today.ToShortDateString(), MessageTask1.Text, Convert.ToInt32(CountUsers1.SelectedItem), TargetTask1.Text);

            DialogResult = true;
        }

        private void CountDay1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.Key >= (int)Key.D0 && (int)e.Key <= (int)Key.D9 || e.Key == Key.Back) return;
            e.Handled = true;
        }

        private void Cancel_CLick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
