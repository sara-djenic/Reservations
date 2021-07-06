using Ispit_asp.Models;
using Ispit_asp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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

        // GET: Courts CRUD
        [AllowAnonymous]
        public ViewResult Index()
        {
            var courts = _context.Courts.Include(c => c.CourtType).ToList();

            if (User.IsInRole("admin"))
            {
                return View(courts);
            }

            else if(User.Identity.IsAuthenticated)
            {
                return View("ForReservations", courts);
            }
            
            return View("ReadOnlyList", courts);
        }

        [Authorize(Roles ="admin")]
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewCourtViewModel newModel)
        {

            if (!ModelState.IsValid)
            {
                var courtTypes = _context.CourtTypes.ToList();
                var courtViewModel = new NewCourtViewModel
                {
                    CourtTypes = courtTypes,
                };
                return View("Create", courtViewModel);
            }

            _context.Courts.Add(newModel.Court);
            _context.SaveChanges();
            return RedirectToAction("Index", "Courts");
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            var court = _context.Courts.SingleOrDefault(c => c.CourtId == id);

            if (court == null)
                return HttpNotFound();

            var courtEdit = new NewCourtViewModel()
            {
                Court = court,
                CourtTypes = _context.CourtTypes.ToList()
            };

            return View(courtEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NewCourtViewModel newModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", newModel);
            }

            var courtEdited = _context.Courts.SingleOrDefault(c => c.CourtId == newModel.Court.CourtId);

            courtEdited.Name = newModel.Court.Name;
            courtEdited.CourtTypeId = newModel.Court.CourtTypeId;

            _context.SaveChanges();
            
            return RedirectToAction("Index", "Courts");
        }

        [ValidateAntiForgeryToken]
        public ActionResult Delete(NewCourtViewModel newModel)
        {
            var courtDeleted = _context.Courts.SingleOrDefault(c => c.CourtId == newModel.Court.CourtId);

            if (courtDeleted == null)
                return HttpNotFound();

            _context.Courts.Remove(courtDeleted);
            _context.SaveChanges();

            return RedirectToAction("Index", "Courts");
        }

    }
}