using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateTicTacToe.BLL
{
    class SubBoard
    {
        private Button[,] buttonBoard;
        private int id; 

        public SubBoard(Button [,] bb, int id)
        {
            this.buttonBoard = bb;
            this.id = id;
        }

        public Button [,] getButtonBoard()
        {
            return this.buttonBoard; 
        } 

        public Button getButton(int move)
        {
            for (int brow = 0; brow < buttonBoard.GetLength(0); brow++)
            {
                for (int bcol = 0; bcol < buttonBoard.GetLength(1); bcol++)
                {
                    if(buttonBoard[brow, bcol].ButtonId.Equals(move))
                    {
                        return buttonBoard[brow, bcol]; 
                    }
                }
            }
            return null; 
        }

        public int getId()
        {
            return this.id; 
        }
    }
}
