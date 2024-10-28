using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocios.Exceptions
{
    public class ElementoInvalidoException : Exception
    {
        public ElementoInvalidoException()
        {
        }

        public ElementoInvalidoException(string? message) : base(message)
        {
        }

    }
}
