using Microsoft.VisualStudio.TestTools.UnitTesting;
using uab.server.Business;
using uab.server.Entities;

namespace uab.server.test
{
    [TestClass]
    public class AcademicoTest
    {
        private readonly MateriaBusiness todoAppRepositorio;
        private readonly UsuarioBusiness usuarioBusiness;
        public AcademicoTest()
        {
            todoAppRepositorio = new MateriaBusiness();
            usuarioBusiness = new UsuarioBusiness();
        }

        #region Materia
        [TestMethod]
        public void Save()
        {
            /*
             * Investigación I
             * Arquitectura de Software 
             * Teoría General de Sistemas 
             * Ciencia y Biblia 
             * Tecnologías en Internet 
             * Auditoría y Seguridad de Sistemas
             */
            var data = new Materia()
            {
                Nombre = "Investigación I",
                Descripcion = "Semestre VI",
            };

            todoAppRepositorio.SaveOrUpdate(data);

            Assert.IsTrue(data.Id != 0);
        }
        [TestMethod]
        public void GetById()
        {
            var data = todoAppRepositorio.GetById(1008);
            Assert.IsTrue(data.Id != 0);
        }

        [TestMethod]
        public void DeleteById()
        {
            //llamar al metodo delete()
            todoAppRepositorio.DeleteById(4359);
            Assert.IsTrue(1 != 0);
        }

        #endregion

        #region Usuario
        [TestMethod]
        public void SaveUsuario()
        {
            var usuario = new Usuario()
            {
                Id = 0,
                NombreCompleto = "test",
                Codigo = "test",
            };
            var resultado = usuarioBusiness.SaveOrUpdate(usuario);
            Assert.IsTrue(resultado.Id != 0);
        }
        #endregion

        #region Asignaturas

        #endregion
    }
}
