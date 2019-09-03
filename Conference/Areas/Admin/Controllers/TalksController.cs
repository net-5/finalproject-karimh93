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
    public class TalksController : Controller
    {

        private ITalksService talksService;

        public TalksController(ITalksService talksService)
        {
            this.talksService = talksService;
        }



        // GET: Talks
        public ActionResult Index()
        {
            var model = talksService.GetAllTalks();
            return View(model);
        }

        // GET: Talks/Details/5
        public ActionResult Details(int id)
        {
            var getTalkById = talksService.GetTalksById(id);
            TalksViewModel model = new TalksViewModel();
            model.InjectFrom(getTalkById);

            return View(model);
        }

        // GET: Talks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Talks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TalksViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Talks talks = new Talks();
                    talks.InjectFrom(model);
                    var addedTalk = talksService.CreateATalk(talks);

                    if (addedTalk == null)
                    {
                        ModelState.AddModelError("Name", "The Name must be unique");
                        return View(model);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Talks/Edit/5
        public ActionResult Edit(int id)
        {
            var getTalks = talksService.GetTalksById(id);
            TalksViewModel model = new TalksViewModel();
            model.InjectFrom(getTalks);

            return View(model);



        }

        // POST: Talks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TalksViewModel model) { 
        


            Talks talks = new Talks();
            talks.InjectFrom(model);
            talksService.UpdateATalk(talks);

            return RedirectToAction(nameof(Index));
        }
        // GET: Talks/Delete/5
        public ActionResult Delete(int id)
        {
            var del = talksService.GetTalksById(id);

            TalksViewModel model = new TalksViewModel();

            model.InjectFrom(del);

            return View(model);
        }

        // POST: Talks/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TalksViewModel model)
        {
            Talks deleteTalk = new Talks();

            deleteTalk = talksService.GetTalksById(id);

            model.InjectFrom(deleteTalk);

            talksService.DeleteATalk(deleteTalk);

            return RedirectToAction(nameof(Index));
        }
    }
}