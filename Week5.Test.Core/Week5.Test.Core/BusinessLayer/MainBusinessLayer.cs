using System;
using System.Collections.Generic;
using System.Text;
using Week5.Test.Core.Interfaces;
using Week5.Test.Core.Models;

namespace Week5.Test.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IPiattoRepository piattoRepository;
        private readonly IUserRepository userRepository;

        public MainBusinessLayer(IPiattoRepository piattoRepo, IUserRepository userRepo)
        {
            this.piattoRepository = piattoRepo;
            this.userRepository = userRepo;
        }

        #region Piatti
        public PiattoResult Create(Piatto newPiatto)
        {
            if (newPiatto == null)
                throw new ArgumentNullException("Invalid item");
            var result = piattoRepository.Create(newPiatto);
            if (result)
                return new PiattoResult
                {
                    Success = result,
                    Message = ""
                };
            return new PiattoResult
            {
                Success = result,
                Message = "Cannot add new dish"
            };

        }

        public PiattoResult Delete(Piatto piattoToDelete)
        {
            if (piattoToDelete == null)
                throw new ArgumentNullException("invalid item");
            var result = piattoRepository.Delete(piattoToDelete);
            if (result)
                return new PiattoResult
                {
                    Success = result,
                    Message = ""
                };
            return new PiattoResult
            {
                Success = result,
                Message = "Cannot delete the dish"
            };
        }

        public Piatto FetchById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid item");
            return piattoRepository.GetById(id);
        }

        public IEnumerable<Piatto> FetchPiatti()
        {
            return piattoRepository.FetchAll();
        }

        public PiattoResult Update(Piatto piattoToUpdate)
        {
            if (piattoToUpdate == null)
                throw new ArgumentNullException("Invalid item");
            var result = piattoRepository.Update(piattoToUpdate);
            if (result)
                return new PiattoResult
                {
                    Success = result,
                    Message = ""
                };
            return new PiattoResult
            {
                Success = result,
                Message = "Cannot update the dish"
            };
        }

        #endregion


        public User GetUserByUsername(string username)
        {
            if (String.IsNullOrEmpty(username))
                throw new ArgumentException("Invalid username");
            User user = userRepository.GetUserByUsername(username);
            if (user == null)
                throw new ArgumentNullException("User not found");
            return user;
        }

        //per la registrazione utente
        public bool Create(User newUser)
        {
            if (newUser == null)
                throw new ArgumentNullException("Invalid user");
            User isInList = userRepository.GetUserByUsername(newUser.Username);
            if (isInList != null)
                return false;
            userRepository.Create(newUser);
            return true;

        }
    }
}
