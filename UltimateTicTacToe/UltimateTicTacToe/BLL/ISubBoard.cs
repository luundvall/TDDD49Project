using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateTicTacToe.BLL
{
    public interface ISubBoard<T>
    {

        T getBoardSelf();

        T getBoardById(int id);

        Button GetButton(int move);

        Button[,] getButtonList();

    }
}
