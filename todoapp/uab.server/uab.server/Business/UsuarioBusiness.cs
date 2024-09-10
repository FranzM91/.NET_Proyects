using uab.server.Data;
using uab.server.Data.Contracts;
using uab.server.Entities;

namespace uab.server.Business
{
    public class UsuarioBusiness
    {
        private readonly IUsuarioDao repository;
        public UsuarioBusiness()
        {
            repository = new UsuarioDao();
        }

        public Usuario SaveOrUpdate(Usuario data)
        {
            // opcion 1
            var dato = new Usuario();
            if (data.Id == 0)
            {
                // nuevo dato
                dato = repository.Save(data);
            }
            else
            {
                // actualizar dato
                dato = repository.Update(data);
            }
            return dato;

            // opcion 2
            //return (data.Id == 0) 
            //        ? todoAppDao.Save(data) 
            //        : todoAppDao.Update(data);
        }
        public Usuario GetById(int entityId)
        {
            return repository.GetById(entityId);
        }
        public void DeleteById(int entityId)
        {
            repository.DeleteById(entityId);
        }

        //public TodoApp ActualizarDato(TodoApp data)
        //{
        //    return todoAppDao.Update(data);
        //}
    }
}
