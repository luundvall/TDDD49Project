using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateTicTacToe.BLL
{
    public interface InterfaceButton
    {

        string GetIsTaken();

        void SetIsTaken(String marker);

    }
}
