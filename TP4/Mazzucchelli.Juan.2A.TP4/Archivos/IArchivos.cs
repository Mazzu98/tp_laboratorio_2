namespace Archivos
{
    interface IArchivos<T>
    {
        /// <summary>
        /// guarda un archivo
        /// Proyecto Archivos – Clase IArchivos
        /// </summary>
        /// <param name="archivo">string</param>
        /// <param name="datos">out T</param>
        /// <returns> Devuelve true si se pudo guardar y false si no</returns>
        bool Guardar(string archivo,T datos);

        /// <summary>
        /// Lee un archivo
        /// </summary>
        /// <param name="archivo">string</param>
        /// <param name="datos">out T</param>
        /// <returns> Devuelve true si se pudo Leer y false si no</returns>
        bool Leer(string archivo,out T datos);
    }
}
