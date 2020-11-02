using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        /// <summary>
        /// Inicializa los valores por default que tendrá Universiatrio
        /// </summary>
        public Universitario()
            :base()
        {
            this.legajo = 0;
        }

        /// <summary>
        /// Inicializa Universitario con los valores recibidos
        /// </summary>
        /// <param name="legajo">int</param>
        /// <param name="nombre">string</param>
        /// <param name="apellido">string</param>
        /// <param name="dni">string</param>
        /// <param name="nacionalidad">ENacionalidad</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Muestra los datos
        /// </summary>
        /// <returns> Devuelve un string con los datos del Universitario </returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($"LEGAJO NúMERO: {this.legajo}");

            return sb.ToString();
        }

        /// <summary>
        /// compara dos Universitario, serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="pg1">Universitario</param>
        /// <param name="pg2">Universitario</param>
        /// <returns> Devuelve true si son iguales y false si no lo son</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool ret = false;
            if((object)pg1 != null && (object)pg2 != null)
            {
                if(pg1.GetType() == pg2.GetType() && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI))
                {
                    ret = true;
                }
            }
            return ret;
        }

        /// <summary>
        /// compara dos Universitario, no serán iguales si y sólo si no son del mismo Tipo y su Legajo o DNI no son iguales.
        /// </summary>
        /// <param name="pg1">Universitario</param>
        /// <param name="pg2">Universitario</param>
        /// <returns> Devuelve false si son distintosy true si no lo son</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// compara dos Universitario a través del operador ==
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns> Devuelve true si son iguales y false si no lo son</returns>
        public override bool Equals(object obj)
        {
            bool ret = false;
            if(obj is Universitario)
            {
                ret = this == (Universitario)obj;
            }
            return ret;
        }
    }
}
