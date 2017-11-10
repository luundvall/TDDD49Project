using System;

namespace UltimateTicTacToe.BLL
{
    class SubBoard : InterfaceBoard <SubBoard>
    {
        InterfaceBoard <UltimateBoard> ultimateBoard;

        private int id;
        private Button[,] buttonBoard = new Button[3, 3];
        private bool activeBoard;

        public SubBoard(int id)
        {
            this.activeBoard = false;
            int buttonId = 0;
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    buttonId++;
                    buttonBoard[row, column] = new Button(buttonId, id);
                }
            }
            this.id = id;
        }

        public int Id { get => id; set => id = value; }

        public bool getActiveBoard()
        {
            return this.activeBoard;
        }
        public void setActiveBoard(bool active)
        {
            this.activeBoard = active;
        }

        public SubBoard getBoardSelf()
        {
            return this;
        }

        public SubBoard getBoardById(int BoardId)
        {

            if (this.id == BoardId)
            {
                return this;

            }
            return null;
               
        }


        public Button GetButton(int move)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    Button button = buttonBoard[row, column];
                    if (button.Id.Equals(move))
                    {
                        return button;
                    }
                }
            }
            return null;
        }

        public string getTypeOfBoard()
        {
            return "SubBoard";
        }

        public Button[,] getButtonList()
        {
            return this.buttonBoard;
        }
    }
}