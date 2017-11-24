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
        private Game game = null;
        private GameLoop gameLoop;

        public MainWindow()
        {
        }
            public MainWindow(Game game)
                {
            
                    this.game = game;
                    InitializeComponent();
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
            gameLoop = game.getGameLoop();
            int move = Convert.ToInt32(clickedButtonTag);
            

            Activeplayer.Text = "Active player is: " + gameLoop.getActivePlayer().setMarker();
            if (gameLoop.checkButton(move))
            {
                Console.WriteLine("FAIL TO MAKE MOVE");
            }
            else
            {
                gameLoop.run(move);
                gameLoop.setMove();
                foreach (FrameworkElement grid in mainGrid.Children.OfType<Grid>())
                {
                    string i = grid.Tag.ToString();
                    Console.WriteLine(i); 
                    if (grid.Tag.Equals(clickedButtonTag.ToString()))
                    {
                        grid.IsEnabled = true;
                    }
                    else
                    {
                        grid.IsEnabled = false;
                    }
                }
                clickedButton.Content = gameLoop.getActivePlayer().setMarker();
                if (gameLoop.checkWinner())
                {
                    Winner.Text = "The winner is... " + gameLoop.getActivePlayer().setMarker();
                }
            }
        }
    }
}
