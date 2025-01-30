using System.Collections.Generic;
using uab.server.Data;
using uab.server.Data.Contracts;
using uab.server.Entities;

namespace uab.server.Business
{
    public class MateriaBusiness
    {
        private readonly IMateriaDao repository;
        public MateriaBusiness()
        {
            repository = new MateriaDao();
        }
        public List<Materia> SearchByFilter(string filter)
        {
            return repository.SearchByFilter(filter);
        }
        public Materia SaveOrUpdate(Materia data)
        {
            // opcion 1
            var dato = new Materia();
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
        public Materia GetById(int entityId)
        {
            return repository.GetById(entityId);
        }
        public void DeleteById(int entityId)
        {
            repository.DeleteById(entityId);
        }
    }
}
