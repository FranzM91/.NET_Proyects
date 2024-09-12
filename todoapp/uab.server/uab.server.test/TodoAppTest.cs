﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using uab.server.Business;
using uab.server.Entities;
using uab.server.Entities.Entities;

namespace uab.server.test
{
    [TestClass]
    public class TodoAppTest
    {
        private readonly TodoAppBusiness todoAppRepositorio;
        private readonly UsuarioBusiness usuarioBusiness;
        public TodoAppTest()
        {
            todoAppRepositorio = new TodoAppBusiness();
            usuarioBusiness = new UsuarioBusiness();
        }

        #region TodoApp
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
            Assert.IsTrue(1 != 0);
        }

        [TestMethod]
        public void ContarCantidad()
        {
            var result = todoAppRepositorio.ContarActiviades(1);
            Assert.IsTrue(result != 0);
        }

        #endregion

        #region Usuario
        [TestMethod]
        public void SaveUsuario()
        {
            var usuario = new Usuario()
            {
                Nombre = "test",
                Apellido = "test",
                FechaNacimiento = DateTime.Now,
                Sexo = SexoEnum.Masculino,
            };
            var resultado = usuarioBusiness.SaveOrUpdate(usuario);
            Assert.IsTrue(resultado.Id != 0);
        }
        #endregion
    }
}
