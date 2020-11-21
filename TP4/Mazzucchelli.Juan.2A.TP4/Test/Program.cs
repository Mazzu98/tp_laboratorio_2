using Entidades;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Comercio comercio = new Comercio(5);
            Laptop l1 = new Laptop(1, ETipoPc.Laptop,EGama.Alta,100000, true);
            Laptop l2 = new Laptop(2, ETipoPc.Laptop, EGama.Media, 70000, false);
            Laptop l3 = new Laptop(3, ETipoPc.Laptop, EGama.Baja, 50000, false);
            Desktop d1 = new Desktop(4, ETipoPc.Desktop, EGama.Alta, 80000, true);
            Desktop d2 = new Desktop(5, ETipoPc.Desktop, EGama.Alta, 80000, true);
            Desktop d3 = new Desktop(6, ETipoPc.Desktop, EGama.Media, 60000, false);
            
            comercio += l1;

            //computadora repetida
            try
            {
                comercio += l1;
            }
            catch (CompuRepetidaException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Agrego computadoras
            comercio += l2;
            comercio += d1;
            comercio += l3;
            comercio += d3;

            //Intento agregar sin espacio
            try
            {
                comercio += d2;
            }
            catch(NoEspacioException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Intento eliminar una computadora inexistente
            try
            {
                comercio -= d2;
            }
            catch (ComercioSinComputadora ex)
            {
                Console.WriteLine(ex.Message);
            }

            //vendo d1
            Comercio.Vender(comercio, d1);

            //Intento vender d1 sin que esté en el comercio
            try
            {
                Comercio.Vender(comercio, d1);
            }
            catch(SinStockException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\n\n");
            }

            //Imprimo comercio
            Console.WriteLine(comercio.ToString());

            Console.ReadKey();
            Console.Clear();
            //Guardo comercio en un xml
            try
            {
                Comercio.Guardar("comercio.xml",comercio);
                Console.WriteLine("Archivo de Universidad guardado.");
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.ReadKey();
        }
    }
}
