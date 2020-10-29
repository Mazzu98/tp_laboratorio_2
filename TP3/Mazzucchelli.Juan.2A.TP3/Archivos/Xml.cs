using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivos<T>
    {
        /// <summary>
        /// Guarda un archivo Xml
        /// </summary>
        /// <param name="archivo">string</param>
        /// <param name="datos">T</param>
        /// <returns> Devuelve true si se pudo guardar y false si no</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool ret = false;
            using(XmlTextWriter tw = new XmlTextWriter(archivo,Encoding.UTF8))
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                ser.Serialize(tw, datos);
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// Lee un archivo Xml
        /// </summary>
        /// <param name="archivo">string</param>
        /// <param name="datos">out T</param>
        /// <returns> Devuelve true si se pudo Leer y false si no</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool ret = false;
            using(XmlTextReader tr = new XmlTextReader(archivo))
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                datos = (T)ser.Deserialize(tr);
                ret = true;
            }
            return ret;
        }
    }
}