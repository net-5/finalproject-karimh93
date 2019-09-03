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
    public class WorkshopController : Controller
    {


        private readonly IWorkShopService workShopService;

        public WorkshopController(IWorkShopService workShopService)
        {
            this.workShopService = workShopService;
        }
        
        // GET: Workshop
        public ActionResult Index()
        {
            var model = workShopService.GetAllWorkshops();
            return View(model);
        }

        // GET: Workshop/Details/5
        public ActionResult Details(int id)
        {
            var getWorkshopById = workShopService.GetWorkshopsById(id);
            WorkshopViewModel model = new WorkshopViewModel();
            model.InjectFrom(getWorkshopById);

            return View(model);
        }

        // GET: Workshop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Workshop/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkshopViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Workshops workshop = new Workshops();
                    workshop.InjectFrom(model);
                    var addedWorkshop = workShopService.CreateAWorkshop(workshop);

                    if (addedWorkshop == null)
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

        // GET: Workshop/Edit/5
        public ActionResult Edit(int id)
        {
            var getWorkshop = workShopService.GetWorkshopsById(id);
            WorkshopViewModel model = new WorkshopViewModel();
            model.InjectFrom(getWorkshop);

            return View(model);
        }

        // POST: Workshop/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WorkshopViewModel model)
        {
            Workshops workshops = new Workshops();
            workshops.InjectFrom(model);
            workShopService.UpdateAWorkshop(workshops);

            return RedirectToAction(nameof(Index));
        }

            // GET: Workshop/Delete/5
            public ActionResult Delete(int id)
        {
            var del = workShopService.GetWorkshopsById(id);

            WorkshopViewModel model = new WorkshopViewModel();

            model.InjectFrom(del);

            return View(model);
        }

        // POST: Workshop/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, WorkshopViewModel model)
        {

            Workshops deleteWorkshop = new Workshops();

            deleteWorkshop = workShopService.GetWorkshopsById(id);

            model.InjectFrom(deleteWorkshop);

            workShopService.DeleteAWorkshop(deleteWorkshop);

            return RedirectToAction(nameof(Index));
        }
    }
}