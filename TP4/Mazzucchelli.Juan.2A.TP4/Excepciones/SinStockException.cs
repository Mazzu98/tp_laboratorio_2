using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinStockException : Exception
    {
        /// <summary>
        /// Constructor: inicializa los atributos
        /// </summary>
        public SinStockException()
            : base("Venta no realizada por falta de stock")
        {
        }

        /// <summary>
        /// Constructor: inicializa los atributos
        /// <param name="mensaje">string</param>
        /// </summary>
        public SinStockException(string mensaje)
            : base(mensaje)
        {
        }

    }
}
