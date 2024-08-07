using manilab.core.entityframework;
using manilab.Entities;
using manilab.interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace manilab.server
{
    public class UsersServices : EFAdapterBase<Users>, IUsersService
    {
        public UsersServices(DbContext context) : base(context)
        {
        }
        public Users CreateUser(Users item)
        {
            Users user = FindByEmail(item.email);
            if (user != null)
            {
                throw new Exception("ya existe un usuario con el mismo email");
            };
            return Create(item);
        }

        public Users FindByEmail(string email)
        {
            if (email == null)
            {
                throw new Exception("email is undefined");
            };
            return FindOne(src => src.email == email);
        }

        public Users login(string email, string password)
        {
            if (email == null)
            {
                throw new Exception("email is undefined");
            };
            if (password == null)
            {
                throw new Exception("password is undefined");
            };
            return FindOne(src => src.email == email && src.password == password);
        }

        public bool userExists(string id)
        {
            return context.Set<Users>().Count(src => src.id == id) > 0;
        }
        //public List<User> GetAll()
        //{
        //    return context.Set<User>().ToList();
        //}

        public List<Users> SearchItems(string typeSearch, bool isAll, string filter, string listAuthor, string listEditorial, string listYear,
            string listDestriptor, string listIndexer, int page, int limit)
        {
            //exec dbo.lg_search_data typeSearch/isAll/filter/author/editorial/year/listDestriptor/listIndexer/page/pagesize
            var listSearch = context.Database.SqlQuery<Users>(
                string.Format("exec dbo.lg_search_data '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', {8}, {9}",
                typeSearch, isAll, filter, listAuthor, listEditorial, listYear, listDestriptor, listIndexer, page, limit)).ToList();
            return listSearch;
        }

        public Users Save(Users data)
        {
            return context.Set<Users>().Add(data);
        }
    }
}
