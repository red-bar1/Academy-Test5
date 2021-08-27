using System;
using System.Collections.Generic;
using System.Text;
using Week5.Test.Core.Models;

namespace Week5.Test.Core.Interfaces
{
    //dato che le operazioni CRUD sugli account non ci servono non implemento IRepository,
    //nel caso in cui arrivassi a fare la registrazione inserisco qui anche il metodo create
    public interface IUserRepository
    {
        bool Create(User newUser);
        User GetUserByUsername(string username);
    }
}
