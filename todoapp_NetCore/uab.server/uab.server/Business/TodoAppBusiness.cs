using uab.server.Data;
using uab.server.Data.Contracts;
using uab.server.Entities;

namespace uab.server.Business
{
    public class TodoAppBusiness
    {
        private readonly ITodoAppDao repository;
        public TodoAppBusiness()
        {
            repository = new TodoAppDao();
        }
        public TodoApp SaveOrUpdate(TodoApp data)
        {
            // opcion 1
            var dato = new TodoApp();
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
        }
        public TodoApp GetById(int entityId)
        {
            return repository.GetById(entityId);
        }
        public void DeleteById(int entityId)
        {
            repository.DeleteById(entityId);
        }
    }
}
