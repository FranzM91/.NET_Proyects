using NHibernate.Criterion;
using System.Collections.Generic;
using System.Linq;
using uab.server.Data.Contracts;
using uab.server.Entities;

namespace uab.server.Data
{
    public class UsuarioDao: GenericDao<Usuario>, IUsuarioDao
    {
        public List<Usuario> SearchAll(string filter)
        {
            var result = session.QueryOver<Usuario>()
                            .Where(src => src.Codigo.IsLike(filter, MatchMode.Anywhere) || src.NombreCompleto.IsLike(filter, MatchMode.Anywhere));
            return result.List().ToList();
        }
    }
}
