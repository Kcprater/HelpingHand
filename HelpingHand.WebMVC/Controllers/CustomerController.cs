using HelpingHand.Models.Customer;
using HelpingHand.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpingHand.WebMVC.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userID);
            var customerModel = service.GetCustomers();
            return View(customerModel);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var service = CreateCustomerService();
            
            if (service.CreateCustomer(model))
            {
                TempData["SaveResult"] = "Customer Account Created!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Error Creating Account");
            return View(model);
        }
        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            return service;
        }
    }
}