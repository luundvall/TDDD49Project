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
        private static SubBoard[,] subBoards = new SubBoard[3, 3];
        private static Player player1;
        private static Player player2;
        private static XMLsaver xmlsaver;
        private static LoadFromXML loadFromXML;
        private static GameLoop gameLoop;

        [STAThread]
        public static void Main(string [] args)
        {

            int boardId = 1;
            SubBoard[,] subBoards = new SubBoard[3, 3];

            for (int col = 0; col < 3; col++)
            {
                for (int row = 0; row < 3; row++)
                {
                    subBoards[col, row] = new SubBoard(getButtonBoard(boardId), boardId);
                    boardId++;
                }
            }


            Player player1 = new Player("X");
            Player player2 = new Player("O");
            XMLsaver xmlsaver = new XMLsaver();
            LoadFromXML loadFromXML = new LoadFromXML();
            

            DefaultInit di = new DefaultInit();
            DefaultInitDAL diDAL = new DefaultInitDAL();
            DefaultInitBLL diBLL = new DefaultInitBLL();

            Game game = new Game(new UltimateBoard(subBoards), player1, player2, xmlsaver, loadFromXML);
            MainWindow mainWindow = new MainWindow(game);
            
            mainWindow.SetInitable(di);
            loadFromXML.SetInitable(diDAL);
            mainWindow.ShowDialog();
        }

        public static GameLoop CreateNewGame()
        {


            player1 = new Player("X");
            player2 = new Player("O");
            xmlsaver = new XMLsaver();
            loadFromXML = new LoadFromXML();
            Console.WriteLine("Created new game");
            return new GameLoop(player1, player2, new UltimateBoard(subBoards), xmlsaver, loadFromXML);
        }


        public static Button[,] getButtonBoard(int boardId)
        {
            Button[,] buttonBoard = new Button[3, 3];

            int buttonId = 1;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    buttonBoard[row, col] = new Button(buttonId, boardId);
                    buttonId++;
                }
            }
            return buttonBoard;
        }
    }
}
