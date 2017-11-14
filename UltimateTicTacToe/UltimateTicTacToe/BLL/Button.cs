namespace UltimateTicTacToe.BLL
{
    public class Button : InterfaceButton
    {
        private string isTaken;
        private int id;
        private int boardId;

        public Button(int id, int boardId)
        {
            this.Id = id;
            this.isTaken = "";
            this.boardId = boardId;
            
        }

        public int Id { get => id; set => id = value; }

        public int getBoardId()
        {
            return this.boardId;
        }

        public void SetIsTaken(string isTaken)
        {
            this.isTaken = isTaken;
        }

        public string GetIsTaken()
        {
            return this.isTaken;
        }
    }
}