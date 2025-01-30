using System.Collections.Generic;
using uab.server.Entities;

namespace uab.server.Data.Contracts
{
    public interface IUsuarioDao: IGenericDao<Usuario>
    {
        List<Usuario> SearchAll(string filter);
    }
}
