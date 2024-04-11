using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Data.OleDb;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegisterBotanicGarden
{
    /// <summary>
    /// Логика взаимодействия для AddRooms.xaml
    /// </summary>
    public partial class AddRooms : Window
    {
        DataRow result = null;
        public AddRooms(DataRow row, int Max, int idPlace)
        {
            InitializeComponent();
            result = row;

            result["Код_участка"] = idPlace;

            OleDbDataAdapter adapter = new OleDbDataAdapter($"SELECT Номер FROM Теплица WHERE Код_участка = {idPlace}", DataBaseWorker.connection);
            DataSet data = new DataSet();
            adapter.Fill(data);

            for (int i = 1; i <= Max; i++)
                Number1.Items.Add(i);

            foreach (DataRow i in data.Tables[0].Rows)
                Number1.Items.Remove(i[0]);

            Number1.SelectedIndex = 0;
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            if(Name1.Text == "")
            {
                MessageBox.Show("Не все поля были заполнены", "Система", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            result["Наименовние"] = Name1.Text;
            result["Номер"] = (int)Number1.SelectedItem;

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}
