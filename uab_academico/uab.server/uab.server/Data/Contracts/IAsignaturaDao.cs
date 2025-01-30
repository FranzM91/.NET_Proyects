using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uab.server.Entities;

namespace uab.server.Data.Contracts
{
    public interface IAsignaturaDao : IGenericDao<Asignatura>
    {
        List<Asignatura> SearchByUsuario(int studentId);
    }
}
