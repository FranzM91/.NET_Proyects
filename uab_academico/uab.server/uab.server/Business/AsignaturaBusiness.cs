using System.Collections.Generic;
using uab.server.Data;
using uab.server.Data.Contracts;
using uab.server.Entities;

namespace uab.server.Business
{
    public class AsignaturaBusiness
    {
        private readonly IAsignaturaDao repository;
        public AsignaturaBusiness()
        {
            repository = new AsignaturaDao();
        }
        public List<Asignatura> SearchByFilter(int usuarioId)
        {
            return repository.SearchByUsuario(usuarioId);
        }
        public Asignatura SaveOrUpdate(Asignatura data)
        {
            // opcion 1
            var dato = new Asignatura();
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
        public Asignatura GetById(int entityId)
        {
            return repository.GetById(entityId);
        }
        public void DeleteById(int entityId)
        {
            repository.DeleteById(entityId);
        }
    }
}
