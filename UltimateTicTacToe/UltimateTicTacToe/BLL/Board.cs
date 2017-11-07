using System.Windows.Controls;
using System;

namespace UltimateTicTacToe.BLL
{
    class Board
    {
        private Button b1;
        private Button b2;
        private Button b3;
        private Button b4;
        private Button b5;
        private Button b6;
        private Button b7;
        private Button b8;
        private Button b9;
        private Button[,] boardButtons;
        private GameLoop game;
        private int id;

        public Board(GameLoop game, int id)
        {
            this.id = id; 
            this.game = game;    
            b1 = new Button();
            b2 = new Button();
            b3 = new Button();
            b4 = new Button();
            b5 = new Button();
            b6 = new Button();
            b7 = new Button();
            b8 = new Button();
            b9 = new Button();

            boardButtons = new Button [,] { { b1, b2 ,b3},
                                            { b4, b5 ,b6},
                                            { b7, b8 ,b9}};

        }

        public int getID ()
        {
            return this.id;
        }

        public Button[,] GetboardButtons
        {
            get => boardButtons;
        }


    }
}