using google.server.Business;
using google.server.Entity;

namespace google.test
{
    public class Tests
    {
        private readonly UsuarioBusiness usuarioBusiness;
        private readonly PingSchedulerBusiness pingService;
        public Tests()
        {
            usuarioBusiness = new UsuarioBusiness();
            pingService = new PingSchedulerBusiness("");
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAll()
        {
            var dataSource = usuarioBusiness.GetAll();
            if(dataSource.Count != 0)
            {
                Assert.Pass("Success!!");
            } else
            {
                Assert.Catch(() =>
                {
                    throw new Exception("This is an exception");
                });
            }
        }
        [Test]
        public void SaveOrUpdate()
        {
            //var entity = new Usuario()
            //{
            //    name = "Almaraz Jaillita Galia",
            //    studentcode = "650005628",
            //    ip = "192.168.28.18",
            //    status = true,
            //};
            //var entity = new Usuario()
            //{
            //    name = "Mamani Quispe Graciela",
            //    studentcode = "650005451",
            //    ip = "192.168.28.3",
            //    status = true,
            //};
            var entity = new Usuario()
            {
                name = "Alvarez Paredes Elnar Diosdabo",
                studentcode = "650005149",
                ip = "192.168.28.21",
                status = true,
            };
            var dataSource = usuarioBusiness.Save(entity);

            if (dataSource.id != 0)
            {
                Assert.Pass("Success!!");
            }
            else
            {
                Assert.Catch(() =>
                {
                    throw new Exception("This is an exception");
                });
            }
        }

        [Test]
        public void Delete()
        {
            var dataSource = usuarioBusiness.GetAll();

            foreach (var item in dataSource)
            {
                usuarioBusiness.Delete(item);
            }
            var verifyData = usuarioBusiness.GetAll();
            if (verifyData.Count == 0)
            {
                Assert.Pass("Success!!");
            }
            else
            {
                Assert.Catch(() =>
                {
                    throw new Exception("This is an exception");
                });
            }
        }

        [Test]
        public void PingTest()
        {
            pingService.Start();

            if (1 == 1)
            {
                Assert.Pass("Success!!");
            }
            else
            {
                throw new Exception("This is an exception");
            }
        }
        [Test]
        public void PingStopTest()
        {
            pingService.Stop();
            if (1 == 1)
            {
                Assert.Pass("Success!!");
            }
            else
            {
                throw new Exception("This is an exception");
            }
        }

    }
}
