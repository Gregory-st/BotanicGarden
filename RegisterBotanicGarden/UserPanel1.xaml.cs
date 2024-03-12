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

namespace RegisterBotanicGarden
{
    /// <summary>
    /// Логика взаимодействия для UserPanel1.xaml
    /// </summary>
    public partial class UserPanel1 : Window
    {
        private Dictionary<string, UIElement> pairs = new Dictionary<string, UIElement>();
        string lastname = "Null";
        bool reversesize = false;
        int[] targetsize = new int[] { 200, 60 };

        public UserPanel1()
        {
            InitializeComponent();
            pairs.Add("Null", Info1);
            pairs.Add("PersonPage1", Persons1);
            pairs.Add("TasksPage1", Tasks1);

            foreach (var i in pairs)
                if (i.Key != "Null")
                    Content1.Children.Remove(i.Value);
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

            foreach (var i in new UIElement[] { PersonPage1, TasksPage1 })
            {
                if (reversesize) i.Visibility = Visibility.Visible;
                else i.Visibility = Visibility.Collapsed;
            }
        }
    }
}
