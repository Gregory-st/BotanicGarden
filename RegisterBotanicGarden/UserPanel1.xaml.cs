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

namespace RegisterBotanicGarden
{
    /// <summary>
    /// Логика взаимодействия для UserPanel1.xaml
    /// </summary>
    public partial class UserPanel1 : Window
    {
        private Dictionary<string, UIElement> pairs = new Dictionary<string, UIElement>();
        public Window ParentForm { get; set; } = null;
        string lastname = "Null";
        bool reversesize = false;
        int[] targetsize = new int[] { 200, 60 };

        BitmapImage[] MainMenuIcon = new BitmapImage[] { UriImage.GetImage("Menu1.png"), UriImage.GetImage("Back1.png") };

        DataRow user = null;

        public UserPanel1()
        {
            InitializeComponent();
        }

        public UserPanel1(Window parent, DataRow user)
        {
            InitializeComponent();
            ParentForm = parent;
            this.user = user;
        }

        private void Pages_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
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
            MainMenu1.Source = MainMenuIcon[Convert.ToInt32(reversesize)];
            foreach (var i in new UIElement[] { PersonPage1, TasksPage1 })
            {
                if (reversesize) i.Visibility = Visibility.Visible;
                else i.Visibility = Visibility.Collapsed;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PersonPhoto1.Source = UriImage.GetImage("Profil1.png");
            SearchImage1.Source = UriImage.GetImage("Search1.png");
            MainMenu1.Source = UriImage.GetImage("Menu1.png");

            PersonName1.Text = user["Имя"].ToString();
            PersonFName1.Text = user["Фамилия"].ToString();
            PersonPName1.Text = user["Отчество"].ToString();
            PersonDate1.Text = user["Дата_рождения"].ToString().Split()[0];
            PersonRole1.Text = user["Название"].ToString();
            PersonLogin1.Text = user["Логин"].ToString();
            PersonPassword1.Text = user["Пароль"].ToString();

            pairs.Add("Null", Info1);
            pairs.Add("PersonPage1", Persons1);
            pairs.Add("TasksPage1", Tasks1);

            foreach (var i in pairs)
                if (i.Key != "Null")
                    Content1.Children.Remove(i.Value);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ParentForm != null)
            {
                ParentForm.Show();
                ParentForm = null;
            }
        }
    }
}
