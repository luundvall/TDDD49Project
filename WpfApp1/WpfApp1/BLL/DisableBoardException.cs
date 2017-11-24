using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.BLL
{
    class DisableBoardException : Exception
    {
            public DisableBoardException()
            {
            }

            public DisableBoardException(string message)
                : base(message)
            {
            }

            public DisableBoardException(string message, Exception inner)
                : base(message, inner)
            {
            }
    }
}
