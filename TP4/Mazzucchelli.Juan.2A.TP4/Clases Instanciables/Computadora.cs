using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Desktop))]
    [XmlInclude(typeof(Laptop))]
    public abstract class Computadora
    {
        private int idComputadora;
        private ETipoPc tipo;
        private EGama gama;
        private float precio;
        
        public int IdComputadora
        {
            get { return idComputadora; }
            set { idComputadora = value; }
        }
        
        public EGama Gama
        {
            get { return gama; }
            set { gama = value; }
        }

        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public ETipoPc Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public Computadora()
        { }

        /// <summary>
        /// Constructor: inicializa los atributos
        /// <param name="Id">int</param>
        /// <param name="tipo">ETipoPc</param>
        /// <param name="gama">EGama</param>
        /// <param name="precio">float</param>
        /// </summary>
        public Computadora(int Id, ETipoPc tipo, EGama gama, float precio)
            : this()
        {
            this.idComputadora = Id;
            this.tipo = tipo;
            this.gama = gama;
            this.precio = precio;
        }

        /// <summary>
        /// combierte Computadora a string
        /// </summary>
        /// <returns> Devuelve un string con el contenido de la Computadora</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Id: {this.idComputadora}");
            sb.AppendLine($"{this.Tipo}");
            sb.AppendLine($"Gama: {this.gama}");
            sb.AppendLine($"Precio: ${this.precio}");

            return sb.ToString();
        }

        /// <summary>
        /// compara dos computadoras
        /// </summary>
        /// <param name="c1">Computadora</param>
        /// <param name="c1">Computadora</param>
        /// <returns> Devuelve true si las computadoras tienen el mismo id y false si no</returns>
        public static bool operator ==(Computadora c1, Computadora c2)
        {
            bool ret = false;
            if ((object)c1 != null && (object)c2 != null)
            {
                if (c1.IdComputadora == c2.IdComputadora)
                {
                    ret = true;
                }
            }
            return ret;
        }

        /// <summary>
        /// compara dos computadoras
        /// </summary>
        /// <param name="c1">Computadora</param>
        /// <param name="c1">Computadora</param>
        /// <returns> Devuelve true si las computadoras no tienen el mismo id y false si lo tienen</returns>
        public static bool operator !=(Computadora c1, Computadora c2)
        {
            return !(c1 == c2);
        }

        /// <summary>
        /// compara dos computadoras
        /// </summary>
        /// <param name="object">object</param>
        /// <returns> Devuelve true si las computadoras tienen el mismo id y false si no</returns>
        public override bool Equals(object obj)
        {
            bool ret = false;
            if(obj != null && obj is Computadora)
            {
                ret = this == (Computadora)obj;
            }
            return ret;
        }
    }
}
