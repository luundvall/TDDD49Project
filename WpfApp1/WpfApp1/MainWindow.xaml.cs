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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.BLL;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Game game = new Game();
            

            
        }

        private void btnClick(object sender, RoutedEventArgs e) {
            System.Windows.Controls.Button clickedButton = (System.Windows.Controls.Button)sender;

            FrameworkElement activeBorder = (FrameworkElement)((System.Windows.Controls.Button)sender).Parent;

            var clickedButtonTag = clickedButton.Tag;

            var clickedBorderTag = activeBorder.Tag;

            clickedButton.Content = clickedBorderTag + " " + clickedButtonTag;
            clickedButton.IsEnabled = false;
        }
    }
}
