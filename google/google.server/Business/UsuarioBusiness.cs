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

        public List<string> getAllIps()
        {
            var allIps = repository.GetAll().Select(src => src.ip).ToList();
            return allIps;
        }

        public Usuario getByIp(string ip)
        {
            return repository.getByIp(ip);
        }

        public Usuario Save(Usuario entity)
        {
            if(entity.id == 0)
            {
                entity.created_at = DateTime.Now;
                return repository.Save(entity);
            }
            else
            {
                entity.updated_at = DateTime.Now;
                return repository.Update(entity);
            }
        }

        public void Delete(Usuario entity)
        {
            repository.Delete(entity);
        }
    }
}
