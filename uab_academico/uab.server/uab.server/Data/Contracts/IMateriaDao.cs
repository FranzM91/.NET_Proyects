using System.Collections.Generic;
using uab.server.Entities;

namespace uab.server.Data.Contracts
{
    public interface IMateriaDao: IGenericDao<Materia>
    {
        List<Materia> SearchByFilter(string filter);
    }
}
