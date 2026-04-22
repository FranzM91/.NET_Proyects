using google.server.Business.Contracts;
using google.server.Data;
using google.server.Entity;

namespace google.server.Business
{
    public class UsuarioBusiness
    {
        public readonly IUsuarioRepository repository;
        public UsuarioBusiness()
        {
            repository = new UsuarioRepository();
        }

        public List<Usuario> GetAll()
        {
            return repository.GetAll();
        }
    }
}
