using google.server.Entity;

namespace google.server.Business.Contracts
{
    public interface IUsuarioRepository: IGenericRepository<Usuario>
    {
        List<Usuario> GetAll();
        Usuario getByIp(string ip);
    }
}
