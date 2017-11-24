using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.BLL
{
    public class ButtonTakenException : Exception
    {
        public ButtonTakenException()
        {
        }

        public ButtonTakenException(string message)
            : base(message)
        {
        }

        public ButtonTakenException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
