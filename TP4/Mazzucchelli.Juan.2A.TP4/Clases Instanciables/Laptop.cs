
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Laptop : Computadora
    {
        private bool bluetooth;

        public bool Bluetooth
        {
            get { return bluetooth; }
            set { bluetooth = value; }
        }

        public Laptop()
            : base()
        {}

        /// <summary>
        /// Constructor: inicializa los atributos
        /// <param name="Id">int</param>
        /// <param name="tipo">ETipoPc</param>
        /// <param name="gama">EGama</param>
        /// <param name="precio">float</param>
        /// <param name="bluetooth">bool</param>
        /// </summary>
        public Laptop(int Id, ETipoPc tipo, EGama gama, float precio, bool bluetooth)
            : base(Id, tipo, gama, precio)
        {
            this.bluetooth = bluetooth;
        }

        /// <summary>
        /// combierte Laptop a string
        /// </summary>
        /// <returns> Devuelve un string con el contenido de Laptop</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append($"Bluetooth: ");
            if (this.bluetooth)
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
        /// compara dos Laptops
        /// </summary>
        /// <param name="l1">Laptop</param>
        /// <param name="l1">Laptop</param>
        /// <returns> Devuelve true si las Laptops tienen el mismo id y false si no</returns>
        public static bool operator ==(Laptop l1, Laptop l2)
        {
            return (Computadora)l1 == (Computadora)l2;
        }

        /// <summary>
        /// compara dos Laptops
        /// </summary>
        /// <param name="l1">Laptop</param>
        /// <param name="l2">Laptop</param>
        /// <returns> Devuelve true si las Laptops no tienen el mismo id y false si lo tienen</returns>
        public static bool operator !=(Laptop l1, Laptop l2)
        {
            return !(l1 == l2);
        }
    }
}
