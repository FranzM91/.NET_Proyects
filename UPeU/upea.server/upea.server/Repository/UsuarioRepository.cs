using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using upea.server.Interfaces;

namespace upea.server.Repository
{
    public class UsuarioRepository : IUsuarioRepository<Usuario>
    {
        public bool ValidarControlador(Usuario data, string nombreControlador)
        {
            if (data.nombre.ToUpper() == "ADMIN" && nombreControlador.ToUpper() == "COMPRA" ) 
            { 
                return true;
            }

            if (data.nombre.ToUpper() == "ADMIN" && nombreControlador.ToUpper() == "VENTA")
            {
                return true;
            }

            if (data.nombre.ToUpper() == "ADMIN" && nombreControlador.ToUpper() == "GESTION")
            {
                return true;
            }

            if (data.nombre.ToUpper() == "SECRE" && nombreControlador.ToUpper() == "GESTION")
            {
                return true;
            }
            return false;
        }

        public bool ValidarUsuario(Usuario data)
        {
            //throw new NotImplementedException();
            //primer control
            if (data.password.Length < 4 && data.nombre.Length < 4)
            {
                return false;
            }
            if (data.nombre.ToUpper() == "ADMIN" && data.password.ToUpper() == "123456")
            {
                return true;
            }

            if (data.nombre.ToUpper() == "SECRE" && data.password.ToUpper() == "654321")
            {
                return true;
            }

            return false;
        }
    }
}
