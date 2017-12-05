using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using WpfApp1.BLL;
using WpfApp1.DAL;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 

    public partial class App : Application
    {

        [STAThread]
        public static void Main(string [] args)
        {

            Game game = new Game();
            MainWindow mainWindow = new MainWindow(game);
            mainWindow.ShowDialog();
        }
    }
}
