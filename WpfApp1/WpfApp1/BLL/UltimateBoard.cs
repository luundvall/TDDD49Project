using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.BLL
{
    public class UltimateBoard
    {
        private SubBoard[,] subBoards = null;
        public UltimateBoard(SubBoard[,] subBoards)
        {
            this.subBoards = subBoards;
        }

        public SubBoard[,] getListOfSub()
        {
            return this.subBoards;
        }

        public SubBoard GetSubBoard(int move)
        {

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    SubBoard subBoard = this.subBoards[row, col];
                    if (subBoard.getId().Equals(move))
                    {
                        return subBoard;
                    }
                }
            }
            return null;
        }

    }
}
