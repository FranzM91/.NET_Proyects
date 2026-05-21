using google.server.Business.Contracts;
using google.server.Entity;
using NHibernate.Linq;

namespace google.server.Data
{
    public class UsuarioRepository: GenericRepository<Usuario>, IUsuarioRepository
    {
        public Usuario? GetByFilter(string filter)
        {
            var result = Session.Query<Usuario>()
                .Where(src => src.name.Like(filter))
                .FirstOrDefault();
            return result;
        }

        public List<Usuario> GetAll()
        {
            return Session.Query<Usuario>().ToList();
        }

        public Usuario getByIp(string ip)
        {
            var result = Session.Query<Usuario>()
                .Where(src => src.ip.Like(ip))
                .FirstOrDefault();
            return result;
        }
    }
}
