using System;
using Clases_Instanciables;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Test_Unitarios
{
    [TestClass]
    public class Sin_Profesor
    {
        [TestMethod]
        public void Sin_Profesor_Universidad_Vacia()
        {
            try
            {
                Universidad universidad = new Universidad();
                Profesor profe1 = universidad == Universidad.EClases.Laboratorio;
                Profesor profe2 = universidad == Universidad.EClases.SPD;
                Profesor profe3 = universidad == Universidad.EClases.Legislacion;
                Profesor profe4 = universidad == Universidad.EClases.Programacion;
                Assert.Fail("Sin excepción para Sin Profesor");
            }
            catch (SinProfesorException e)
            {
                Assert.IsInstanceOfType(e, typeof(SinProfesorException));
            }
        }
    }
}
