using HelpingHand.Data;
using HelpingHand.Models.Service;
using HelpingHand.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace HelpingHand.WebMVC.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ServiceService(userID);
            var serviceModel = service.GetServices();
            return View(serviceModel);
        }
        public ActionResult Create()
        {
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Select", Value = "0" });
            li.Add(new SelectListItem { Text = "Music", Value = "1" });
            li.Add(new SelectListItem { Text = "Education", Value = "2" });
            ViewData["category"] = li;
            return View();
        }
        public JsonResult GetSubcategories(string id)
        {
            List<SelectListItem> subcatgories = new List<SelectListItem>();
            switch (id)
            {
                case "1":
                    subcatgories.Add(new SelectListItem { Text = "Select", Value = "0" });
                    subcatgories.Add(new SelectListItem { Text = "Piano", Value = "1" });
                    subcatgories.Add(new SelectListItem { Text = "Guitar", Value = "2" });
                    break;
                case "2":
                    subcatgories.Add(new SelectListItem { Text = "Select", Value = "0" });
                    subcatgories.Add(new SelectListItem { Text = "Math", Value = "1" });
                    subcatgories.Add(new SelectListItem { Text = "Reading", Value = "2" });
                    break;
            }
            return Json(new SelectList(subcatgories, "Value", "Text"));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var service = CreateServiceService();

            if (service.CreateService(model))
            {
                TempData["SaveResult"] = "Service Added";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Error Adding Service");
            return View(model);
        }
        private ServiceService CreateServiceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ServiceService(userId);
            return service;
        }
        public ActionResult Details(int id)
        {
            //var svc = CreateCustomerService();
            var model = CreateServiceService().GetServiceById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Select", Value = "0" });
            li.Add(new SelectListItem { Text = "Music", Value = "1" });
            li.Add(new SelectListItem { Text = "Education", Value = "2" });
            ViewData["category"] = li;
            var providerService = CreateServiceService().GetServiceById(id);

            var model =
                new ServiceEdit
                {
                    ServiceID = providerService.ServiceID,
                    ProviderID = providerService.ProviderID,
                    Category = providerService.Category,
                    Subcategory = providerService.Subcategory,
                    Experience = providerService.Experience,
                    Rate = providerService.Rate,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ServiceEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ServiceID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateServiceService();

            if (service.UpdateService(model))
            {
                TempData["SaveResult"] = "Offered Service Updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error Occurred, Service Could Not Be Updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateServiceService().GetServiceById(id);
            return View(svc);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateServiceService();

            service.ServiceDelete(id);

            TempData["SaveResult"] = "Provicer Deleted.";

            return RedirectToAction("Index");
        }
    }
}