using Ispit_asp.Models;
using Ispit_asp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ispit_asp.Controllers
{
    public class CourtsController : Controller
    {
        private ApplicationDbContext _context;

        public CourtsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Courts
        public ActionResult Index()
        {
            var courts = _context.Courts.ToList();

            return View(courts);
        }

        public ActionResult Create()
        {
            var courtTypes = _context.CourtTypes.ToList();
            var courtViewModel = new NewCourtViewModel
            {
                CourtTypes = courtTypes,
            };
            return View(courtViewModel);
        }

        [HttpPost]
        public ActionResult Create(NewCourtViewModel newModel)
        {
            _context.Courts.Add(newModel.Court);
            _context.SaveChanges();
            return RedirectToAction("Index", "Courts");
        }

    }
}