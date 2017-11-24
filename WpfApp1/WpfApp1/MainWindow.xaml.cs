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
        Game game;
        GameLoop gameLoop;
        

        public MainWindow()
        {
            InitializeComponent();
            game = new Game();
            foreach (FrameworkElement grid in mainGrid.Children.OfType<Grid>())
            {
                string i = grid.Tag.ToString();
                
                if(grid.Tag.Equals("1"))
                {
                    grid.IsEnabled = true;
                } else
                {
                    grid.IsEnabled = false;
                }
            }
        }

        private void btnClick(object sender, RoutedEventArgs e) {
            System.Windows.Controls.Button clickedButton = (System.Windows.Controls.Button)sender;
            var clickedButtonTag = clickedButton.Tag;
            foreach (FrameworkElement grid in mainGrid.Children.OfType<Grid>())
            {
                string i = grid.Tag.ToString();
                
                if (grid.Tag.Equals(clickedButtonTag.ToString()))
                {
                    grid.IsEnabled = true;
                }
                else
                {
                    grid.IsEnabled = false;
                }
            }

            FrameworkElement activeBorder = (FrameworkElement)((System.Windows.Controls.Button)sender).Parent;
            var active = activeBorder.Tag;

            gameLoop = game.getGameLoop();


              
                clickedButtonTag = clickedButton.Tag;
                int move = Convert.ToInt32(clickedButtonTag);
                gameLoop.run(move);

                clickedButton.Content = gameLoop.getActivePlayer().setMarker();
               // clickedButton.IsEnabled = false;

                if(gameLoop.checkWinner())
                {
                MessageBox.Show("WE HAVE A WINNER");
                }

                var clickedBorderTag = activeBorder.Tag;
                
                


        }
    }
}
