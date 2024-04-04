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

        public int Max { get; set; } = 10;
        public int IdPlace { get; set; } = -1;
        public AddFloversDialog(DataRow Before)
        {
            InitializeComponent();
            result = Before;

            DescriptionFlover.SelectedIndex = (int)result["Код_тип"];
            DescriptionSoft.SelectedIndex = (int)result["Код_ухода"];
            NumberFlover.Items.Add(result["Номер"]);
            StatusFlovewer.Text = result["Состояние"].ToString();
        }
        public AddFloversDialog()
        {
            InitializeComponent();

            for (int i = 1; i <= Max; i++)
                NumberFlover.Items.Add(i);

            foreach (DataRow i in TablesFlover.Tables["Растение"].Rows)
            {
                if (IdPlace == -1) break;
                if ((int)i["Код_грядки"] != IdPlace) continue;
                NumberFlover.Items.Remove(i["Номер"]);
            }

            NumberFlover.SelectedIndex = 0;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = DataBaseWorker.connection;

            foreach (string i in new string[] { "ТипРастения", "Уход", "Растение" })
            {
                cmd.CommandText = "SELECT * FROM " + i;
                TypeLoad.SelectCommand = cmd;

                TypeLoad.Fill(TablesFlover, i);
            }

            foreach (DataRow i in TablesFlover.Tables["ТипРастения"].Rows)
                DescriptionFlover.Items.Add(i["Вид"].ToString());

            foreach (DataRow i in TablesFlover.Tables["Уход"].Rows)
                DescriptionSoft.Items.Add(i["Наименование"].ToString());

            DescriptionSoft.SelectedIndex = 0;
        }
    }
}
