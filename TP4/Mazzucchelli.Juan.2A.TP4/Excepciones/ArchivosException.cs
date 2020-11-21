using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor: inicializa los atributos
        /// </summary>
        public ArchivosException() 
            :base("Archivo Inexistente")
        {
        }

        /// <summary>
        /// Constructor: inicializa los atributos
        /// <param name="mensaje">string</param>
        /// </summary>
        public ArchivosException(string mensaje)
            :base(mensaje)
        {
        }

        /// <summary>
        /// Constructor: inicializa los atributos
        /// <param name="innerException">Exception</param>
        /// </summary>
        public ArchivosException(Exception innerException)
            : base("Archivo Inexistente", innerException)
        {
        }
    }
}
