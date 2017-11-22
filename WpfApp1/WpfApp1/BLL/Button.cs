using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.BLL
{
    class Button
    {
        private int buttonId;
        private string marker;
        private int boardId;
        public Button(int buttonId, int boardId)
        {
            this.marker = "";
            this.buttonId = buttonId;
            this.boardId = boardId;
        }

        public int ButtonId { get => this.buttonId; set => this.buttonId = value; }

        public void setMarker(string marker)
        {
            this.marker = marker;
        }

        public string getMarker()
        {
            return this.marker;
        }
        public int BoardId { get => this.boardId; set => this.boardId = value; }
    }
}
