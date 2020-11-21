using Archivos;

using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comercio
    {
        private int cantidad;
        private List<Computadora> computadoras;

        /// <summary>
        /// propiedad: inicializa los atributos
        /// </summary>
        public List<Computadora> Computadoras { get { return computadoras; } set { computadoras = value; } }
        /// <summary>
        /// Constructor: inicializa los atributos
        /// </summary>
        public int Cantidad { get { return cantidad; } set { cantidad= value; } }

        /// <summary>
        /// Constructor: inicializa los atributos
        /// </summary>
        public Comercio()
        {
            this.cantidad = 0;
            this.computadoras = new List<Computadora>();
        }

        /// <summary>
        /// Constructor: inicializa los atributos
        /// </summary>
        /// <param name="cant">int</param>
        public Comercio(int cant)
            : this()
        {
            this.cantidad = cant;
        }

        /// <summary>
        /// compara un comercio y una computadora
        /// </summary>
        /// <param name="co">Comercio</param>
        /// <param name="ca">Computadora</param>
        /// <returns> Devuelve true si el comercio tiene esa computadora y false si no la tiene</returns>
        public static bool operator ==(Comercio co,Computadora ca)
        {
            bool ret = false;
            if((object)co != null && (object)ca != null)
            {
                if(co.computadoras.Contains(ca))
                {
                    ret = true;
                }
            }
            return ret;
        }

        /// <summary>
        /// compara un comercio y una computadora
        /// </summary>
        /// <param name="co">Comercio</param>
        /// <param name="ca">Computadora</param>
        /// <returns> Devuelve true si el comercio no tiene esa computadora y false si la tiene</returns>
        public static bool operator !=(Comercio co, Computadora ca)
        {
            return !(co == ca);
        }

        /// <summary>
        /// compara un comercio y una computadora
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns> Devuelve true si el comercio tiene esa computadora y false si no la tiene</returns>
        public override bool Equals(object obj)
        {
            bool ret = false;
            if(obj is Computadora)
            {
                ret = this == (Computadora)obj;
            }
            return ret;
        }

        /// <summary>
        /// agrega una computadora al comercio si todavia no esta en el comercio y tiene capacidad
        /// Proyecto Entidades - Clase comercio - sobrecarga + (NoEspacioException, CompuRepetidaException)
        /// </summary>
        /// <param name="co">Comercio</param>
        /// <param name="ca">Computadora</param>
        /// <returns> Devuelve el comercio</returns>
        public static Comercio operator +(Comercio co, Computadora ca)
        {
            if(co != ca)
            {
                if(co.cantidad > co.Computadoras.Count)
                {
                    co.computadoras.Add(ca);
                }
                else
                {
                    throw new NoEspacioException();
                }
            }
            else
            {
                throw new CompuRepetidaException();
            }
            return co;
        }

        /// <summary>
        /// si el comercio contiene a esa computadora la eliminará
        /// Proyecto Entidades - Clase comercio – sobrecarga - (ComercioSinComputadora)
        /// </summary>
        /// <param name="co">Comercio</param>
        /// <param name="ca">Computadora</param>
        /// <returns> Devuelve el comercio</returns>
        public static Comercio operator -(Comercio co, Computadora ca)
        {
            if (co == ca)
            {
                co.computadoras.Remove(ca);
            }
            else
            {
                throw new ComercioSinComputadora();
            }
            return co;
        }

        /// <summary>
        /// si el comercio contiene a esa computadora la eliminará e imprimira el tiquet de venta
        /// Proyecto Entidades - Clase comercio – Vender - (SinStockException)
        /// </summary>
        /// <param name="co">Comercio</param>
        /// <param name="ca">Computadora</param>
        /// <returns> Devuelve el true si se pudo vender y false si no</returns>
        public static bool Vender(Comercio co,Computadora ca)
        {
            bool ret = false;
            try
            {
                co -= ca;
                Tickets tickets = new Tickets();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("\nVENTA");
                sb.AppendLine("*********************************");
                sb.Append(tickets.hacerTicket(ca));
                sb.AppendLine("*********************************");
                Console.WriteLine(sb.ToString());
                
                ret = true;
            }
            catch(ComercioSinComputadora)
            {
                throw new SinStockException();
            }
            return ret;
        }

        /// <summary>
        /// Guarda en un archivo el comercio
        /// </summary>
        /// <param name="co">Comercio</param>
        /// <param name="path">string</param>
        /// <returns> Devuelve true si pudo guardar y false si no</returns>
        public static bool Guardar(string path,Comercio co)
        {
            bool ret = false;
            Xml<Comercio> xml = new Xml<Comercio>();
            ret = xml.Guardar(path, co);

            return ret;
        }

        /// <summary>
        /// Lee el archivo de el comercio
        /// </summary>
        /// <returns> Devuelve un string con el contenido del archivo</returns>
        public static string Leer()
        {
            Comercio co = new Comercio();
            Xml<Comercio> xml = new Xml<Comercio>();
            xml.Leer("comercio.xml", out co);

            return co.ToString();
        }

        /// <summary>
        /// combierte comercio a string
        /// </summary>
        /// <returns> Devuelve un string con el contenido de el comercio</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("COMERCIO");
            sb.AppendLine($"Capacidad: {this.cantidad}");
            sb.AppendLine("Listado:\n");
            foreach (Computadora c in this.computadoras)
            {
                sb.AppendLine(c.ToString());
                sb.AppendLine("-----------------------------------");
            }
            return sb.ToString();
        }

    }
}
