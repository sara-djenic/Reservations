using Ispit_asp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ispit_asp.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        [Authorize(Roles = "admin")]
        public ViewResult Index()
        {
            var customers = _context.Customers.ToList();

            return View(customers);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer newCustomer)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Customers.Add(newCustomer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);

            if (customer == null)
                return HttpNotFound();

            var customerEdit = new Customer()
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                LastName = customer.LastName,
                IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter
            };

            return View(customerEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer newCustomer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var customerEdited = _context.Customers.SingleOrDefault(c => c.CustomerId == newCustomer.CustomerId);

            customerEdited.CustomerName = newCustomer.CustomerName;
            customerEdited.LastName = newCustomer.LastName;
            customerEdited.IsSubscribedToNewsletter = newCustomer.IsSubscribedToNewsletter;
            customerEdited.CustomerId = newCustomer.CustomerId;

            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Customer newCustomer)
        {
            var customerDeleted = _context.Customers.SingleOrDefault(c => c.CustomerId == newCustomer.CustomerId);

            if (customerDeleted == null)
                return HttpNotFound();

            _context.Customers.Remove(customerDeleted);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

    }
}