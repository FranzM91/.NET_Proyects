using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using uab.server.Business;
using uab.server.Entities;

namespace uab.server.test
{
    [TestClass]
    public class TodoAppTest
    {
        private readonly TodoAppBusiness repositorio;
        public TodoAppTest()
        {
            repositorio = new TodoAppBusiness();
        }
        [TestMethod]
        public void Save()
        {
            var data = new TodoApp()
            {
                Descripcion = "test 19082024",
                Estado = true,
                Visible = true,
                FechaCreacion = new DateTime(),
                FechaActualizacion = new DateTime()
            };

            repositorio.SaveOrUpdate(data);

            Assert.IsTrue(data.Id != 0);
        }
    }
}
