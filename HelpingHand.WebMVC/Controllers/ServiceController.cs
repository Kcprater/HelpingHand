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
            //return View(CreateServiceService().GetServices());
        }
        public ActionResult Create()
        {
            return View();
        }
        //public ActionResult Create(Guid userID)
        //{
        //    ViewBag.Title = "New Service";

        //    List<Provider> Providers = new ProviderService().GetProviders().ToList();
        //    var query = from p in Providers
        //                select new SelectListItem()
        //                {
        //                    Value = p.ID.ToString(),
        //                    Text = p.Name
        //                };
        //    ViewBag.ProviderID = query.ToList();

        //    return View();
        //}
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
            //var service = CreateCustomerService();
            var providerService = CreateServiceService().GetServiceById(id);

            //List<Provider> Providers = (new ProviderService()).GetProviders().ToList();

            //var query = from p in Providers
            //            select new SelectListItem()
            //            {
            //                Value = p.ProviderID.ToString(),
            //                Text = p.Name
            //            };
            //ViewBag.ProviderID = query.ToList();

            var model =
                new ServiceEdit
                {
                    ServiceID = providerService.ServiceID,
                    ProviderID = providerService.ProviderID,
                    Category = providerService.Category,
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