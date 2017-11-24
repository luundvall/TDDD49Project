using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.BLL
{
   public class Player
    {
        private string marker;

        public Player(string playerMarker)
        {
            this.marker = playerMarker;
        }

        public string setMarker()
        {
            return this.marker;
        }
    }
}
