using Ispit_asp.Models;
using Ispit_asp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ispit_asp.Controllers
{
    public class ReservationController : Controller
    {
        private ApplicationDbContext _context;

        public ReservationController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Reserve()
        {

            if (User.Identity.IsAuthenticated)
            {
                
                return View();
            }


            return RedirectToAction("Index", "Courts");

        }


        // GET: Reservation
        public ActionResult Index()
        {
            return View();
        }
    }
}