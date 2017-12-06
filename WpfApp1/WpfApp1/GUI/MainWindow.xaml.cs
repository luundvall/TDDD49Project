using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfApp1.BLL;
using System.Drawing;


namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private Game game = null;
        private GameLoop gameLoop;

        public MainWindow()
        {
        }
        public MainWindow(Game game)
        {
            InitializeComponent();
            this.game = game;
            this.gameLoop = game.getGameLoop();
        }

        public void New_Game(object sender, RoutedEventArgs e)
        {
            Winner.Text = null;
            this.game = new Game();
            ËnableGrid("1");
            clearButton();
        }
        
        protected override void OnClosing(CancelEventArgs e)
        {
            if (!gameLoop.checkWinner())
            {
                MessageBoxResult dr = MessageBox.Show("Do you want to save the game?", "Save game?", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (dr == MessageBoxResult.No)
                {
                    gameLoop.deleteGame();
                    e.Cancel = false;
                }
                else if (dr == MessageBoxResult.Yes)
                {
                    gameLoop.saveGame();
                    e.Cancel = false;
                }
                else if (dr == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            this.Activate();
            Error.Text = "";
            gameLoop = game.getGameLoop();
            System.Windows.Controls.Button clickedButton = (System.Windows.Controls.Button)sender;

            var clickedButtonTag = clickedButton.Tag;
            string tag = clickedButtonTag.ToString();
            int move = Convert.ToInt32(clickedButtonTag);
            int boardId = Int32.Parse(tag);

            try
            {
                if (gameLoop.checkButton(move) || gameLoop.GetUltimateBoard().GetSubBoard(move).getDisable())
                {

                }
                else
                {
                    Activeplayer.Text = "Active player is: " + gameLoop.getActivePlayer().setMarker();
                    ËnableGrid(clickedButtonTag.ToString());
                    gameLoop.run(move);
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NewGameButton.Content = "Start New Game";
            ËnableGrid(gameLoop.getActiveBoard().getId().ToString());
            if (gameLoop.gameExists())
            {
                MessageBoxResult dr = MessageBox.Show("Do you want to resume the game?", "Resume", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (dr == MessageBoxResult.Yes)
                {
                    this.game = gameLoop.resumeGame();

                    UltimateBoard ub = gameLoop.resumeGame().getGameLoop().GetUltimateBoard();
                    foreach (System.Windows.Controls.Button button in FindVisualChildren<System.Windows.Controls.Button>(this))
                    {
                        Grid parent = button.Parent as Grid;
                        string parentString = parent.Tag.ToString();
                        int parentId = Int32.Parse(parentString);

                        foreach (SubBoard s in ub.getListOfSub())
                        {
                            for (int col = 0; col < 3; col++)
                            {
                                for (int row = 0; row < 3; row++)
                                {
                                    BLL.Button b = s.getButtonBoard()[col, row];
                                    if (b.getMarker().Equals("X"))
                                    {

                                        string tag = button.Tag.ToString();
                                        int buttonTag = Int32.Parse(tag);

                                        if (buttonTag.Equals(b.ButtonId) && parentId.Equals(b.BoardId))
                                        {
                                            button.Content = "X";
                                            button.FontSize = 40;
                                            button.Foreground = Brushes.Blue;
                                        }
                                    }

                                    if (b.getMarker().Equals("O"))
                                    {
                                        string tag = button.Tag.ToString();
                                        int buttonTag = Int32.Parse(tag);

                                        if (buttonTag.Equals(b.ButtonId) && parentId.Equals(b.BoardId))
                                        {
                                            button.Content = "O";
                                            button.FontSize = 40;
                                            button.Foreground = Brushes.Red;
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
                else if (dr == MessageBoxResult.No)
                {
                    this.game = new Game();
                }
            }

        }
        
        public void checkWinner(GameLoop gameLoop)
        {
            Xwinner1.Visibility = System.Windows.Visibility.Hidden;
            Xwinner2.Visibility = System.Windows.Visibility.Hidden;
            Owinner.Visibility = System.Windows.Visibility.Hidden;
            if (gameLoop.checkWinner())
            {
                ËnableGrid("1");
                Winner.Foreground = Brushes.LightGreen;
                Winner.Text = " is the Winner!!";

                if(gameLoop.getActivePlayer().setMarker().Equals("X"))
                {
                    Xwinner1.Visibility = System.Windows.Visibility.Visible;
                    Xwinner2.Visibility = System.Windows.Visibility.Visible;

                } else if (gameLoop.getActivePlayer().setMarker().Equals("O"))
                {
                    Owinner.Visibility = System.Windows.Visibility.Visible; 
                }
                if (MessageBox.Show("Do you want to start a new game?", "New game", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    this.Close();
                }
                else
                {
                    Winner.Text = null;
                    this.game = new Game();
                    clearButton();
                }

            }
        }

        public void clearButton()
        {
            foreach (System.Windows.Controls.Button button in FindVisualChildren<System.Windows.Controls.Button>(this))
            {
                if(button.Tag.ToString().Equals("25"))
                {
                    button.Content = "Start New Game";
                } else
                {
                    button.Content = "";
                }
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
            int boardId = Int32.Parse(tagId); 
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
