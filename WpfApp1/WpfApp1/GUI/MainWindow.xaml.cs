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
        }


        private void btnClick(object sender, RoutedEventArgs e)
        {
            
            Error.Text = "";
            gameLoop = game.getGameLoop();
            System.Windows.Controls.Button clickedButton = (System.Windows.Controls.Button)sender;
            var clickedButtonTag = clickedButton.Tag;

                int move = Convert.ToInt32(clickedButtonTag);
            try
            {
                if (gameLoop.checkButton(move) || gameLoop.GetUltimateBoard().GetSubBoard(move).getDisable())
                {

                }
                else
                {
                    ËnableGrid(clickedButtonTag.ToString());
                    gameLoop.run(move);
                    Activeplayer.Text = "Active player is: " + gameLoop.getActivePlayer().setMarker();
                    gameLoop.setMove();
                    clickedButton.Content = gameLoop.getActivePlayer().setMarker();
                    SetColor(clickedButton);
                    checkWinner(gameLoop);
                }
            }
            catch (Exception ex)
            {
                Error.Foreground = Brushes.Red;
                if (ex is ButtonTakenException)
                {
                    Error.Text = "Button is taken";
                }
                if (ex is DisableBoardException)
                {
                    Error.Text = "Board is disabled";
                }
            }
        }

        public void SetColor(System.Windows.Controls.Button clickedButton)
        {
            clickedButton.FontSize = 40;
            if (gameLoop.getActivePlayer().setMarker().Equals("X"))
            {
                clickedButton.Foreground = Brushes.Blue;
            }
            else if (gameLoop.getActivePlayer().setMarker().Equals("O"))
            {
                clickedButton.Foreground = Brushes.Red;
            }

        }

        public void checkWinner(GameLoop gameLoop)
        {    
            //CheckWinner is true next lap so winner will change all the time after a win has been made
            if (gameLoop.checkWinner())
            {
                Winner.Foreground = Brushes.LightGreen;
                Winner.Text = "The winner is " + gameLoop.getActivePlayer().setMarker();
                this.game = new Game();
                clearButton();
            }
        }


        public void clearButton()
        {
                foreach(System.Windows.Controls.Button button in FindVisualChildren<System.Windows.Controls.Button>(this))
                {
                button.Content = "";
                }
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }


        public void ËnableGrid(string tagId)
        {
            foreach (FrameworkElement grid in mainGrid.Children.OfType<Grid>())
            {
                
                string i = grid.Tag.ToString();
                if (grid.Tag.Equals(tagId))
                {
                    grid.IsEnabled = true;
                }
                else
                {
                    grid.IsEnabled = false;
                }
            }
        }
    }
}
