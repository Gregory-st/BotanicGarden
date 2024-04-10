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
        DataSet TablesFlover = new DataSet();
        public readonly Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
        int Max = 10;
        int IdPlace = -1;
        int FixedNumber = -1;
        public AddFloversDialog(DataRow Before, int max)
        {
            InitializeComponent();
            result = Before;

            Max = max;
            FixedNumber = (int)result["Номер"];
            IdPlace = (int)result["Код_грядки"];

            LoadWindow();

            DescriptionFlover.SelectedIndex = (int)result["Код_тип"];
            DescriptionSoft.SelectedIndex = (int)result["Код_ухода"];
            NumberFlover.SelectedItem = result["Номер"];
            StatusFlovewer.Text = result["Состояние"].ToString();
        }
        public AddFloversDialog(int max, int idplace)
        {
            InitializeComponent();

            Max = max;
            IdPlace = idplace;

            LoadWindow();

            NumberFlover.SelectedIndex = 0;
            DescriptionFlover.SelectedIndex = 0;
            DescriptionSoft.SelectedIndex = 0;
        }

        private void Done(object sender, RoutedEventArgs e)
        {
            bool error = false;
            for (int i = 0; i < InfoFlover.Children.Count; i++)
            {
                Border border = InfoFlover.Children[i] as Border;
                TextBox textBox = border.Child as TextBox;

                if (textBox.Text == "")
                {
                    border.Background = (Brush)new BrushConverter().ConvertFrom("#FFFF9595");
                    if (!error) error = true;
                }
                else
                {
                    border.Background = (Brush)new BrushConverter().ConvertFrom("#FFFFFDC4");
                }
            }

            for(int i = 0; i < InfoFlover1.Children.Count; i++)
            {
                Border border = InfoFlover1.Children[i] as Border;

                if (border.Visibility == Visibility.Collapsed) continue;

                TextBox textBox = border.Child as TextBox;
                ComboBox comboBox = border.Child as ComboBox;

                if(textBox != null)
                {
                    if (textBox.Text == "")
                    {
                        border.Background = (Brush)new BrushConverter().ConvertFrom("#FFFF9595");
                        if (!error) error = true;
                    }
                    else
                        border.Background = (Brush)new BrushConverter().ConvertFrom("#FFFFFDC4");
                }

                if(comboBox != null)
                {
                    if (comboBox.Text == "")
                    {
                        border.Background = (Brush)new BrushConverter().ConvertFrom("#FFFF9595");
                        if (!error) error = true;
                    }
                    else
                        border.Background = (Brush)new BrushConverter().ConvertFrom("#FFFFFDC4");
                }
            }

            if (error)
            {
                MessageBox.Show("Не все поля были заполнены", "Система", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            TypeLoad.SelectCommand.Dispose();
            OleDbCommand command = new OleDbCommand();
            DataSet addData = new DataSet();
            DataTable dataTable = null;
            DataRow row = null;
            OleDbCommandBuilder builder = null;
            int idsoft = DescriptionSoft.SelectedIndex;
            int idtypeflover = DescriptionFlover.SelectedIndex;

            command.Connection = DataBaseWorker.connection;

            if (DescriptionSoft.SelectedIndex == 0)
            {
                command.CommandText = "SELECT * FROM Уход";
                TypeLoad.SelectCommand = command;
                TextBox textBox = TypeSoft.Child as TextBox;

                TypeLoad.Fill(addData);
                dataTable = addData.Tables[0];
                idsoft = dataTable.Rows.Count + 1;

                row = dataTable.NewRow();
                row["Код"] = idsoft;
                row["Наименование"] = textBox.Text;
                dataTable.Rows.Add(row);

                builder = new OleDbCommandBuilder(TypeLoad);
                TypeLoad.Update(addData);

                row = null;
                addData.Dispose();
                addData = new DataSet();
                builder.Dispose();
            }

            if(DescriptionFlover.SelectedIndex == 0)
            {
                command.CommandText = "SELECT * FROM ТипРастения";
                TypeLoad.SelectCommand = command;

                TypeLoad.Fill(addData);
                dataTable = addData.Tables[0];
                idtypeflover = dataTable.Rows.Count + 1;

                row = dataTable.NewRow();
                row["Код"] = idtypeflover;

                for (int i = 0; i < InfoFlover.Children.Count; i++)
                {
                    Border border = InfoFlover.Children[i] as Border;
                    TextBox textBox = border.Child as TextBox;

                    row[i + 1] = textBox.Text.Trim(' ');
                }

                dataTable.Rows.Add(row);

                builder = new OleDbCommandBuilder(TypeLoad);
                TypeLoad.Update(addData);
            }

            keyValuePairs.Add("Код_тип", idtypeflover);
            keyValuePairs.Add("Код_ухода", idsoft);
            keyValuePairs.Add("Номер", NumberFlover.SelectedItem);
            keyValuePairs.Add("Состояние", StatusFlovewer.Text);

            if(result != null)
            {
                foreach (var i in keyValuePairs)
                    result[i.Key] = i.Value;
            }

            DialogResult = true;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Select_Flover(object sender, SelectionChangedEventArgs e)
        {
            for (int j = 0; j < InfoFlover.Children.Count; j++)
            {
                Border border = InfoFlover.Children[j] as Border;
                TextBox textBox = border.Child as TextBox;

                textBox.Text = "";
            }

            foreach (DataRow i in TablesFlover.Tables["ТипРастения"].Rows)
            {
                if (i["Вид"].ToString() != DescriptionFlover.SelectedItem.ToString()) continue;

                for (int j = 0; j < InfoFlover.Children.Count; j++)
                {
                    Border border = InfoFlover.Children[j] as Border;
                    TextBox textBox = border.Child as TextBox;

                    textBox.Text = i[j + 1].ToString();
                }
                break;
            }
        }

        private void Soft_Select(object sender, SelectionChangedEventArgs e) => TypeSoft.Visibility = (Visibility)(2 - Convert.ToInt32(DescriptionSoft.SelectedIndex == 0) * 2);

        private void LoadWindow()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = DataBaseWorker.connection;

            foreach (string i in new string[] { "ТипРастения", "Уход", "Растение" })
            {
                cmd.CommandText = "SELECT * FROM " + i;
                TypeLoad.SelectCommand = cmd;

                TypeLoad.Fill(TablesFlover, i);
            }

            for (int i = 1; i <= Max; i++)
                NumberFlover.Items.Add(i);

            foreach (DataRow i in TablesFlover.Tables["Растение"].Rows)
            {
                if (IdPlace == -1) break;
                if (!i["Код_грядки"].Equals(IdPlace) || i["Номер"].Equals(FixedNumber)) continue;
                NumberFlover.Items.Remove(i["Номер"]);
            }

            foreach (DataRow i in TablesFlover.Tables["ТипРастения"].Rows)
                DescriptionFlover.Items.Add(i["Вид"].ToString());

            foreach (DataRow i in TablesFlover.Tables["Уход"].Rows)
                DescriptionSoft.Items.Add(i["Наименование"].ToString());
        }
    }
}
