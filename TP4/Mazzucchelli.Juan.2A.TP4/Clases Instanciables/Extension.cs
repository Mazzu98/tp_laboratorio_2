using Archivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Extension
    {
        /// <summary>
        /// guarda en un archivo de texto el ticket
        /// Proyecto Entidades – Clase Extension
        /// </summary>
        /// <param name="path">string</param>
        /// <param name="cadena">string</param>
        /// <returns> Devuelve true si se pudo guardar y false si no </returns>
        public static bool GuardarTicket(this Tickets t,string path,string cadena)
        {
            Texto txt = new Texto();
            return txt.Guardar(path,cadena);
        }
    }
}
