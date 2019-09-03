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
    public class SpeakersController : Controller
    {

        private readonly ISpeakerService speakerService;

        public SpeakersController(ISpeakerService speakerService)
        {
            this.speakerService = speakerService;
        }


        // GET: Speakers
        public ActionResult Index()
        {
            var model = speakerService.GetSpeakers();
            return View(model);
        }

        // GET: Speakers/Details/5
        public ActionResult Details(int id)
        {
            var speakerDetails = speakerService.GetById(id);
            SpeakersViewModel model = new SpeakersViewModel();
            model.InjectFrom(speakerDetails);
            return View(model);

           
        }

        // GET: Speakers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Speakers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SpeakersViewModel speakers)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Speakers s = new Speakers();
                    s.InjectFrom(speakers);
                    speakerService.Create(s);
                    if (s == null)
                    {
                        ModelState.AddModelError("Description", "Description must be unique");
                        return View(speakers);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(speakers);
            }
        }

        // GET: Speakers/Edit/5
        public ActionResult Edit(int id)
        {
            var editSpeaker = speakerService.GetById(id);
            SpeakersViewModel model = new SpeakersViewModel();
            model.InjectFrom(editSpeaker);

            return View(model);
        }

        // POST: Speakers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SpeakersViewModel model)
        {

            Speakers speakers = new Speakers();
            speakers.InjectFrom(model);
            speakerService.Update(speakers);

            return RedirectToAction(nameof(Index));
        }

        // GET: Speakers/Delete/5
        public ActionResult Delete(int id)
        {
            var del = speakerService.GetById(id);

           SpeakersViewModel model = new SpeakersViewModel();

            model.InjectFrom(del);

            return View(model);
        }

        // POST: Speakers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SpeakersViewModel model)
        {

            Speakers deleteSpeaker = new Speakers();

            deleteSpeaker = speakerService.GetById(id);

            model.InjectFrom(deleteSpeaker);

            speakerService.DeleteSpeaker(deleteSpeaker);

            return RedirectToAction(nameof(Index));
        }
        }
    }
