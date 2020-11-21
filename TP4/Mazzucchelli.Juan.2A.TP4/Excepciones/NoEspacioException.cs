using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NoEspacioException : Exception
    {
        /// <summary>
        /// Constructor: inicializa los atributos
        /// </summary>
        public NoEspacioException()
           : base("No hay mas espacio")
        {
        }

        /// <summary>
        /// Constructor: inicializa los atributos
        /// <param name="mensaje">string</param>
        /// </summary>
        public NoEspacioException(string mensaje)
           : base(mensaje)
        {
        }
    }
}
