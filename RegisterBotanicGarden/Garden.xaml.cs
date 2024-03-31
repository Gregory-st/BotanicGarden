using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace RegisterBotanicGarden
{
    /// <summary>
    /// Логика взаимодействия для Garden.xaml
    /// </summary>
    public partial class Garden : Window
    {
        bool mousepress = false;
        Point mousePosition = new Point();
        int idroom = -1;
        DataSet grass = null;
        public Garden()
        {
            InitializeComponent();
        }

        public Garden(int idroom, DataSet grass)
        {
            InitializeComponent();

            this.idroom = idroom;
            this.grass = grass;


        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mousepress = true;
            mousePosition = e.GetPosition((Grid)sender);
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e) => mousepress = false;

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if(mousepress)
            {
                Grid sen = (Grid)sender;
                Point val = e.GetPosition(sen);
                Thickness mar = sen.Margin;

                if (mar.Left + val.X - mousePosition.X <= 0 && mar.Left + val.X - mousePosition.X >= Contener1.DesiredSize.Width - sen.Width)
                    mar.Left += val.X - mousePosition.X;

                if(mar.Top + val.Y - mousePosition.Y <= 0 && mar.Top + val.Y - mousePosition.Y >= Contener1.DesiredSize.Height - sen.Height)
                    mar.Top += val.Y - mousePosition.Y;

                sen.Margin = mar;
            }
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e) => mousepress = false;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (idroom == -1 || grass == null) return;
            UpdateSpace1();
        }

        private void UpdateSpace1()
        {
            Space1.Children.Clear();

            DataTable dataTable = grass.Tables["Грядка"];
            DataTable dataTable1 = grass.Tables["Растение"];
            DataTable TypeGrass = grass.Tables["ТипРастения"];
            int x = 0;
            int y = 0;
            int index = 0;
            Border Cell = null;
            Grid Content = null;

            foreach (DataRow i in dataTable.Rows)
            {
                if ((int)i["Код_теплицы"] != idroom) continue;

                Cell = CopyElement.NBorder(Cell1);
                Content = CopyElement.NGrid(ContentCell1);

                Content.Name = $"C_{index}_{i["Код"]}";
                Content.ContextMenu = ContentCell1.ContextMenu;
                UpDateCell(ref Content);

                Cell.Child = Content;

                x = index;
                if(index >= Space1.ColumnDefinitions.Count)
                {
                    x = index % Space1.ColumnDefinitions.Count;
                    y = index / Space1.ColumnDefinitions.Count;
                }


                Grid.SetColumn(Cell, x);
                Grid.SetRow(Cell, y);
                Space1.Children.Add(Cell);

                index++;
            }
        }

        private void UpDateCell(ref Grid ContentCell)
        {
            ContentCell.Children.Clear();

            DataTable dataTable = grass.Tables["Растение"];
            DataTable TypeGrass = grass.Tables["ТипРастения"];

            int x = 0;
            int y = 0;
            int index = 0;
            int idtype = -1;
            string idcell = ContentCell.Name.Split('_')[2];

            StackPanel flover = null;
            foreach(DataRow i in dataTable.Rows)
            {
                if (i["Код_грядки"].ToString() != idcell) continue;

                flover = (StackPanel)CopyElement.NChild(Flover1);

                idtype = (int)i["Код_тип"] - 1;

                ((TextBlock)flover.Children[1]).Text = TypeGrass.Rows[idtype]["Вид"].ToString() + " " + i["Номер"].ToString();

                x = index;
                if (index >= ContentCell.ColumnDefinitions.Count)
                {
                    x = index % ContentCell.ColumnDefinitions.Count;
                    y = index / ContentCell.ColumnDefinitions.Count;
                }

                Grid.SetColumn(flover, x);
                Grid.SetRow(flover, y);

                ContentCell.Children.Add(flover);

                index++;
            }
        }

        private void AddCells(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveCells(object sender, RoutedEventArgs e)
        {

        }

        private void AddFlovers(object sender, RoutedEventArgs e)
        {
            AddFloversDialog dialog = new AddFloversDialog(null, true);
            dialog.ShowDialog();
        }

        private void AfterFlovers(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveFlovers(object sender, RoutedEventArgs e)
        {

        }
    }
}
