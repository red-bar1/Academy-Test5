using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week5.Test.Core.Interfaces;
using Week5.Test.Core.Models;

namespace Week5.Test.EF.Repositories
{
    public class UserRepositoryEF : IUserRepository
    {
        private readonly RistoranteContext ctx;

        public UserRepositoryEF(RistoranteContext context)
        {
            this.ctx = context;
        }

        //per registrazione utente
        public bool Create(User newUser)
        {
            if (newUser == null)
                throw new ArgumentNullException("Invalid item");
            try
            {
                ctx.Users.Add(newUser);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public User GetUserByUsername(string username)
        {
            if (String.IsNullOrEmpty(username))
                throw new ArgumentException("Invalid username");
            try
            {
                return ctx.Users.FirstOrDefault(u => u.Username.Equals(username));
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
