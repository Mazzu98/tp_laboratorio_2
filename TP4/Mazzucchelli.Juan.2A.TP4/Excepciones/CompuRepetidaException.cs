using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class CompuRepetidaException : Exception
    {
        /// <summary>
        /// Constructor: inicializa los atributos
        /// </summary>
        public CompuRepetidaException()
            : base("Esta computadora ya esta en el comercio")
        {
        }
        /// <summary>
        /// Constructor: inicializa los atributos
        /// <param name="mensaje">string</param>
        /// </summary>
        public CompuRepetidaException(string mensaje)
            : base(mensaje)
        {
        }

        /// <summary>
        /// Constructor: inicializa los atributos
        /// <param name="innerException">Exception</param>
        /// </summary>
        public CompuRepetidaException(Exception innerException)
            : base("Esta computadora ya esta en el comercio", innerException)
        {
        }
    }
}
