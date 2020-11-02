using EntidadesAbstractas;
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
        public List<Profesor> Instructores { get { return profesores; } set { profesores = value; } }

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
        /// <param name="i">Profesor</param>
        /// <returns> Devuelve true si pertenece a la universidad y false si no </returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool ret = false;
            if ((object)g != null)
            {
                foreach(Profesor profe in g.profesores)
                {
                    if (profe == i)
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
        /// <param name="i">Profesor</param>
        /// <returns> Devuelve true si no pertenece a la universidad y false si pertenece </returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// compara una Universidad y una clase, Seran iguales si la universidad tiene un profesor que de la materia.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">EClases</param>
        /// <returns> Devuelve true si tiene un profesor y false si no </returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            Profesor ret = null;
            if((object)g != null)
            {
                foreach(Profesor profesor in g.Instructores)
                {
                    if(profesor == clase)
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
        /// <param name="clase">EClases</param>
        /// <returns> Devuelve true si no tiene un profesor y false si tiene</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            Profesor ret = null;
            if ((object)g != null)
            {
                foreach (Profesor profesor in g.Instructores)
                {
                    if (profesor != clase)
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
        /// <param name="clase">EClases</param>
        /// <returns> Devuelve la universidad </returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            bool hayProfe = false;
            foreach(Profesor profe in g.profesores)
            {
                if (profe == clase)
                {
                    Jornada nuevaJornada = new Jornada(clase, profe);
                    foreach(Alumno alumno in g.alumnos)
                    {
                        if(alumno == clase)
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
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns> Devuelve la universidad </returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
          
            return u;
        }

        /// <summary>
        /// Agrega un Profesor a la universidad.
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns> Devuelve la universidad </returns>
        public static Universidad operator +(Universidad u, Profesor i)
        { 
            if (u != i)
            {
                u.profesores.Add(i);
            }
            return u;
        }

        /// <summary>
        /// Guarda en un archivo la Universidad
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns> Devuelve true si pudo guardar y false si no</returns>
        public static bool Guardar(Universidad uni)
        {
            bool ret = false;
            Xml<Universidad> xml = new Xml<Universidad>();
            ret = xml.Guardar("universidad.xml", uni);

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
            xml.Leer("universidad.xml", out universidad);

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
