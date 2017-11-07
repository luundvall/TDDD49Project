using System;
using System.Windows;
using System.Windows.Controls;
using UltimateTicTacToe.BLL; 

namespace UltimateTicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameLoop gameLoop;

        public MainWindow()
        {
            InitializeComponent();
            CreateGame();
            CreateUI();
        }


        private void CreateUI()
        { 
            for(int row = 0; row<3; row++)
            {
                for(int col = 0; col<3; col++)
                {
                    Button b = gameLoop.GetUltimateBoard().getBoardofBoards[col, row].GetboardButtons[col, row];
                }

            }
        }

        private void CreateGame()
        {
            gameLoop = new GameLoop();
            gameLoop.createComponents();
            gameLoop.run();
        }


    }
}
