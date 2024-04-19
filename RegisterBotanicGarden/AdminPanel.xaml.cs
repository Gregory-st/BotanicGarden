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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.OleDb;
using System.Data;
using MaterialDesignThemes.Wpf;
using System.Runtime.Remoting.Messaging;
using DataBaseWorker;

namespace RegisterBotanicGarden
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        private Dictionary<string, UIElement> pairs = new Dictionary<string, UIElement>();
        private readonly Dictionary<string, Border> pattertask = new Dictionary<string, Border>(); 
        BitmapImage[] MainMenuIcon1 = new BitmapImage[] { UriImage.Images["Menu"], UriImage.Images["Back"] };
        public Window ParentForm { get; set; } = null;
        string lastname = "Null";
        int iduser = -1;
        bool reversesize = false;
        int[] targetsize = new int[] { 200, 60 };

        bool after = false;

        bool mousepress = false;
        Point mousePosition = new Point();

        OleDbDataAdapter Users = null;
        Dictionary<string, OleDbDataAdapter> GardenComplex = new Dictionary<string, OleDbDataAdapter>();

        public AdminPanel()
        {
            InitializeComponent();
        }
        public AdminPanel(Window perent, int iduser)
        {
            InitializeComponent();
            ParentForm = perent;
            this.iduser = iduser;
        }

        private void Pages_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (lastname == button.Name)
            {
                Content1.Children.Remove(pairs[lastname]);
                lastname = "Null";
                Content1.Children.Add(pairs[lastname]);
                return;
            }

            if (lastname != "")
                Content1.Children.Remove(pairs[lastname]);

            lastname = button.Name;

            Content1.Children.Add(pairs[lastname]);
        }

        private void Menu1_Click(object sender, RoutedEventArgs e)
        {
            var anim = new DoubleAnimation() { To = targetsize[Convert.ToInt32(reversesize)], Duration = TimeSpan.FromSeconds(0.5) };
            MenuContent1.BeginAnimation(Grid.WidthProperty, anim);

            reversesize = !reversesize;
            MainMenu1.Source = MainMenuIcon1[Convert.ToInt32(reversesize)];

            foreach (var i in new UIElement[] { PersonPage1, GardenPage1, InventoryPage1, TasksPage1 })
            {
                if (reversesize) i.Visibility = Visibility.Visible;
                else i.Visibility = Visibility.Collapsed;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ParentForm != null)
            {
                ParentForm.Show();
                ParentForm = null;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SearchImage1.Source = UriImage.Images["Search"];
            SearchImage2.Source = UriImage.Images["Search"];
            SearchImage3.Source = UriImage.Images["Search"];
            MainMenu1.Source = UriImage.Images["Menu"];
            ItemsInfo1.Source = UriImage.Images["Info"];
            ItemsDelete1.Source = UriImage.Images["Delete"];

            UpDataUsers();
            LoadGarden();
            UpdateHotCells();
            CellHot1.SelectedIndex = -1;
            HotRoomList1.Children.Clear();

            pairs.Add("Null", Info1);
            pairs.Add("PersonPage1", Persons1);
            pairs.Add("GardenPage1", Garden1);
            pairs.Add("InventoryPage1", Inventory1);
            pairs.Add("TasksPage1", Tasks1);

            pattertask.Add("Wait", TaskWait1);
            pattertask.Add("Active", TaskActive1);
            pattertask.Add("Failed", TaskFailed1);

            foreach (var i in pairs)
                if (i.Key != "Null")
                    Content1.Children.Remove(i.Value);
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mousepress = true;
            mousePosition = e.GetPosition((Grid)sender);
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e) => mousepress = false;

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousepress)
            {
                Grid sen = (Grid)sender;
                Point val = e.GetPosition(sen);
                Thickness mar = sen.Margin;

                if (mar.Left + val.X - mousePosition.X <= 0 && mar.Left + val.X - mousePosition.X >= Contener1.DesiredSize.Width - sen.Width)
                    mar.Left += val.X - mousePosition.X;

                if (mar.Top + val.Y - mousePosition.Y <= 0 && mar.Top + val.Y - mousePosition.Y >= Contener1.DesiredSize.Height - sen.Height)
                    mar.Top += val.Y - mousePosition.Y;

                sen.Margin = mar;
            }
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e) => mousepress = false;

        private void InfoUserEvent_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string[] substring = button.Name.Split('_');
            int id = Convert.ToInt32(substring[0].Substring(1, substring[0].Length - 1));
            DataSet data = new DataSet();
            Users.Fill(data);

            UserDialog userDialog1 = new UserDialog(data.Tables[0].Rows[id], after);

            if (userDialog1.ShowDialog().Value)
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter($"SELECT * FROM Пользователь WHERE Код = {substring[1]}", DataBaseWorker.connection);
                DataSet set = new DataSet();
                DataTable table = null;
                DataRow row = null;
                adapter.Fill(set);

                table = set.Tables[0];
                row = table.Rows[0];

                row["Имя"] = userDialog1.User["Имя"];
                row["Фамилия"] = userDialog1.User["Фамилия"];
                row["Отчество"] = userDialog1.User["Отчество"];
                row["Дата_рождения"] = userDialog1.User["Дата_рождения"];
                row["Код_должности"] = new OleDbCommand($"SELECT Код FROM Должность WHERE Название = '{userDialog1.User["Название"]}'", DataBaseWorker.connection).ExecuteScalar();

                OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
                adapter.Update(set);

                set.Clear();
                adapter = new OleDbDataAdapter($"SELECT * FROM Авторизация WHERE Код_пользователя = {substring[1]}", DataBaseWorker.connection);
                adapter.Fill(set);
                table = set.Tables[0];
                row = table.Rows[0];

                row["Логин"] = userDialog1.User["Логин"];
                row["Пароль"] = userDialog1.User["Пароль"];

                builder = new OleDbCommandBuilder(adapter);
                adapter.Update(set);

                UpDataUsers();
            }
        }

        private void AfterUserEvent_Click(object sender, RoutedEventArgs e)
        {
            after = true;
            InfoUserEvent_Click(sender, e);
            after = false;
        }

        private void DeleteUserEvent_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы уверены что хотите удалить данного пользователя?", "Система", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                Button button = (Button)sender;
                string[] substring = button.Name.Split('_');

                OleDbDataAdapter adapter = new OleDbDataAdapter($"SELECT * FROM Авторизация", DataBaseWorker.connection);
                DataSet data = new DataSet();
                DataTable table = null;

                adapter.Fill(data);
                table = data.Tables[0];

                for(int i = 0; i < table.Rows.Count; i++)
                    if (table.Rows[i]["Код_пользователя"].ToString() == substring[1])
                        table.Rows[i].Delete();

                OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
                adapter.Update(data);

                DataBaseWorker.RenumberId("Авторизация");

                data.Clear();
                adapter.Dispose();

                adapter = new OleDbDataAdapter($"SELECT * FROM Участок", DataBaseWorker.connection);

                adapter.Fill(data);
                table = data.Tables[0];

                for(int i = 0; i < table.Rows.Count; i++)
                {
                    if (table.Rows[i]["Код_пользователя"].ToString() != substring[1]) continue;
                    table.Rows[i]["Код_пользователя"] = Convert.DBNull;
                }

                builder = new OleDbCommandBuilder(adapter);
                adapter.Update(data);

                data.Clear();
                adapter.Dispose();

                adapter = new OleDbDataAdapter($"SELECT * FROM Пользователь", DataBaseWorker.connection);

                adapter.Fill(data);
                table = data.Tables[0];

                for(int i = 0; i < table.Rows.Count; i++)
                    if (table.Rows[i]["Код"].ToString() == substring[1])
                        table.Rows[i].Delete();

                builder = new OleDbCommandBuilder(adapter);
                adapter.Update(data);

                data.Clear();
                adapter.Dispose();

                DataBaseWorker.RenumberId("Пользователь");

                UpDataUsers();
            }
        }

        private void UpDataUsers()
        {
            UserList1.Children.Clear();

            UserPhoto1.Source = UriImage.GetImage("Profil1.png");

            Users = new OleDbDataAdapter($"SELECT * FROM Пользователи", DataBaseWorker.connection);
            DataSet dataSet = new DataSet();
            Users.Fill(dataSet);
            OleDbCommand command = new OleDbCommand();
            DataTable table = dataSet.Tables[0];
            int id = 0;

            command.Connection = DataBaseWorker.connection;

            InfoImage1.Source = UriImage.GetImage("Info1.png");
            AfterImage1.Source = UriImage.GetImage("After1.png");
            DeleteImage1.Source = UriImage.GetImage("Delete1.png");

            foreach (DataRow i in table.Rows)
            {
                UserFName1.Text = i["Фамилия"].ToString();
                UserName1.Text = i["Имя"].ToString();
                UserPName1.Text = i["Отчество"].ToString();
                UserRole1.Text = i["Название"].ToString();

                command.CommandText = $"SELECT Код FROM Пользователь WHERE Фамилия = '{i["Фамилия"]}' AND Имя = '{i["Имя"]}' AND Отчество = '{i["Отчество"]}'";

                Border board = CopyElement.NChild(ContenerUser1) as Border;
                Grid grid = (Grid)board.Child;
                grid = (Grid)grid.Children[grid.Children.Count - 1];
                Button info = (Button)grid.Children[0];
                Button after = (Button)grid.Children[1];
                Button delete = (Button)grid.Children[2];

                info.Click += InfoUserEvent_Click;
                info.Name = "b" + id.ToString() + "_" + command.ExecuteScalar();

                after.Click += AfterUserEvent_Click;
                after.Name = "b" + id.ToString() + "_" + command.ExecuteScalar();

                delete.Click += DeleteUserEvent_Click;
                delete.Name = "b" + id.ToString() + "_" + command.ExecuteScalar();

                UserList1.Children.Add(board);
                id++;
            }
        }
        private void UpdateHotCells()
        {
            for (int i = 1; i < CellHot1.Items.Count; i++)
                CellHot1.Items.RemoveAt(i);

            DataSet HotRooms = new DataSet();

            GardenComplex["Участок"].Fill(HotRooms);

            DataTable table = HotRooms.Tables[0];

            foreach (DataRow i in table.Rows)
                CellHot1.Items.Add(i["Название"]);
        }
        private void UpDateHotRoom()
        {
            HotRoomList1.Children.Clear();

            DataSet HotRooms = new DataSet();

            GardenComplex["Теплица"].Fill(HotRooms, "Теплица");

            DataTable rooms1 = HotRooms.Tables[0];
            int coderoom = CellHot1.SelectedIndex;
            int index = 0;
            int x = 0;
            int y = 0;
            Button hotroom = null;
            foreach (DataRow i in rooms1.Rows)
            {
                if ((int)i["Код_участка"] != coderoom) continue;

                hotroom = CopyElement.NButton(Teplit1);
                hotroom.Content = $"{i["Наименовние"]} {i["Номер"]}";
                hotroom.Name = $"h_{index}_{i["Код"]}";
                ButtonAssist.SetCornerRadius(hotroom, ButtonAssist.GetCornerRadius(Teplit1));
                hotroom.Click += Teplit1_Click;

                x = index;
                if (index >= HotRoomList1.ColumnDefinitions.Count)
                {
                    x = index % HotRoomList1.ColumnDefinitions.Count;
                    y = index / HotRoomList1.ColumnDefinitions.Count;
                }

                Grid.SetColumn(hotroom, x);
                Grid.SetRow(hotroom, y);

                HotRoomList1.Children.Add(hotroom);
                index++;
            }
        }
        private void UpdateTaskList()
        {
            TaskListing1.Children.Clear();

            DataBaseApplication application = new DataBaseApplication();
            application.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Ботанический_сад.accdb";

            DataTable table = application.GetDataTable("Стоп_лист");

            foreach (DataRow row in table.Rows)
            {

            }
        }
        private void LoadGarden()
        {
            string commandskil = "SELECT * FROM ";
            foreach (var i in new string[] { "Участок", "Теплица", "Грядка", "Растение", "ТипРастения", "Уход" })
                GardenComplex.Add(i, new OleDbDataAdapter(commandskil + i, DataBaseWorker.connection));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataSet data = new DataSet();
            Users.Fill(data);

            DataTable table = data.Tables[0];
            DataRow row = table.NewRow();

            UserDialog userDialog1 = new UserDialog(row);

            if(userDialog1.ShowDialog().Value)
            {
                row = userDialog1.User;

                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Пользователь", DataBaseWorker.connection);
                DataSet data1 = new DataSet();
                DataTable table1 = null;
                DataRow row1 = null;
                int id = -1;

                adapter.Fill(data1);
                table1 = data1.Tables[0];
                row1 = table1.NewRow();

                id = table1.Rows.Count + 1;

                row1["Код"] = id;
                row1["Имя"] = row["Имя"];
                row1["Фамилия"] = row["Фамилия"];
                row1["Отчество"] = row["Отчество"];
                row1["Дата_рождения"] = row["Дата_рождения"];
                row1["Код_должности"] = new OleDbCommand($"SELECT Код FROM Должность WHERE Название = '{row["Название"]}'", DataBaseWorker.connection).ExecuteScalar();

                table1.Rows.Add(row1);

                OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
                adapter.Update(data1);

                data1.Clear();
                adapter.Dispose();

                adapter = new OleDbDataAdapter("SELECT * FROM Авторизация", DataBaseWorker.connection);
                adapter.Fill(data1);

                table1 = data1.Tables[0];
                row1 = table1.NewRow();

                row1["Код"] = table1.Rows.Count + 1;
                row1["Логин"] = row["Логин"];
                row1["Пароль"] = row["Пароль"];
                row1["Код_пользователя"] = id;

                table1.Rows.Add(row1);

                builder = new OleDbCommandBuilder(adapter);
                adapter.Update(data1);

                UpDataUsers();
            }
        }

        private void SearchButton1_Click(object sender, RoutedEventArgs e)
        {
            string line = SearchLine1.Text;
            int id = 0;
            if (line == "")
            {
                UpDataUsers();
                return;
            }

            DataSet data = new DataSet();
            OleDbCommand command = new OleDbCommand();
            DataTable table = null;
            string[] arraydata;
            bool exist = false;

            Users.Fill(data);
            table = data.Tables[0];

            UserList1.Children.Clear();
            command.Connection = DataBaseWorker.connection;
            foreach (DataRow i in table.Rows)
            {
                arraydata = new string[] 
                { 
                    i["Фамилия"].ToString(),
                    i["Имя"].ToString(),
                    i["Отчество"].ToString(),
                    i["Название"].ToString()
                };
                foreach (string j in arraydata)
                {
                    exist = j.IndexOf(line) != -1;
                    if (exist) break;
                }

                if (exist)
                {
                    UserFName1.Text = i["Фамилия"].ToString();
                    UserName1.Text = i["Имя"].ToString();
                    UserPName1.Text = i["Отчество"].ToString();
                    UserRole1.Text = i["Название"].ToString();

                    command.CommandText = $"SELECT Код FROM Пользователь WHERE Фамилия = '{i["Фамилия"]}' AND Имя = '{i["Имя"]}' AND Отчество = '{i["Отчество"]}'";

                    Border board = CopyElement.NChild(ContenerUser1) as Border;
                    Grid grid = (Grid)board.Child;
                    grid = (Grid)grid.Children[grid.Children.Count - 1];
                    Button info = (Button)grid.Children[0];
                    Button after = (Button)grid.Children[1];
                    Button delete = (Button)grid.Children[2];

                    info.Click += InfoUserEvent_Click;
                    info.Name = "b" + id.ToString() + "_" + command.ExecuteScalar();

                    after.Click += AfterUserEvent_Click;
                    after.Name = "b" + id.ToString() + "_" + command.ExecuteScalar();

                    delete.Click += DeleteUserEvent_Click;
                    delete.Name = "b" + id.ToString() + "_" + command.ExecuteScalar();

                    UserList1.Children.Add(board);
                }
                id++;
            }

        }

        private void AddWaitItem_Click(object sender, RoutedEventArgs e)
        {
            ItemDialog item = new ItemDialog();
            item.Show();
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            AddItemDialog dialog = new AddItemDialog();
            dialog.Show();
        }

        private void AddTask1_Click(object sender, RoutedEventArgs e)
        {
            AddTaskDialog addTask = new AddTaskDialog(iduser);
            
            if(addTask.ShowDialog().Value)
            {

            }
        }

        private void InfoItem1_Click(object sender, RoutedEventArgs e)
        {
            InfoItem info = new InfoItem();
            info.Show();
        }

        private void Teplit1_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            int idroom = Convert.ToInt32(b.Name.Split('_')[2]);
            DataSet dataSets = new DataSet();

            GardenComplex["Грядка"].Fill(dataSets, "Грядка");
            GardenComplex["Растение"].Fill(dataSets, "Растение");
            GardenComplex["ТипРастения"].Fill(dataSets, "ТипРастения");

            Garden garden = new Garden(idroom);
            garden.Show();
        }

        private void RoomAdd1_Click(object sender, RoutedEventArgs e)
        {
            DataSet data = new DataSet();
            GardenComplex["Теплица"].Fill(data);

            DataRow row = data.Tables[0].NewRow();

            int id = data.Tables[0].Rows.Count + 1; 
            int max = HotRoomList1.ColumnDefinitions.Count * HotRoomList1.RowDefinitions.Count;

            AddRooms rooms = new AddRooms(row, max, CellHot1.SelectedIndex);

            if(rooms.ShowDialog().Value)
            {
                row["Код"] = id;

                data.Tables[0].Rows.Add(row);

                OleDbCommandBuilder builder = new OleDbCommandBuilder(GardenComplex["Теплица"]);
                GardenComplex["Теплица"].Update(data);
                builder.Dispose();

                UpDateHotRoom();
            }
        }

        private void RoomRemove1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RoomRemove1.SelectedIndex == -1) return;

            DataSet data = new DataSet();
            DataTable table = null;

            GardenComplex["Теплица"].Fill(data);
            table = data.Tables[0];
            string[] target = RoomRemove1.SelectedItem.ToString().Split();
            int id = -1;
            foreach(DataRow i in table.Rows)
            {
                if (i["Наименовние"].ToString() != target[0] || i["Номер"].ToString() != target[1]) continue;
                id = (int)i[0];
            }

            RemoveRowTable(new string[] { "Теплица", "Грядка", "Растение" }, new string[] { "Код", "Код_теплицы", "Код_грядки" }, id, 0);
            UpDateHotRoom();
        }

        private void CellHot1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CellHot1.SelectedIndex == 0)
            {
                AddPlaceDialog dialog = new AddPlaceDialog();
                if(dialog.ShowDialog().Value)
                {
                    DataSet data = new DataSet();
                    DataTable table = null;

                    GardenComplex["Участок"].Fill(data);
                    table = data.Tables[0];

                    DataRow row = table.NewRow();
                    int id = table.Rows.Count + 1;

                    row["Код"] = id;
                    row["Название"] = dialog.NamePlace;
                    row["Код_пользователя"] = dialog.IdUser;

                    table.Rows.Add(row);

                    OleDbCommandBuilder builder = new OleDbCommandBuilder(GardenComplex["Участок"]);
                    GardenComplex["Участок"].Update(table);

                    UpdateHotCells();
                    CellHot1.SelectedIndex = CellHot1.Items.Count - 1;
                    return;
                }
                else
                {
                    CellHot1.SelectedIndex = -1;
                    return;
                }
            }
            UpDateHotRoom();
        }

        private void RoomRemove2_MouseLeave(object sender, MouseEventArgs e) => RoomRemove1.Items.Clear();

        private void RoomRemove2_MouseEnter(object sender, MouseEventArgs e)
        {
            foreach(UIElement i in HotRoomList1.Children)
            {
                if(i is Button button)
                    RoomRemove1.Items.Add(button.Content);
            }
        }

        private void RemoveRowTable(string[] TableName, string[] ParamsName, int Param, int step)
        {
            DataSet data = new DataSet();
            DataTable table = null;

            GardenComplex[TableName[step]].Fill(data);
            table = data.Tables[0];

            foreach(DataRow i in table.Rows)
            {
                if ((int)i[ParamsName[step]] != Param) continue;

                if (step < TableName.Length - 1)
                {
                    RemoveRowTable(TableName, ParamsName, (int)i[0], step + 1);
                    i.Delete();
                }
                else
                {
                    i.Delete();
                }
            }

            OleDbCommandBuilder builder = new OleDbCommandBuilder(GardenComplex[TableName[step]]);
            GardenComplex[TableName[step]].Update(data);

            DataBaseWorker.RenumberId(TableName[step]);
        }


    }
}
