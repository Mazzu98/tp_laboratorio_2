using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        public string Apellido 
        { 
            get { return apellido; } 
            set { apellido = ValidarNombreApellido(value); } 
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = ValidarNombreApellido(value); }
        }

        public int DNI
        {
            get { return dni; }
            set 
            {
             dni = ValidarDni(nacionalidad,value); 
            }
        }

        public string StringToDNI
        {
            set
            {
            
             dni = ValidarDni(nacionalidad, value);
  
            }
        }

        public ENacionalidad Nacionalidad 
        {
            get { return nacionalidad; }
            set { nacionalidad = value; } 
        }

        /// <summary>
        /// Inicializa los valores por default que tendrá Persona
        /// </summary>
        public Persona()
        {
            this.nacionalidad = ENacionalidad.Argentino;
            this.apellido = "";
            this.nombre = "";
            this.dni = 0;
        }

        /// <summary>
        /// Inicializa Persona con los valores recibidos
        /// </summary>
        /// <param name="nombre">string</param>
        /// <param name="apellido">string</param>
        /// <param name="nacionalidad">ENacionalidad</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Inicializa Persona con los valores recibidos
        /// </summary>
        /// <param name="nombre">string</param>
        /// <param name="apellido">string</param>
        /// <param name="dni">int</param>
        /// <param name="nacionalidad">ENacionalidad</param>
        public Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad) :this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Inicializa Persona con los valores recibidos
        /// </summary>
        /// <param name="nombre">string</param>
        /// <param name="apellido">string</param>
        /// <param name="dni">string</param>
        /// <param name="nacionalidad">ENacionalidad</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Valida que la nacionalidad coincida con el dni
        /// </summary>
        /// <param name="nacionalidad">Enacionalidad</param>
        /// <param name="dato">int</param>
        /// <returns>devuelve el dni validado y si no lo es lanza una excepcion</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int ret = 0;
            if(nacionalidad == ENacionalidad.Argentino)
            {
                if(dato < 89999999 && dato > 0)
                {
                    ret = dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }
            else if (nacionalidad == ENacionalidad.Extranjero)
            {
                if (dato < 99999999 && dato > 90000000)
                {
                    ret = dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }
            return ret;
        }

        /// <summary>
        /// Valida que el string dni sea correcto y que la nacionalidad tambien lo sea
        /// </summary>
        /// <param name="nacionalidad">Enacionalidad</param>
        /// <param name="dato">string</param>
        /// <returns>devuelve el dni validado y si no lo es lanza una excepcion</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int ret = 0;
            bool esNumero;
            int dni;
            esNumero = int.TryParse(dato, out dni);
            if(esNumero && dato.Length < 9)
            {
                ret = ValidarDni(nacionalidad, dni);
            }
            else
            {
                throw new DniInvalidoException();
            }
            return ret;
        }

        /// <summary>
        /// Valida que el string contenga solo caracteres
        /// </summary>
        /// <param name="dato">string</param>
        /// <returns>devuelve el string validado si es correcto y si no devuelve un sttring vacio</returns>
        private string ValidarNombreApellido(string dato)
        {
            string ret = "";
            bool esValido = true;
            foreach (char ch in dato)
            {
                if (!Char.IsLetter(ch))
                {
                    esValido = false;
                    break;
                }
            }
            if(esValido)
            {
                ret = dato;
            }

            return ret;
        }

        /// <summary>
        /// Convierte Persona a string
        /// </summary>
        /// <returns>devuelve un string con todos los datos de Persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"NOMBRE COMPLETO: {this.apellido},{this.Nombre}");
            sb.AppendLine($"NACIONALIDAD: {this.nacionalidad}");

            return sb.ToString();
        }

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
    }
}
