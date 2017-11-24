using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.BLL;

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

            Console.WriteLine("Works");

            Game game = new Game();
            MainWindow mainWindow = new MainWindow(game);
            mainWindow.ShowDialog();


            
        }
    }
}
