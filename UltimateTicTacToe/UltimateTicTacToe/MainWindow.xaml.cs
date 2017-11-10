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

        }

        private void CreateGame()
        {
            gameLoop = new GameLoop();
            gameLoop.createComponents();
            gameLoop.run();
        }


    }
}
