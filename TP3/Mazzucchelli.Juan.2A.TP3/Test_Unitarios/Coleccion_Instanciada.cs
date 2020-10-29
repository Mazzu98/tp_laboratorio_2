using System;
using Clases_Instanciables;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace Test_Unitarios
{
    [TestClass]
    public class Coleccion_Instanciada
    {
        [TestMethod]
        public void Lista_Alumnos()
        {
            try
            {
                Universidad universidad = new Universidad();
                Assert.IsNotNull(universidad.Alumnos);
            }
            catch(NullReferenceException e)
            {
                
                Assert.Fail("La lista Alumnos de Universidad no fue instanciada");
            }
           
            
        }
    }
}
