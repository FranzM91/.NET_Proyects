using uab.server.Business;
using uab.server.Entities;

namespace uab.server.test
{
    public class Tests
    {
        public readonly TodoAppBusiness todoAppBusiness;
        public Tests()
        {
            todoAppBusiness = new TodoAppBusiness();
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Save()
        {
            var data = new TodoApp()
            {
                Descripcion = "guardando nuevo dato",
                Estado = true,
                Visible = true,
                FechaCreacion = DateTime.Now,
                FechaActualizacion = DateTime.Now
            };

            todoAppBusiness.SaveOrUpdate(data);

            Assert.IsTrue(data.Id != 0);
        }

        [Test]
        public void Get()
        {
            var result = todoAppBusiness.GetById(1009);
            Assert.IsTrue(result.Id != 0);
        }
    }
}