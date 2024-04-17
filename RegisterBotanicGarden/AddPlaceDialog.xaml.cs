using System.Windows;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System;

namespace RegisterBotanicGarden
{
    /// <summary>
    /// Логика взаимодействия для AddPlaceDialog.xaml
    /// </summary>
    public partial class AddPlaceDialog : Window
    {
        public string NamePlace => NamePlace1.Text;
        public int IdUser => Convert.ToInt32(User1.SelectedItem.ToString().Split().Last());
        public AddPlaceDialog()
        {
            InitializeComponent();

            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Пользователи", DataBaseWorker.connection);
            DataSet data = new DataSet();
            DataTable table = null;

            adapter.Fill(data);
            table = data.Tables[0];

            foreach(DataRow i in table.Rows)
                User1.Items.Add($"{i["Фамилия"]} {i["Имя"]} {i[0]}");
            User1.SelectedIndex = 0;
        }

        private void Done_Click(object sender, RoutedEventArgs e) => DialogResult = true;
        private void Cancel_Click(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}
