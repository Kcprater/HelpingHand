﻿using HelpingHand.Models.Customer;
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
        public ActionResult Details(int id)
        {
            //var svc = CreateCustomerService();
            var model = CreateCustomerService().GetCustomerById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            //var service = CreateCustomerService();
            var customer = CreateCustomerService().GetCustomerById(id);
            var model =
                new CustomerEdit
                {
                    CustomerID = customer.CustomerID,
                    Name = customer.Name,
                    Email = customer.Email,
                    City = customer.City,
                    State = customer.State
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CustomerID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCustomerService();

            if (service.UpdateCustomer(model))
            {
                TempData["SaveResult"] = "Customer Account Updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error Occurred Account Could Not Be Updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCustomerService().GetCustomerById(id);
            return View(svc);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCustomerService();

            service.CustomerDelete(id);

            TempData["SaveResult"] = "Customer Deleted.";

            return RedirectToAction("Index");

        }
        private CustomerService CreateCustomerService()
        {
            var service = new CustomerService(Guid.Parse(User.Identity.GetUserId()));
            return service;
        }
    }
}