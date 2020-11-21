
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Desktop : Computadora
    {
        private bool perisfericos;

        public bool Perisfericos
        {
            get { return perisfericos; }
            set { perisfericos = value; }
        }

        
        public Desktop()
            : base()
        { }

        /// <summary>
        /// Constructor: inicializa los atributos
        /// <param name="Id">int</param>
        /// <param name="tipo">ETipoPc</param>
        /// <param name="gama">EGama</param>
        /// <param name="precio">float</param>
        /// <param name="perisfericos">bool</param>
        /// </summary>
        public Desktop(int Id, ETipoPc tipo, EGama gama, float precio, bool perisfericos)
            : base(Id, tipo, gama, precio)
        {
            this.perisfericos = perisfericos;
        }

        /// <summary>
        /// combierte Desktop a string
        /// </summary>
        /// <returns> Devuelve un string con el contenido de Desktop</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append($"perisfericos: ");
            if (this.perisfericos)
            {
                sb.AppendLine("Si");
            }
            else
            {
                sb.AppendLine("No");
            }

            return sb.ToString();
        }

        /// <summary>
        /// compara dos Desktops
        /// </summary>
        /// <param name="d1">Desktop</param>
        /// <param name="d1">Desktop</param>
        /// <returns> Devuelve true si las Desktop tienen el mismo id y false si no</returns>
        public static bool operator ==(Desktop d1, Desktop d2)
        {
            return (Computadora)d1 == (Computadora)d2;
        }

        /// <summary>
        /// compara dos computadoras
        /// </summary>
        /// <param name="d1">Desktop</param>
        /// <param name="d1">Desktop</param>
        /// <returns> Devuelve true si las Desktop no tienen el mismo id y false si lo tienen</returns>
        public static bool operator !=(Desktop d1, Desktop d2)
        {
            return !(d1 == d2);
        }

    }
}
