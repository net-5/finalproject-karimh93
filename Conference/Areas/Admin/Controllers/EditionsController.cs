using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conference.Areas.Admin.Models;
using Conference.Domain.Entities;
using Conference.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace Conference.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EditionsController : Controller
    {

        private IEditionService editions;

        public EditionsController(IEditionService editionService)
        {
            this.editions = editionService;
        }


        // GET: Editions
        public ActionResult Index()
        {
            IEnumerable<Editions> allEditions = editions.GetEditions();
            return View(allEditions);
        }

        // GET: Editions/Details/5
        public ActionResult Details(int id)
        {
            var getById = editions.GetById(id);

            EditionViewModel model = new EditionViewModel();
            model.InjectFrom(getById);

            return View(model);
        }

        // GET: Editions/Create
        public ActionResult Create()
        {
            //EditionViewModel model = new EditionViewModel();

            //var cr = editions.GetEditions();

            //ViewBag.Editions = cr;

            return View();
        }

        // POST: Editions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EditionViewModel model)
        {


            if (ModelState.IsValid)
            {
                Editions e = new Editions();

                e.InjectFrom(model);

                var createNewEdition = editions.CreateEdition(e);

                if (createNewEdition == null)
                {
                    ModelState.AddModelError("Name", "The Name must be unique!");

                    return View(model);
                }
            }
                return RedirectToAction(nameof(Index));

           
        }

        // GET: Editions/Edit/5
        public ActionResult Edit(int id)
        {
            var ed = editions.GetById(id);
            EditionViewModel model = new EditionViewModel();
            model.InjectFrom(ed);

            return View(model);
        }

        // POST: Editions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditionViewModel model)
        {
           


               Editions e = new Editions();

                e.InjectFrom(model);

                var createNewEdition = editions.Update(e);

                return RedirectToAction(nameof(Index));
            
    }

        // GET: Editions/Delete/5
        public ActionResult Delete(int id)
        {
            var del = editions.GetById(id);

            EditionViewModel model = new EditionViewModel();

            model.InjectFrom(del);

            return View(model);
        }

        // POST: Editions/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EditionViewModel model)
        {

            Editions deleteEdition = new Editions();

            deleteEdition = editions.GetById(id);

            model.InjectFrom(deleteEdition);

            editions.DeleteEdition(deleteEdition);

            return RedirectToAction(nameof(Index));

        }
    }
}