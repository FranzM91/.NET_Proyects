using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upea.server.Interfaces
{
    public interface IUsuarioRepository<Usuario>
    {
        bool ValidarUsuario(Usuario data);
        bool ValidarControlador(Usuario data, string nombreControlador);
    }
}
