using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Data.OleDb;

namespace RegisterBotanicGarden
{

    static class DataBaseWorker
    {
        public static OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Ботанический_сад.accdb");

        public static void OpenConnection() => connection.Open();
        public static void CloseConnection() => connection.Close();
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
}
