using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using upea.server.Interfaces;
using upea.server.Repository;

namespace upea.server.Business
{
    public class UsuarioBusiness
    {
        private readonly IUsuarioRepository<Usuario> repository;
        public UsuarioBusiness()
        {
            repository = new UsuarioRepository();
        }

        public bool ValidarUsuario(Usuario entity)
        {
            return repository.ValidarUsuario(entity);
        }

        public bool ValidarControlador(Usuario entity, string controlador)
        {
            return repository.ValidarControlador(entity, controlador);
        }
    }
}
