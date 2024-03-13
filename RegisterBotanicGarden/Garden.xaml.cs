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
    /// Логика взаимодействия для Garden.xaml
    /// </summary>
    public partial class Garden : Window
    {
        bool mousepress = false;
        Point mousePosition = new Point();
        public Garden()
        {
            InitializeComponent();
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
    }
}
