using google.server.Business;

namespace google.test
{
    public class Tests
    {
        private readonly UsuarioBusiness usuarioBusiness;
        public Tests()
        {
            usuarioBusiness = new UsuarioBusiness();
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
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
    }
}
