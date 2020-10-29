using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivos<string>
    {
        /// <summary>
        /// Guarda un archivo de texto
        /// </summary>
        /// <param name="archivo">string</param>
        /// <param name="datos">string</param>
        /// <returns> Devuelve true si se pudo guardar y false si no</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool ret = false;
            using (StreamWriter sw = new StreamWriter(archivo, false, Encoding.UTF8))
            {
                sw.WriteLine(datos);
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// Lee un archivo de texto
        /// </summary>
        /// <param name="archivo">string</param>
        /// <param name="datos">out string</param>
        /// <returns> Devuelve true si se pudo Leer y false si no</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool ret = false;
            using (StreamReader sr = new StreamReader(archivo, Encoding.UTF8))
            {
                datos = sr.ReadToEnd();
                ret = true;
            }
            return ret;
        }
    }
}

