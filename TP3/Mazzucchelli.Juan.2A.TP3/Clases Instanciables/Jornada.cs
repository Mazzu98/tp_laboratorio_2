using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clases;
        private Profesor instructor;

        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { alumnos = value; }
        }
        public Universidad.EClases Clases 
        { 
            get { return clases; } 
            set { clases = value; } 
        }
        public Profesor Instructor
        {
            get { return instructor; }
            set { instructor = value; }
        }

        /// <summary>
        /// Inicializa la coleccion que tendrá Jornada
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Inicializa Jornada con los valores recibidos
        /// </summary>
        /// <param name="clase">EClases</param>
        /// <param name="instructor">Profesor</param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.clases = clase;
            this.instructor = instructor;
        }

        /// <summary>
        /// compara una Jornada y un Alumno, Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns> Devuelve true si el alumno participa en la clase y false si no participa</returns>
        public static bool operator ==(Jornada j,Alumno a)
        {
            bool ret = false;
            if((object)j != null)
            {
                foreach(Alumno alumno in j.alumnos)
                {
                    if( (Universitario)alumno == (Universitario)a)
                    {
                        ret = true;
                        break;
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// compara una Jornada y un Alumno, Una Jornada será distinto a un Alumno si el mismo no participa de la clase.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns> Devuelve true si el alumno no participa en la clase y false si participa</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega Alumnos a la clase, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns> Devuelve la Jornada</returns>
        public static Jornada operator +(Jornada j,Alumno a)
        {
            if((object)j != null && (object)a != null)
            {
                if(j != a)
                {
                    j.alumnos.Add(a);
                }
            }
            return j;
        }

        /// <summary>
        /// Guarda en un archivo la jornada
        /// </summary>
        /// <param name="jornada">Jornada</param>
        /// <returns> Devuelve true si pudo guardar y false si no</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool ret = false ;
            Texto texo = new Texto();
            ret = texo.Guardar("jornada.txt", jornada.ToString());
            return ret;
        }

        /// <summary>
        /// Lee el archivo de la Jornada
        /// </summary>
        /// <returns> Devuelve un string con el contenido del archivo</returns>
        public static string Leer()
        {
            string jornada;
            Texto texo = new Texto();
            texo.Leer("jornada.txt", out jornada);

            return jornada;
        }

        /// <summary>
        /// Convierte Jornada a string
        /// </summary>
        /// <returns> devuelve un string con todos los datos de la Jornada </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"CLASES DE {this.clases}");
            sb.AppendLine($" POR {this.instructor}");

            foreach (Alumno alumno in this.alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }

            return sb.ToString();
        }
    }
}
