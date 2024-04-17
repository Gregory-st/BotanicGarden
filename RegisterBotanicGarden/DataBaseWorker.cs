using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Data.OleDb;
using System.Data;
using MaterialDesignThemes.Wpf;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;

namespace RegisterBotanicGarden
{

    static class DataBaseWorker
    {
        public static OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Ботанический_сад.accdb");

        public static void OpenConnection() => connection.OpenAsync();
        public static void CloseConnection() => connection.Close();

        public static void RenumberId(string NameDataTable)
        {
            bool connectionisopen = connection.State == ConnectionState.Open;

            if(!connectionisopen) OpenConnection();

            OleDbDataAdapter adapter = new OleDbDataAdapter($"SELECT * FROM {NameDataTable}", connection);
            DataSet data = new DataSet();
            DataTable table = null;
            adapter.Fill(data);

            table = data.Tables[0];
            for(int i = 0; i < table.Rows.Count; i++)
            {
                if ((int)table.Rows[i]["Код"] == (i + 1)) continue;
                table.Rows[i]["Код"] = i + 1;
            }

            OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
            adapter.Update(data);

            if(!connectionisopen) CloseConnection();
        }
    }

    static class Users
    {
        private static AdminPanel admin = new AdminPanel();
        private static UserPanel1 user = new UserPanel1();
        public static readonly Dictionary<string, Window> User = new Dictionary<string, Window>() 
        {
            { "Admin", new AdminPanel() },
            { "User", new UserPanel1() }
        };
    }

    static class CopyElement
    {
        public static Border NBorder(Border prototype) => new Border()
        {
            Margin = prototype.Margin,
            Padding = prototype.Padding,
            Width = prototype.Width,
            Height = prototype.Height,
            RenderSize = prototype.RenderSize,
            MinHeight = prototype.MinHeight,
            MinWidth = prototype.MinWidth,
            MaxHeight = prototype.MaxHeight,
            MaxWidth = prototype.MaxWidth,
            BorderBrush = prototype.BorderBrush,
            BorderThickness = prototype.BorderThickness,
            Background = prototype.Background,
            CornerRadius = prototype.CornerRadius,
            VerticalAlignment = prototype.VerticalAlignment,
            HorizontalAlignment = prototype.HorizontalAlignment
        };

        public static Grid NGrid(Grid prototype)
        {
            Grid result = new Grid()
            {
                Margin = prototype.Margin,
                Width = prototype.Width,
                Height = prototype.Height,
                RenderSize = prototype.RenderSize,
                MaxWidth = prototype.MaxWidth,
                MinWidth = prototype.MinWidth,
                MaxHeight = prototype.MaxHeight,
                MinHeight = prototype.MinHeight,
                Background = prototype.Background,
                VerticalAlignment = prototype.VerticalAlignment,
                HorizontalAlignment = prototype.HorizontalAlignment         
            };

            if (prototype.ColumnDefinitions.Count > 0)
                for (int i = 0; i < prototype.ColumnDefinitions.Count; i++)
                {
                    result.ColumnDefinitions.Add(new ColumnDefinition());
                    result.ColumnDefinitions[i].Width = prototype.ColumnDefinitions[i].Width;
                    result.ColumnDefinitions[i].MaxWidth = prototype.ColumnDefinitions[i].MaxWidth;
                    result.ColumnDefinitions[i].MinWidth = prototype.ColumnDefinitions[i].MinWidth;
                }

            if (prototype.RowDefinitions.Count > 0)
                for (int i = 0; i < prototype.RowDefinitions.Count; i++)
                {
                    result.RowDefinitions.Add(new RowDefinition());
                    result.RowDefinitions[i].Height = prototype.RowDefinitions[i].Height;
                    result.RowDefinitions[i].MaxHeight = prototype.RowDefinitions[i].MaxHeight;
                    result.RowDefinitions[i].MinHeight = prototype.RowDefinitions[i].MinHeight;
                }

            return result;
        }

        public static StackPanel NStackPanel(StackPanel prototype) => new StackPanel()
        {
            Margin = prototype.Margin,
            Width = prototype.Width,
            Height = prototype.Height,
            RenderSize = prototype.RenderSize,
            MaxWidth = prototype.MaxWidth,
            MinWidth = prototype.MinWidth,
            MaxHeight = prototype.MaxHeight,
            MinHeight = prototype.MinHeight,
            Background = prototype.Background,
            Orientation = prototype.Orientation,
            VerticalAlignment = prototype.VerticalAlignment,
            HorizontalAlignment = prototype.HorizontalAlignment
        };

        public static Button NButton(Button prototype)
        {
            Button result = new Button()
            {
                Margin = prototype.Margin,
                Padding = prototype.Padding,
                Width = prototype.Width,
                MinWidth = prototype.MinWidth,
                MaxWidth = prototype.MaxWidth,
                Height = prototype.Height,
                MinHeight = prototype.MinHeight,
                MaxHeight = prototype.MaxHeight,
                RenderSize = prototype.RenderSize,
                Style = prototype.Style,
                Background = prototype.Background,
                BorderBrush = prototype.BorderBrush,
                BorderThickness = prototype.BorderThickness,
                FontFamily = prototype.FontFamily,
                FontSize = prototype.FontSize,
                Foreground = prototype.Foreground
            };

            ButtonAssist.SetCornerRadius(result, ButtonAssist.GetCornerRadius(prototype));

            if (prototype.Content is Image)
                result.Content = NImage((Image)prototype.Content);
            else 
                result.Content = prototype.Content;

            return result;
        }

        public static TextBox NTextBox(TextBox prototype)
        {
            TextBox result = new TextBox()
            {
                Margin = prototype.Margin,
                Padding = prototype.Padding,
                Width = prototype.Width,
                Height = prototype.Height,
                RenderSize = prototype.RenderSize,
                Foreground = prototype.Foreground,
                Style = prototype.Style,
                Background = prototype.Background,
                BorderBrush = prototype.BorderBrush,
                BorderThickness = prototype.BorderThickness,
                FontFamily = prototype.FontFamily,
                FontSize = prototype.FontSize
            };

            HintAssist.SetHint(result, HintAssist.GetHint(prototype));
            HintAssist.SetForeground(result, HintAssist.GetForeground(prototype));
            TextFieldAssist.SetUnderlineBrush(result, TextFieldAssist.GetUnderlineBrush(prototype));

            return result;
        }

        public static TextBlock NTextBlock(TextBlock prototype) => new TextBlock()
        {
            Margin = prototype.Margin,
            Padding = prototype.Padding,
            Width = prototype.Width,
            Height = prototype.Height,
            RenderSize = prototype.RenderSize,
            TextAlignment = prototype.TextAlignment,
            TextWrapping = prototype.TextWrapping,  
            VerticalAlignment = prototype.VerticalAlignment,
            HorizontalAlignment = prototype.HorizontalAlignment,
            Text = prototype.Text,
            Background = prototype.Background,
            Foreground = prototype.Foreground,
            FontFamily = prototype.FontFamily,
            FontSize = prototype.FontSize,
            TextDecorations = prototype.TextDecorations,
            FontWeight = prototype.FontWeight,
            Style = prototype.Style
        };

        public static Image NImage(Image prototype) => new Image()
        { 
            Source = prototype.Source,
            Margin = prototype.Margin,
            Width = prototype.Width,
            Height = prototype.Height,
            RenderSize = prototype.RenderSize,
            StretchDirection = prototype.StretchDirection,
            Stretch = prototype.Stretch
        };

        public static DockPanel NDockPanel(DockPanel prototype) => new DockPanel()
        {
            Margin = prototype.Margin,
            Width = prototype.Width,
            Height = prototype.Height,
            RenderSize = prototype.RenderSize,
            MaxWidth = prototype.MaxWidth,
            MinWidth = prototype.MinWidth,
            MaxHeight = prototype.MaxHeight,
            MinHeight = prototype.MinHeight,
            Background = prototype.Background,
            LastChildFill = prototype.LastChildFill,
            VerticalAlignment = prototype.VerticalAlignment,
            HorizontalAlignment = prototype.HorizontalAlignment
        };

        public static UIElement NChild(UIElement parent)
        {
            UIElement result = null;
            if (parent is TextBox)
                return NTextBox((TextBox)parent);
            else if (parent is TextBlock)
                return NTextBlock((TextBlock)parent);
            else if (parent is Image)
                return NImage((Image)parent);
            else if (parent is Button)
                return NButton((Button)parent);
            else if (parent is Border)
            {
                result = NBorder((Border)parent);
                ((Border)result).Child = NChild(((Border)parent).Child);
                return (Border)result;
            }
            else if (parent is Grid)
            {
                result = NGrid((Grid)parent);
                Grid grid = (Grid)result;
                UIElement element = null;
                foreach (UIElement i in ((Grid)parent).Children)
                {
                    element = NChild(i);
                    grid.Children.Add(element);

                    Grid.SetColumn(element, Grid.GetColumn(i));
                    Grid.SetRow(element, Grid.GetRow(i));
                }
                return grid;
            }
            else if (parent is StackPanel)
            {
                result = NStackPanel((StackPanel)parent);
                StackPanel stack = (StackPanel)result;
                foreach (UIElement i in ((StackPanel)parent).Children)
                    stack.Children.Add(NChild(i));
                return stack;
            }
            else if(parent is DockPanel dock)
            {
                result = NDockPanel(dock);
                DockPanel dockPanel = (DockPanel)result;
                UIElement element = null;
                foreach (UIElement i in dock.Children)
                {
                    element = NChild(i);
                    dockPanel.Children.Add(element);
                    DockPanel.SetDock(element, DockPanel.GetDock(i));
                }
                return dockPanel;
            }

            return result;
        }

        public static Border NChildBorder(Border parent)
        {
            Border result = NBorder(parent);
            if(parent.Child is Border)
                result.Child = NChildBorder((Border)parent.Child);
            else if(parent.Child is Grid)
                result.Child = NChildGrid((Grid)parent.Child);
            else if (parent.Child is StackPanel)
                result.Child = NChildStackPanel((StackPanel)parent.Child);
            else if(parent.Child is TextBox)
                    result.Child = NTextBox((TextBox)parent.Child);
            else if (parent.Child is TextBlock)
                result.Child = NTextBlock((TextBlock)parent.Child);
            else if (parent.Child is Image)
                result.Child = NImage((Image)parent.Child);
            else if (parent.Child is Button)
                result.Child = NButton((Button)parent.Child);
            return result;
        }

        public static Grid NChildGrid(Grid parent)
        {
            Grid result = NGrid(parent);
            
            foreach(var i in parent.Children)
            {
                if (i is TextBox)
                    result.Children.Add(NTextBox((TextBox)i));
                else if (i is TextBlock)
                    result.Children.Add(NTextBlock((TextBlock)i));
                else if (i is Image)
                    result.Children.Add(NImage((Image)i));
                else if (i is Button)
                    result.Children.Add(NButton((Button)i));
                else if (i is Border)
                    result.Children.Add(NChildBorder((Border)i));
                else if (i is StackPanel)
                    result.Children.Add(NChildStackPanel((StackPanel)i));
                else if (i is Grid)
                    result.Children.Add(NChildGrid((Grid)i));
            }
            return result;
        }

        public static StackPanel NChildStackPanel(StackPanel parent)
        {
            StackPanel result = NStackPanel(parent);

            foreach (var i in parent.Children)
            {
                if (i is TextBox)
                    result.Children.Add(NTextBox((TextBox)i));
                else if (i is TextBlock)
                    result.Children.Add(NTextBlock((TextBlock)i));
                else if (i is Image)
                    result.Children.Add(NImage((Image)i));
                else if (i is Button)
                    result.Children.Add(NButton((Button)i));
                else if (i is Border)
                    result.Children.Add(NChildBorder((Border)i));
                else if (i is StackPanel)
                    result.Children.Add(NChildStackPanel((StackPanel)i));
                else if (i is Grid)
                    result.Children.Add(NChildGrid((Grid)i));
            }
            return result;
        }
    }

    static class UriImage
    {
        public static Uri Url(string name) => new Uri(Path.Combine(Path.GetFullPath("Examples"), name));
        public static BitmapImage GetImage(string name) => new BitmapImage(Url(name));

        private static Dictionary<string, BitmapImage> img = new Dictionary<string, BitmapImage>()
        {
            { "Profil", GetImage("Profil1.png") },
            { "Tree", GetImage("Tree2.png") },
            { "Seed", GetImage("Seed1.png") },
            { "Search", GetImage("Search1.png") },
            { "Menu", GetImage("Menu1.png") },
            { "Info", GetImage("Info1.png") },
            { "Delete", GetImage("Delete1.png") },
            { "Back", GetImage("Back1.png") }
        };

        public static Dictionary<string, BitmapImage> Images { get => img; }
    }
}
