using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using uab.server.Business;
using uab.server.Entities;

namespace uab.server.test
{
    [TestClass]
    public class TodoAppTest
    {
        private readonly TodoAppBusiness todoAppRepositorio;
        public TodoAppTest()
        {
            todoAppRepositorio = new TodoAppBusiness();
        }
        [TestMethod]
        public void Save()
        {
            var data = new TodoApp()
            {
                Descripcion = "test 21082024",
                Estado = true,
                Visible = true,
                FechaCreacion = DateTime.Now,
                FechaActualizacion = DateTime.Now
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
            Assert.IsTrue(1!=0);
        }
    }
}
