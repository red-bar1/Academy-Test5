using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week5.Test.Core.Interfaces;
using Week5.Test.Core.Models;

namespace Week5.Test.EF.Repositories
{
    public class PiattoRepositoryEF : IPiattoRepository
    {
        private readonly RistoranteContext ctx;

        public PiattoRepositoryEF(RistoranteContext context)
        {
            ctx = context;
        }

        public bool Create(Piatto newItem)
        {
            if (newItem == null)
                throw new ArgumentNullException("Invalid item");
            try
            {
                ctx.Piatti.Add(newItem);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Delete(Piatto itemToDelete)
        {
            if (itemToDelete == null)
                throw new ArgumentNullException("Invalid item");
            try
            {
                ctx.Piatti.Remove(itemToDelete);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Piatto> FetchAll()
        {
            return ctx.Piatti.ToList();
        }

        public Piatto GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid id");
            try
            {
                return ctx.Piatti.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(Piatto itemToUpdate)
        {
            if (itemToUpdate == null)
                throw new ArgumentNullException("Invalid item");
            try
            {
                ctx.Entry(itemToUpdate).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
