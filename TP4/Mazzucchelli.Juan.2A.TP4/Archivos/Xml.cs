using Excepciones;
using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivos<T>
    {
        /// <summary>
        /// Guarda un archivo Xml
        /// Proyecto Archivos – Clase Texto y Xml (ArchivosException)
        /// Proyecto Archivos – Clase XML
        /// </summary>
        /// <param name="archivo">string</param>
        /// <param name="datos">T</param>
        /// <returns> Devuelve true si se pudo guardar y false si no</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool ret = false;
            try
            {
                using(XmlTextWriter tw = new XmlTextWriter(archivo,Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(tw, datos);
                    ret = true;
                }
            }

            catch (Exception)
            {
                throw new ArchivosException("Archivo no generado");
            }
            return ret;
        }

        /// <summary>
        /// Lee un archivo Xml
        /// Proyecto Archivos – Clase Xml<T> - Los dos metodos
        /// </summary>
        /// <param name="archivo">string</param>
        /// <param name="datos">out T</param>
        /// <returns> Devuelve true si se pudo Leer y false si no</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool ret = false;
            try
            {
                using(XmlTextReader tr = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    datos = (T)ser.Deserialize(tr);
                    ret = true;
                }
            }
            catch (Exception)
            {
                throw new ArchivosException();
            }
            return ret;
        }
    }
}