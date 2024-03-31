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
    /// Логика взаимодействия для AddFloversDialog.xaml
    /// </summary>
    public partial class AddFloversDialog : Window
    {
        DataRow result = null;
        OleDbDataAdapter TypeLoad = new OleDbDataAdapter();
        DataSet Tables = new DataSet();

        public AddFloversDialog(DataRow ModeAdd, bool editmode)
        {
            InitializeComponent();
            result = ModeAdd;
            
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = DataBaseWorker.connection;

            foreach(string i in new string[] { "ТипРастения", "Уход" })
            {
                cmd.CommandText = "SELECT * FROM " + i;
                TypeLoad.SelectCommand = cmd;

                TypeLoad.Fill(Tables, i);
            }

            foreach(DataRow i in Tables.Tables["ТипРастения"].Rows)
                DescriptionFlover.Items.Add(i["Вид"].ToString());

            foreach (DataRow i in Tables.Tables["Уход"].Rows)
                DescriptionSoft.Items.Add(i["Наименование"].ToString());

            if (editmode)
            {

                return;
            }


        }

        private void Done(object sender, RoutedEventArgs e)
        {

            DialogResult = true;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
