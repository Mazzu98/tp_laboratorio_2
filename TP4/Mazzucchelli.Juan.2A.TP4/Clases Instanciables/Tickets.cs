using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tickets
    {
        /// <summary>
        /// crea el ticket de la venta
        /// </summary>
        /// <param name="c">Computadora</param>
        /// <returns> Devuelve un ticket en formato de string</returns>
        public string hacerTicket(Computadora c)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(c.ToString());

            return sb.ToString();
        }
    }
}
