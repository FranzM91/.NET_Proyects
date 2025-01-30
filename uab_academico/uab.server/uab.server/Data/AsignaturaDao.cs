using NHibernate.Criterion;
using System.Collections.Generic;
using System.Linq;
using uab.server.Data.Contracts;
using uab.server.Entities;

namespace uab.server.Data
{
    public class AsignaturaDao: GenericDao<Asignatura>, IAsignaturaDao
    {
        public List<Asignatura> SearchByUsuario(int studentId)
        {
            var result = session.QueryOver<Asignatura>()
                            .Where(src => src.Usuario.Id == studentId);
            return result.List().ToList();
        }
    }
}
