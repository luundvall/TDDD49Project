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
                    checkWinner(gameLoop);
                    clickedButton.Content = gameLoop.getActivePlayer().setMarker();
                    SetColor(clickedButton);
                }
            }
            catch (Exception ex)
            {
                if (ex is ButtonTakenException)
                {
                    MessageBox.Show("The button is already taken, try again plz");
                }
                if (ex is DisableBoardException)
                {
                    MessageBox.Show("The board that you want to move to is disabled");
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
            if (gameLoop.checkWinner())
            {
                Winner.Text = "The winner is... " + gameLoop.getActivePlayer().setMarker();

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
