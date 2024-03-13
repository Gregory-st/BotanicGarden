using MaterialDesignThemes.Wpf;
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
    /// Логика взаимодействия для RegisterForm1.xaml
    /// </summary>
    public partial class RegisterForm1 : Window
    {
        bool click = false;
        string[,] names = new string[,]
        {
            { "Отмена", "Далее" },
            { "Назад", "Готово" }
        };

        public Dictionary<string, string> Person { get; } = new Dictionary<string, string>()
        {
            { "FName", "" },
            { "Name", "" },
            { "PName", "" },
            { "Date", "" },
            { "Login", "" },
            { "Password", "" }
        };

        public RegisterForm1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel1_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if(button.Content.ToString() == names[0, 0])
            {
                this.DialogResult = false;
                return;
            }

            foreach (Border i in Content1.Children)
                i.Visibility = i.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;

            click = !click;

            button.Content = names[Convert.ToInt32(click), 0];
            Next1.Content = names[Convert.ToInt32(click), 1];
        }

        private void Next1_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            bool errorGlobal = false;
            bool errorLocal = false;

            foreach (var i in new UIElement[] { FName, PersonName1, DateBorn1, Login1, Password1, Password2 })
            {
                TextBox textbox = i as TextBox;
                DatePicker datePicker = i as DatePicker;

                if (textbox != null)
                {
                    if (((Border)textbox.Parent).Visibility != Visibility.Visible) continue;
                    errorLocal = textbox.Text == "";

                    if (errorLocal) textbox.BorderBrush = new SolidColorBrush(Colors.Blue);
                    else textbox.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#89000000");
                }
                else if (datePicker != null)
                {
                    if (((Border)datePicker.Parent).Visibility != Visibility.Visible) continue;
                    errorLocal = datePicker.Text == "";

                    if (errorLocal) datePicker.BorderBrush = new SolidColorBrush(Colors.Blue);
                    else datePicker.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#89000000");
                }

                if (errorLocal) errorGlobal = true;
            }

            if (errorGlobal)
            {
                MessageBox.Show("Не все поля были заполнены", "Система", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                if (Password1.Text != Password2.Text)
                {
                    MessageBox.Show("Пароли не совпадают", "Система", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            if (button.Content.ToString() == names[1, 1])
            {
                Person["FName"] = FName.Text;
                Person["Name"] = PersonName1.Text;
                Person["PName"] = PatherName1.Text;
                Person["Date"] = DateBorn1.Text;
                Person["Login"] = Login1.Text;
                Person["Password"] = Password1.Text;
                this.DialogResult = true;
                return;
            }

            foreach (Border i in Content1.Children)
                i.Visibility = i.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;

            click = !click;

            button.Content = names[Convert.ToInt32(click), 1];
            Cancel1.Content = names[Convert.ToInt32(click), 0];
        }
    }
}
