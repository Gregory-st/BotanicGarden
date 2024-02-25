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

namespace RegisterBotanicGarden
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        private Dictionary<string, UIElement> pairs = new Dictionary<string, UIElement>();
        string lastname = "Null";

        public AdminPanel()
        {
            InitializeComponent();

            pairs.Add("Null", Info1);
            pairs.Add("PersonPage1", Persons1);
            pairs.Add("GardenPage1", Garden1);
            pairs.Add("InventoryPage1", Inventory1);
            pairs.Add("TasksPage1", Tasks1);

            foreach (var i in pairs)
                if(i.Key != "Null")
                    Content1.Children.Remove(i.Value);
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
    }
}
