﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                Descripcion = "test 21082024",
                Estado = true,
                Visible = true,
                FechaCreacion = DateTime.Now,
                FechaActualizacion = DateTime.Now
            };

            repositorio.SaveOrUpdate(data);

            Assert.IsTrue(data.Id != 0);
        }

        [TestMethod]
        public void GetAll()
        {
            var result = repositorio.GetById(5);

            Assert.IsTrue(result.Id != 0);
        }
    }
}
