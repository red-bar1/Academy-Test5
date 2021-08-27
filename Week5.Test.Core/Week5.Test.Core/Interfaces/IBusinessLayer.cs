using System;
using System.Collections.Generic;
using System.Text;
using Week5.Test.Core.Models;

namespace Week5.Test.Core.Interfaces
{
    public interface IBusinessLayer
    {
        #region Piatto
        IEnumerable<Piatto> FetchPiatti();
        Piatto FetchById(int id);
        PiattoResult Create(Piatto newPiatto);
        PiattoResult Update(Piatto piattoToUpdate);
        PiattoResult Delete(Piatto piattoToDelete);
        #endregion

        #region User
        bool Create(User newUser);
        User GetUserByUsername(string username);
        #endregion
    }
}
