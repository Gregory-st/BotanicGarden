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
using System.Data.OleDb;
using System.Data;

namespace RegisterBotanicGarden
{
    /// <summary>
    /// Логика взаимодействия для UserDialog.xaml
    /// </summary>
    public partial class UserDialog : Window
    {
        DataRow user = null;
        public DataRow User => user;
        public UserDialog()
        {
            InitializeComponent();
        }
        public UserDialog(DataRow data, bool after)
        {
            InitializeComponent();
            user = data;
            UserRole1.IsEnabled = after;
            UserDate1.IsEnabled = after;
            if(after)
                AfterButton1.Visibility = Visibility.Visible;
            else 
                AfterButton1.Visibility = Visibility.Collapsed;
        }

        public UserDialog(DataRow newRow)
        {
            InitializeComponent();
            user = newRow;
            UserRole1.IsEnabled = true;
            UserDate1.IsEnabled = true;
            AfterButton1.Visibility = Visibility.Visible;
            AfterButton1.Content = "Создать";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Должность", DataBaseWorker.connection);
            DataSet data = new DataSet();
            DataTable table = null;

            adapter.Fill(data);
            table = data.Tables[0];

            foreach (DataRow i in table.Rows)
                UserRole1.Items.Add(i["Название"].ToString());

            if (user != null)
            {
                UserFName1.Text = user["Фамилия"].ToString();
                UserName1.Text = user["Имя"].ToString();
                UserPName1.Text = user["Отчество"].ToString();
                UserDate1.Text = user["Дата_рождения"].ToString().Split()[0];
                UserLogin1.Text = user["Логин"].ToString();
                UserPassword1.Text = user["Пароль"].ToString();

                UserRole1.SelectedItem = user["Название"];
            }
            UserPhoto1.Source = UriImage.GetImage("Profil1.png");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            user["Фамилия"] = UserFName1.Text;
            user["Имя"] = UserName1.Text;
            user["Отчество"] = UserPName1.Text;
            user["Дата_рождения"] = UserDate1.Text;
            user["Название"] = UserRole1.SelectedItem;
            user["Логин"] = UserLogin1.Text;
            user["Пароль"] = UserPassword1.Text;
            DialogResult = true;
        }

    }
}
