using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using Clases_Abstractas;
using Excepciones;
using System.Diagnostics;
using System.Runtime.Remoting.Channels;

namespace Test_Unitarios
{
    [TestClass]
    public class Dni_Invalido
    {
        [TestMethod]
        public void Argentino_Con_Dni_Invalido()
        {
            try
            {
                Alumno alumno1 = new Alumno(1, "pepe", "sech", "90000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Alumno alumno2 = new Alumno(1, "pepe", "sech", "0", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Assert.Fail("Sin excepción para Nacionalidad invalida");
            }
            catch(NacionalidadInvalidaException e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        [TestMethod]
        public void Extranjero_Con_Dni_Invalido()
        {
            try
            {
                Alumno alumno1 = new Alumno(1, "pepe", "sech", "99999999", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Alumno alumno2 = new Alumno(1, "pepe", "sech", "90000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Assert.Fail("Sin excepción para Nacionalidad invalida");
            }
            catch (NacionalidadInvalidaException e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }



    }
}
