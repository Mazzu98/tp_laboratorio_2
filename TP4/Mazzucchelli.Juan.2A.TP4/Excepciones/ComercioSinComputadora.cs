using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ComercioSinComputadora : Exception
    {
        /// <summary>
        /// Constructor: inicializa los atributos
        /// </summary>
        public ComercioSinComputadora()
            : base("El comercio no contiene esa computadora")
        {
        }

        /// <summary>
        /// Constructor: inicializa los atributos
        /// <param name="mensaje">string</param>
        /// </summary>
        public ComercioSinComputadora(string mensaje)
            : base(mensaje)
        {
        }

        /// <summary>
        /// Constructor: inicializa los atributos
        /// <param name="innerException">Exception</param>
        /// </summary>
        public ComercioSinComputadora(Exception innerException)
            : base("El comercio no contiene esa computadora", innerException)
        {
        }
    }
}
