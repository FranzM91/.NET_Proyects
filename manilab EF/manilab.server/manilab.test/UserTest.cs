using manilab.Entities;
using manilab.interfaces;
using manilab.server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace manilab.test
{
    [TestClass]
    public class UserTest
    {
        private readonly IUsersService service;
        public UserTest()
        {
            service = new UsersServices(new ManilabContext());
        }
        [TestMethod]
        public void CreateUser()
        {
            Users user = new Users
            {
                id = Guid.NewGuid().ToString(),
                name = "test",
                email = "test@mail.com",
                cel = "123456789",
                password = "123456"
            };

            try
            {
                service.Create(user);
                service.Commit();
            }
            catch (Exception e)
            {
                Assert.Fail("Error in create User", e.Message);
            }
        }

        [TestMethod]
        public void GetAllUser()
        {
            try
            {
                var data = service.GetAll();
                Assert.IsNotNull(data);
            }
            catch (Exception e)
            {
                Assert.Fail("Error in create User", e.Message);
            }
        }
    }
}
