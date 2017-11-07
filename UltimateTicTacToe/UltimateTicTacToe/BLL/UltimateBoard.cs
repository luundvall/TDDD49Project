using System;
using System.Collections.Generic;

namespace UltimateTicTacToe.BLL
{
    class UltimateBoard
    {
        private Board b1;
        private Board b2;
        private Board b3;
        private Board b4;
        private Board b5;
        private Board b6;
        private Board b7;
        private Board b8;
        private Board b9;
        
        private GameLoop game;
        private Board[,] boardOfBoards;

        public UltimateBoard(GameLoop game)
        {
            
            Board b1 = new Board(game, 1);
            Board b2 = new Board(game, 2);
            Board b3 = new Board(game, 3);
            Board b4 = new Board(game, 4);
            Board b5 = new Board(game, 5);
            Board b6 = new Board(game, 6);
            Board b7 = new Board(game, 7);
            Board b8 = new Board(game, 8);
            Board b9 = new Board(game, 9);

            this.game = game;
            boardOfBoards = new Board[,] {  { b1, b2 ,b3},
                                            { b4, b5 ,b6},
                                            { b7, b8 ,b9}};

            Console.WriteLine(boardOfBoards);



            Console.WriteLine("(2) Creating the boards for the Ultimate board..");

        }

        public Board[,] getBoardofBoards
        {
            get => boardOfBoards;
        }

       
    }
}