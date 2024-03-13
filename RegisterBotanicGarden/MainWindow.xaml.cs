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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;
using System.Data.Common;
using System.Data;

namespace RegisterBotanicGarden
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, Window> users = new Dictionary<string, Window>();
        public MainWindow()
        {
            InitializeComponent();
            DataBaseWorker.OpenConnection();
            users.Add("Admin", new AdminPanel(this));
            users.Add("User", new UserPanel1(this));
        }

        private void SigIn_Click(object sender, RoutedEventArgs e)
        {
            OleDbCommand command = new OleDbCommand($"SELECT Код_пользователя FROM Авторизация WHERE Логин = '{Login.Text}' AND Пароль = '{Password.Password}'", DataBaseWorker.connection);
            OleDbDataReader reader = command.ExecuteReader();

            if(reader.Read())
            {
                MessageBox.Show($"Доборо пожаловать, {new OleDbCommand($"SELECT Имя FROM Пользователь WHERE Код = {reader[0]}", DataBaseWorker.connection).ExecuteScalar()}", "Система", MessageBoxButton.OK, MessageBoxImage.Information);
                OleDbCommand command1 = new OleDbCommand($"SELECT Название FROM Должность WHERE Код = (SELECT Код_должности FROM Пользователь WHERE Код = {reader[0]})", DataBaseWorker.connection);

                users[command1.ExecuteScalar().ToString()].Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Система", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterForm1 register = new RegisterForm1();
            if(register.ShowDialog().Value)
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Пользователь", DataBaseWorker.connection);
                DataSet data = new DataSet();
                DataTable table = null;
                int iduser = -1;

                adapter.Fill(data);

                table = data.Tables[0];

                DataRow row = table.NewRow();

                iduser = table.Rows.Count + 1;
                row["Код"] = iduser;
                row["Имя"] = register.Person["Name"];
                row["Фамилия"] = register.Person["FName"];
                row["Отчество"] = register.Person["PName"];
                row["Дата_рождения"] = register.Person["Date"];
                row["Код_должности"] = 2;

                table.Rows.Add(row);

                OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
                adapter.Update(data);

                adapter.Dispose();
                adapter = new OleDbDataAdapter("SELECT * FROM Авторизация", DataBaseWorker.connection);

                data.Clear();
                adapter.Fill(data);

                table = data.Tables[0];

                row = table.NewRow();

                row["Код"] = table.Rows.Count + 1;
                row["Логин"] = register.Person["Login"];
                row["Пароль"] = register.Person["Password"];
                row["Код_пользователя"] = iduser;

                table.Rows.Add(row);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Update(data);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ((AdminPanel)users["Admin"]).ParentForm = null;
            ((UserPanel1)users["User"]).ParentForm = null;
            DataBaseWorker.CloseConnection();
            Application.Current.Shutdown();
        }
    }
}
