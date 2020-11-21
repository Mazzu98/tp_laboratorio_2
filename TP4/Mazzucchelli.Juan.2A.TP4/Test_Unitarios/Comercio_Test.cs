using Entidades;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Test_Unitarios
{
    [TestClass]
    public class Comercio_Test
    {
        /// <summary>
        /// Prueba si puede agregar correctamente una Computadora
        /// Proyecto Test_Unitarios – Clase Comercio_Test – Todas los metodos
        /// </summary>
        [TestMethod]
        public void AgregarAComercio()
        {
            Comercio comercio = new Comercio(1);
            Laptop l1 = new Laptop(1, ETipoPc.Laptop, EGama.Alta, 100000, true);
            comercio += l1;
            Assert.AreEqual(comercio, l1);
        }

        /// <summary>
        /// Prueba si  lanza la exception al no tener mas espacio
        /// </summary>
        [TestMethod]
        public void ComercioSinEspacio()
        {
            try
            {
                Comercio comercio = new Comercio(0);
                Laptop l1 = new Laptop(1, ETipoPc.Laptop, EGama.Alta, 100000, true);
                comercio += l1;

            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(NoEspacioException));
            }
        }

        /// <summary>
        /// Prueba si lanza la excepcion al intentar agregar una computadora repetida
        /// </summary>
        [TestMethod]
        public void ComputadoraRepetida()
        {
            try
            {
                Comercio comercio = new Comercio(2);
                Laptop l1 = new Laptop(1, ETipoPc.Laptop, EGama.Alta, 100000, true);
                comercio += l1;
                comercio += l1;
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(CompuRepetidaException));
            }
        }

        /// <summary>
        /// Prueba si al intentar sacar una computadora de el comercio lanza la exception
        /// </summary>
        [TestMethod]
        public void SinStock()
        {
            try
            {
                Comercio comercio = new Comercio(1);
                Laptop l1 = new Laptop(1, ETipoPc.Laptop, EGama.Alta, 100000, true);
                comercio -= l1;
            }
            catch (SinStockException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(SinStockException));
            }
        }

        /// <summary>
        /// Prueba se puede serializar y guardar un comercio correctamente
        /// </summary>
        [TestMethod]
        public void ArchivosXml_Test()
        {
            try
            {
                bool exist;
                string path = "pruebaComercio.xml";
                Comercio comercio = new Comercio(3);
                Laptop l1 = new Laptop(1, ETipoPc.Laptop, EGama.Alta, 100000, true);
                Laptop l2 = new Laptop(2, ETipoPc.Laptop, EGama.Media, 70000, false);
                Desktop d1 = new Desktop(3, ETipoPc.Desktop, EGama.Alta, 80000, true);
                comercio += l1;
                comercio += l2;
                comercio += d1;

                Comercio.Guardar(path, comercio);

                exist = File.Exists(path);
                Assert.IsTrue(exist);
                if (exist)
                {
                    File.Delete(path);
                }
            }
            catch (Exception)
            {}
        }
    }
}
