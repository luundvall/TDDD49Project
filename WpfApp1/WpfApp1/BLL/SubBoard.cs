using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.BLL
{
    public class SubBoard
    {
        private Button[,] buttonBoard;
        private int id;
        private int numberOfMoves = 0;
        private bool disable; 

        public SubBoard(Button[,] bb, int id)
        {
            this.buttonBoard = bb;
            this.id = id;
            this.disable = false;
        }

        public Button[,] getButtonBoard()
        {
            return this.buttonBoard;
        }

        public Button getButton(int move)
        {
            for (int brow = 0; brow < buttonBoard.GetLength(0); brow++)
            {
                for (int bcol = 0; bcol < buttonBoard.GetLength(1); bcol++)
                {
                    if (buttonBoard[brow, bcol].ButtonId.Equals(move))
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

        public void NumberOfMoves()
        {
            this.numberOfMoves = numberOfMoves + 1; 
        }

        public int getNumberOfMoves()
        {
            return this.numberOfMoves; 
        }

        public void disableBoard(bool isDisable)
        {
            this.disable = isDisable;    
        }

        public bool getDisable()
        {
            return this.disable;
        }
    }
}
