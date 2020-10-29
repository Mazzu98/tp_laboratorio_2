using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {

        public DniInvalidoException(string mensaje)
            : base(mensaje)
        {
        }

        public DniInvalidoException()
            : this("Dni contiene un error de formmato")
        {
        }

        public DniInvalidoException(string mensaje,Exception innerException)
            : base(mensaje, innerException)
        {
        }
        public DniInvalidoException(Exception innerException)
            : this("Dni contiene uun error de formmato", innerException)
        {
        }
    }
}
