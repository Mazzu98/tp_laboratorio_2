using Clases_Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        /// <summary>
        /// Inicializa random
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Inicializa los valores por default que tendrá Profesor
        /// </summary>
        public Profesor()
            :base()
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        /// <summary>
        /// Inicializa Profesor con los valores recibidos
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="nombre">string</param>
        /// <param name="apellido">string</param>
        /// <param name="dni">string</param>
        /// <param name="nacionalidad">ENacionalidad</param>
        public Profesor(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(legajo, nombre, apellido, dni, nacionalidad) 
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        /// <summary>
        /// Muestra los datos del Profesor
        /// </summary>
        /// <returns> Devuelve un string con los datos del Profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.Append(ParticiparEnClase());

            return sb.ToString();
            
        }

        /// <summary>
        /// las clases que da el Profesor
        /// </summary>
        /// <returns> Devuelve un sttring con las clases que da el Profesor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA: ");
            foreach (Universidad.EClases item in clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Convierte Profesor a String
        /// </summary>
        /// <returns> Devuelve un string con los datos del Profesor</returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

        /// <summary>
        /// Elige dos clases al azar y las agrega al queue del Profesor. 
        /// </summary>
        /// <returns> Sin retorno</returns>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
               
                switch(Profesor.random.Next(0, 4))
                {
                    case 0: 
                        this.clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                        break;
                    case 1:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                        break;
                    case 2:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                        break;
                    case 3:
                        this.clasesDelDia.Enqueue(Universidad.EClases.SPD);
                        break;
                }
            }
        }

        /// <summary>
        /// compara un Profesor y una Clase, un Profesor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">EClases</param>
        /// <returns> Devuelve true si da la clase y false si no la da</returns>
        public static bool operator ==(Profesor i,Universidad.EClases clase)
        {
            bool ret = false;
            if((object)i != null && (object)clase != null)
            {
                foreach (Universidad.EClases item in i.clasesDelDia)
                {
                    if(item == clase)
                    {
                        ret = true;
                        break;
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// compara un Profesor y una Clase, un Profesor será disttintto a un EClase si no da esa clase.
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">EClase</param>
        /// <returns> Devuelve true si no da la clase y false si la da</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i==clase);
        }
        
    }
}
