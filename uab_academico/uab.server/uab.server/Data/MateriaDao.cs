using NHibernate.Criterion;
using System.Collections.Generic;
using System.Linq;
using uab.server.Data.Contracts;
using uab.server.Entities;

namespace uab.server.Data
{
    public class MateriaDao: GenericDao<Materia>, IMateriaDao
    {
        public List<Materia> SearchByFilter(string filter)
        {
            var resultado = session.QueryOver<Materia>()
                            .Where(src => src.Nombre.IsLike(filter, MatchMode.Anywhere));
            return resultado.List().ToList();
        }
    }
}
