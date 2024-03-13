﻿using System;
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
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        private Dictionary<string, UIElement> pairs = new Dictionary<string, UIElement>();
        public Window ParentForm { get; set; } = null;
        string lastname = "Null";
        bool reversesize = false;
        int[] targetsize = new int[] { 200, 60 };

        public AdminPanel()
        {
            InitializeComponent();
        }
        public AdminPanel(Window perent)
        {
            InitializeComponent();
            ParentForm = perent;
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

            foreach (var i in new UIElement[] { PersonPage1, GardenPage1, InventoryPage1, TasksPage1 })
            {
                if (reversesize) i.Visibility = Visibility.Visible;
                else i.Visibility = Visibility.Collapsed;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(ParentForm != null)
                 ParentForm.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            pairs.Add("Null", Info1);
            pairs.Add("PersonPage1", Persons1);
            pairs.Add("GardenPage1", Garden1);
            pairs.Add("InventoryPage1", Inventory1);
            pairs.Add("TasksPage1", Tasks1);

            foreach (var i in pairs)
                if (i.Key != "Null")
                    Content1.Children.Remove(i.Value);
        }
    }
}
