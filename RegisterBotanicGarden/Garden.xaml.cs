﻿using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
        Dictionary<string, OleDbDataAdapter> Grass = new Dictionary<string, OleDbDataAdapter>();
        public Garden()
        {
            InitializeComponent();
        }

        public Garden(int idroom)
        {
            InitializeComponent();

            this.idroom = idroom;

            UpdateData();
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
        private void UpdateData()
        {
            if(grass != null)
                grass.Dispose();

            if(Grass.Count > 0)
                Grass.Clear();

            grass = new DataSet();
            foreach (string i in new string[] { "Грядка", "Растение", "ТипРастения" })
            {
                Grass.Add(i, new OleDbDataAdapter("SELECT * FROM " + i, DataBaseWorker.connection));
                Grass[i].Fill(grass, i);
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
            System.Windows.Controls.Primitives.Popup context = ContentCell1.ContextMenu.Parent as System.Windows.Controls.Primitives.Popup;
            Grid cell = context.PlacementTarget as Grid;

            int idplace = int.Parse(cell.Name.Split('_')[2]);

            AddFloversDialog dialog = new AddFloversDialog(cell.ColumnDefinitions.Count * cell.RowDefinitions.Count, idplace);

            if(dialog.ShowDialog().Value)
            {
                DataTable table = grass.Tables["Растение"];
                DataRow row = table.NewRow();

                row["Код"] = table.Rows.Count + 1;
                row["Код_грядки"] = idplace;
                foreach(var i in dialog.keyValuePairs)
                    row[i.Key] = i.Value;

                table.Rows.Add(row);
                OleDbCommandBuilder builder = new OleDbCommandBuilder(Grass["Растение"]);
                Grass["Растение"].Update(grass, "Растение");

                UpdateData();
                UpDateCell(ref cell);
            }
        }

        private void RemoveFlovers(object sender, RoutedEventArgs e)
        {

        }

        private void FloverSelect1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FloverSelect1.SelectedIndex == -1) return;
            System.Windows.Controls.Primitives.Popup context = ContentCell1.ContextMenu.Parent as System.Windows.Controls.Primitives.Popup;
            Grid cell = context.PlacementTarget as Grid;

            AddFloversDialog dialog = null;

            int idplace = int.Parse(cell.Name.Split('_')[2]);

            DataTable table = grass.Tables["Растение"];
            string[] content = FloverSelect1.SelectedItem.ToString().Split();
            foreach (DataRow i in table.Rows)
            {
                if (!i["Номер"].Equals(content[1]) || !i["Код_грядки"].Equals(idplace)) continue;

                dialog = new AddFloversDialog(i, cell.RowDefinitions.Count * cell.ColumnDefinitions.Count);
                dialog.ShowDialog();
                break;
            }

            OleDbCommandBuilder builder = new OleDbCommandBuilder(Grass["Растение"]);
            Grass["Растение"].Update(grass, "Растение");

            UpdateData();
            UpDateCell(ref cell);
        }

        private void After_MouseEnter(object sender, MouseEventArgs e)
        {
            System.Windows.Controls.Primitives.Popup context = ContentCell1.ContextMenu.Parent as System.Windows.Controls.Primitives.Popup;
            Grid cell = context.PlacementTarget as Grid;

            foreach(StackPanel i in cell.Children)
                FloverSelect1.Items.Add(((TextBlock)i.Children[1]).Text);
        }

        private void After_MouseLeave(object sender, MouseEventArgs e)
        {
            FloverSelect1.SelectedIndex = -1;
            FloverSelect1.Items.Clear();
        }
    }
}
