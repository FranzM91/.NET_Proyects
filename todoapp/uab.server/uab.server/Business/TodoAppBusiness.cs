using uab.server.Data;
using uab.server.Data.Contracts;
using uab.server.Entities;

namespace uab.server.Business
{
    public class TodoAppBusiness
    {
        private readonly ITodoAppDao todoAppDao;
        public TodoAppBusiness()
        {
            todoAppDao = new TodoAppDao();
        }

        public TodoApp SaveOrUpdate(TodoApp data)
        {
            // opcion 1
            var dato = new TodoApp();
            if (data.Id == 0)
            {
                // nuevo dato
                dato = todoAppDao.Save(data);
            }
            else
            {
                // actualizar dato
                dato = todoAppDao.Update(data);
            }
            return dato;

            // opcion 2
            //return (data.Id == 0) 
            //        ? todoAppDao.Save(data) 
            //        : todoAppDao.Update(data);
        }
        public TodoApp GetById(int entityId)
        {
            return todoAppDao.GetById(entityId);
        }
        public void DeleteById(int entityId)
        {
            todoAppDao.DeleteById(entityId);
        }

        //public TodoApp ActualizarDato(TodoApp data)
        //{
        //    return todoAppDao.Update(data);
        //}
    }
}
