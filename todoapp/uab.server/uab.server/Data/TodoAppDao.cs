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
    }
}
