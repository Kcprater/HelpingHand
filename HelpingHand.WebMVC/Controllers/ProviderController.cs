using HelpingHand.Data;
using HelpingHand.Models.Customer;
using HelpingHand.Models.Provider;
using HelpingHand.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;

namespace HelpingHand.WebMVC.Controllers
{
    [Authorize]
    public class ProviderController : Controller
    {
        // GET: Provider
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ProviderService(userID);
            var providerModel = service.GetProviders();
            return View(providerModel);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProviderCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var service = CreateProviderService();

            if (service.CreateProvider(model))
            {
                TempData["SaveResult"] = "Provider Account Created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Error Creating Account");
            return View(model);
        }
        private ProviderService CreateProviderService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProviderService(userId);
            return service;
        }
        public IEnumerable<ProviderListItem> GetProviderLists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Providers.Select(p => new ProviderListItem
                {
                    ProviderID = p.ProviderID,
                    Name = p.Name,
                    Phone = p.Phone,
                    City = p.City,
                    State = p.State
                });

                return query.ToArray();
            }
        }

        public IEnumerable<Provider> GetProviders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Providers.ToList();
            }
        }

        public ActionResult Details(int id)
        {
            //var svc = CreateCustomerService();
            var model = CreateProviderService().GetProviderById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            //var service = CreateCustomerService();
            var provider = CreateProviderService().GetProviderById(id);
            var model =
                new ProviderEdit
                {
                    ProviderID = provider.ProviderID,
                    Name = provider.Name,
                    Email = provider.Email,
                    Phone = provider.Phone,
                    City = provider.City,
                    State = provider.State
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProviderEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProviderID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateProviderService();

            if (service.UpdateProvider(model))
            {
                TempData["SaveResult"] = "Provided Account Updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error Occurred Account Could Not Be Updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateProviderService().GetProviderById(id);
            return View(svc);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateProviderService();

            service.ProviderDelete(id);

            TempData["SaveResult"] = "Provicer Deleted.";

            return RedirectToAction("Index");

        }
    }
}