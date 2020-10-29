using Clases_Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Clases_Instanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public List<Alumno> Alumnos { get { return alumnos; } set { alumnos = value; } }
        public List<Jornada> Jornada { get { return jornada; } set { jornada = value; } }
        public List<Profesor> Profesores { get { return profesores; } set { profesores = value; } }

        public Jornada this[int indice]
        {
            get
            {
                if (indice >= this.jornada.Count || indice < 0)
                {
                    return null;
                }
                else
                {
                    return this.jornada[indice];
                }
            }

            set
            {
                if (indice >= 0 && indice < this.jornada.Count)
                {
                    this.jornada[indice] = value;
                }
                else if (indice == this.jornada.Count)
                {
                    this.jornada.Add(value);
                }
            }
        }

        /// <summary>
        /// Inicializa las colecciones que tendrá Universidad
        /// </summary>
        public Universidad()
        {
            jornada = new List<Jornada>();
            alumnos = new List<Alumno>();
            profesores = new List<Profesor>();
        }

        /// <summary>
        /// Muestra los datos de la Universidad
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns> Devuelve un string con los datos de la Universidad</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            foreach (Jornada jornada in uni.Jornada)
            {
                sb.Append(jornada.ToString());
                sb.AppendLine("<------------------------------------------------------------------>");
            }
            
            return sb.ToString();

            //TODO: Modificar
        }

        /// <summary>
        /// compara una Universidad y un Alumno, Seran iguales si el Alumno está en la universidad.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns> Devuelve true si pertenece a la universidad y false si no </returns>
        public static bool operator ==(Universidad g,Alumno a)
        {
            bool ret = false;
            if ((object) g != null)
            {
                foreach (Alumno alumno in g.alumnos)
                {
                    if (alumno == a)
                    {
                        ret = true;
                        break;
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// compara una Universidad y un Alumno, Seran Distintos si el Alumno no está en la universidad.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns> Devuelve true si no pertenece a la universidad y false si pertenece </returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// compara una Universidad y un Profesor, Seran iguales si el Profesor está en la universidad.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="p">Profesor</param>
        /// <returns> Devuelve true si pertenece a la universidad y false si no </returns>
        public static bool operator ==(Universidad g, Profesor p)
        {
            bool ret = false;
            if ((object)g != null)
            {
                foreach(Profesor profe in g.profesores)
                {
                    if (profe == p)
                    {
                        ret = true;
                        break;
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// compara una Universidad y un Profesor, Seran Distintos si el Profesor está en la universidad.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="p">Profesor</param>
        /// <returns> Devuelve true si no pertenece a la universidad y false si pertenece </returns>
        public static bool operator !=(Universidad g, Profesor p)
        {
            return !(g == p);
        }

        /// <summary>
        /// compara una Universidad y una clase, Seran iguales si la universidad tiene un profesor que de la materia.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="c">EClases</param>
        /// <returns> Devuelve true si tiene un profesor y false si no </returns>
        public static Profesor operator ==(Universidad g, EClases c)
        {
            Profesor ret = null;
            if((object)g != null)
            {
                foreach(Profesor profesor in g.Profesores)
                {
                    if(profesor == c)
                    {
                        ret = profesor;
                        break;
                    }
                }
            }
            if((object)ret == null)
            {
                throw new SinProfesorException();
            }
            return ret;
        }

        /// <summary>
        /// compara una Universidad y una clase, Seran disttintos si la universidad no tiene un profesor que de la materia.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="c">EClases</param>
        /// <returns> Devuelve true si no tiene un profesor y false si tiene</returns>
        public static Profesor operator !=(Universidad g, EClases c)
        {
            Profesor ret = null;
            if ((object)g != null)
            {
                foreach (Profesor profesor in g.Profesores)
                {
                    if (profesor != c)
                    {
                        ret = profesor;
                        break;
                    }
                }
            }
            
            return ret;
        }

        /// <summary>
        /// Agrega una clase a la universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="c">EClases</param>
        /// <returns> Devuelve la universidad </returns>
        public static Universidad operator +(Universidad g, EClases c)
        {
            bool hayProfe = false;
            foreach(Profesor profe in g.profesores)
            {
                if (profe == c)
                {
                    Jornada nuevaJornada = new Jornada(c, profe);
                    foreach(Alumno alumno in g.alumnos)
                    {
                        if(alumno == c)
                        {
                            nuevaJornada.Alumnos.Add(alumno);
                        }
                    }
                    g.Jornada.Add(nuevaJornada);
                    hayProfe = true;
                    break;
                }
            
            }
            if(!hayProfe)
            {
                throw new SinProfesorException();
            }
            return g;
        }

        /// <summary>
        /// Agrega un alumno a la universidad.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns> Devuelve la universidad </returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
          
            return g;
        }

        /// <summary>
        /// Agrega un Profesor a la universidad.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns> Devuelve la universidad </returns>
        public static Universidad operator +(Universidad g, Profesor i)
        { 
            if (g != i)
            {
                g.profesores.Add(i);
            }
            return g;
        }

        /// <summary>
        /// Guarda en un archivo la Universidad
        /// </summary>
        /// <param name="universidad">Universidad</param>
        /// <returns> Devuelve true si pudo guardar y false si no</returns>
        public static bool Guardar(Universidad universidad)
        {
            bool ret = false;
            Xml<Universidad> xml = new Xml<Universidad>();
            Texto texo = new Texto();
            ret = xml.Guardar("universidad.xml", universidad) && texo.Guardar("universidad.txt", universidad.ToString());
            return ret;
        }

        /// <summary>
        /// Lee el archivo de la Universidad
        /// </summary>
        /// <returns> Devuelve un string con el contenido del archivo</returns>
        public static string Leer()
        {
            Universidad universidad = new Universidad();
            Xml<Universidad> xml = new Xml<Universidad>();

            xml.Leer("jornada.txt", out universidad);
            return universidad.ToString();
        }

        /// <summary>
        /// Convierte Universidad a string
        /// </summary>
        /// <returns> devuelve un string con todos los datos de la Universidad </returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
    }
}
