using NHibernate.Criterion;
using System.Collections.Generic;
using System.Linq;
using uab.server.Data.Contracts;
using uab.server.Entities;

namespace uab.server.Data
{
    public class TodoAppDao: GenericDao<TodoApp>, ITodoAppDao
    {
        public int ContarActiviades(int usuarioId)
        {
            var resultado = session.QueryOver<TodoApp>()
                            .Where(src => src.Usuario.Id == usuarioId);

            return resultado.List().ToList().Count();
        }

        public IList<TodoApp> GetAll()
        {
            var resultado = session.QueryOver<TodoApp>();
            return resultado.List();
        }

        public IList<TodoApp> SearchByDescription(string description)
        {
            var result = session.QueryOver<TodoApp>()
                .Where(src => src.Descripcion.IsLike(description, MatchMode.Anywhere));
            return result.List();
        }
    }
}
