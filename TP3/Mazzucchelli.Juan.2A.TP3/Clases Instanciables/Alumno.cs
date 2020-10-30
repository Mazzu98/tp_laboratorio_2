using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        /// <summary>
        /// Inicializa los valores por default que tendrá Alumno
        /// </summary>
        public Alumno()
            :base()
        {
        }

        /// <summary>
        /// Inicializa Alumno con los valores recibidos
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="nombre">string</param>
        /// <param name="apellido">string</param>
        /// <param name="dni">string</param>
        /// <param name="nacionalidad">ENacionalidad</param>
        /// <param name="claseQueToma">EClases</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,Universidad.EClases claseQueToma) 
            : base(id,nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Inicializa Alumno con los valores recibidos
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="nombre">string</param>
        /// <param name="apellido">string</param>
        /// <param name="dni">string</param>
        /// <param name="nacionalidad">ENacionalidad</param>
        /// <param name="claseQueToma">EClases</param>
        /// <param name="estadoCuenta">EClases</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad,clasesQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Muestra los datos del Alumno
        /// </summary>
        /// <returns> Devuelve un string con los datos del Alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            if(this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                sb.AppendLine($"ESTADO DE CUENTA: Cuota al día");
            }
            else
            {
                sb.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta}");
            }
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// convierte Alumno a string
        /// </summary>
        /// <returns> Devuelve un string con los datos del Alumno</returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

        /// <summary>
        /// las clases que toma el alumno
        /// </summary>
        /// <returns> Devuelve un sttring con las clases que toma el Alumno</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE " + this.claseQueToma;
        }

        /// <summary>
        /// compara un alumno y una clase, un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">EClases</param>
        /// <returns> Devuelve true si son iguales y false si no lo son</returns>
        public static bool operator ==(Alumno a,Universidad.EClases clase)
        {
            bool ret = false;
            if((object)a != null && (object)clase != null)
            {
                if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
                {
                    ret = true;
                }
            }
            return ret;
        }

        /// <summary>
        /// compara un alumno y una clase, un Alumno será distinto a un EClase sólo si no toma esa clase.
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">EClases</param>
        /// <returns> Devuelve true si son distintos y false si son iguales</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool ret = false;
            if ((object)a != null && (object)clase != null)
            {
                if (a.claseQueToma != clase )
                {
                    ret = true;
                }
            }
            return ret;
        }

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
    }
}
