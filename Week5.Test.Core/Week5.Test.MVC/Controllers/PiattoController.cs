using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week5.Test.Core.Interfaces;
using Week5.Test.Core.Models;
using Week5.Test.MVC.Models;

namespace Week5.Test.MVC.Controllers
{
    [Authorize]
    public class PiattoController : Controller
    {
        private readonly IBusinessLayer bl;

        public PiattoController(IBusinessLayer businessLayer)
        {
            this.bl = businessLayer;
        }



        public IActionResult Index()
        {
            var model = bl.FetchPiatti();
            return View(model);
        }

        #region Create
        //get
        [Authorize(Policy = "UserRistoratore")]
        public IActionResult Create()
        {
            return View();
        }

        //post
        [HttpPost]
        [Authorize(Policy = "UserRistoratore")]
        public IActionResult Create(PiattoViewModel newPiatto)
        {
            if (newPiatto == null)
                return View("Error", new ErrorViewModel());
            var result = bl.Create(new Piatto()
            {
                Nome = newPiatto.Nome,
                Descrizione = newPiatto.Descrizione,
                Tipologia = newPiatto.Tipologia,
                Prezzo = newPiatto.Prezzo
            });
            if (result.Success)
                return RedirectToAction("Index");
            return View();
        }

        #endregion

        #region Update
        //get
        [Authorize(Policy = "UserRistoratore")]
        public IActionResult Update(int id)
        {
            if (id <= 0)
                return View("Error", new ErrorViewModel());
            var piatto = bl.FetchById(id);
            if (piatto == null)
                return View("NotFound", new NotFoundViewModel()
                {
                    EntityId = id,
                    Message = "Please use another id."
                });
            return View(new PiattoViewModel()
            {
                Nome = piatto.Nome,
                Descrizione = piatto.Descrizione,
                Tipologia = piatto.Tipologia,
                Prezzo = piatto.Prezzo
            });
        }

        //post
        [HttpPost]
        [Authorize(Policy ="UserRistoratore")]
        public IActionResult Update(PiattoViewModel piattoToUpdate)
        {
            if (piattoToUpdate == null)
                return View("Error", new ErrorViewModel());
            var result = bl.Update(new Piatto()
            {
                Nome = piattoToUpdate.Nome,
                Descrizione = piattoToUpdate.Descrizione,
                Tipologia = piattoToUpdate.Tipologia,
                Prezzo = piattoToUpdate.Prezzo

            });
            if (result.Success)
                return RedirectToAction("Index");
            return View();
        }



        #endregion

        #region Delete
        //get
        [Authorize(Policy ="UserRistoratore")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return View("Error", new ErrorViewModel());
            var piatto = bl.FetchById(id);
            if (piatto == null)
                return View("NotFound", new NotFoundViewModel()
                {
                    EntityId = id,
                    Message = "Please try another id"
                });
            return View(piatto);

        }
        
        //post
        [HttpPost]
        [Authorize(Policy ="UserRistoratore")]
        public IActionResult Delete(Piatto piattoToDelete)
        {
            if (piattoToDelete == null)
                return View("Error", new ErrorViewModel());
            var piattoFromList = bl.FetchById(piattoToDelete.Id);
            if (piattoFromList == null)
                return View("NotFound", new NotFoundViewModel());
            var result = bl.Delete(piattoFromList);
            if (result.Success)
                return RedirectToAction("Index");
            return View();
        }

        #endregion

        public IActionResult Details(int id)
        {
            if (id <= 0)
                return View("Error", new ErrorViewModel());
            var piatto = bl.FetchById(id);
            if (piatto == null)
                return View("NotFound", new NotFoundViewModel()
                {
                    EntityId = id,
                    Message = "Please, try with a different id."
                });
            return View(piatto);

        }


    }
}
