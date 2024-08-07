using manilab.core.interfaces;
using manilab.Entities;
using System;

namespace manilab.interfaces
{
    public interface IUsersService : IAdapterBase<Users>
    {
        bool userExists(string id);
        Users login(string email, string password);
        Users FindByEmail(String email);
        Users CreateUser(Users item);
    }
}
