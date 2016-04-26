using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SinglePage.Models;
using SinglePage.DAL;
using PagedList;

namespace SinglePage.Controllers
{
    public class PriceTargetController : Controller
    {
        private IPriceTargetRepository priceTargetRepository;


        public PriceTargetController()
        {
            this.priceTargetRepository = new PriceTargetRepository(new PriceTargetContext());
        }

        public PriceTargetController(IPriceTargetRepository priceTargetRepository)
        {
            this.priceTargetRepository = priceTargetRepository;
        }


        //
        // GET: /PriceTarget/Index

        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date desc" : "Date";

            if (Request.HttpMethod == "GET")
            {
                searchString = currentFilter;
            }
            else
            {
                page = 1;
            }
            ViewBag.CurrentFilter = searchString;
            
            var priceTargets = from s in priceTargetRepository.GetPriceTargets()
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                priceTargets = priceTargets.Where(s => s.QA_Id.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Name desc":
                    priceTargets = priceTargets.OrderByDescending(s => s.QA_Id);
                    break;
                case "Date":
                    priceTargets = priceTargets.OrderBy(s => s.ModifiedOn);
                    break;
                case "Date desc":
                    priceTargets = priceTargets.OrderByDescending(s => s.ModifiedOn);
                    break;
                default:
                    priceTargets = priceTargets.OrderBy(s => s.QA_Id);
                    break;
            }

            int pageSize = 10;
            int pageIndex = (page ?? 1) - 1;
            return View(priceTargets.ToPagedList(pageIndex, pageSize));
        }


        //
        // GET: /PriceTarget/Details/5

        public ViewResult Details(int id)
        {
            PriceTarget priceTarget = priceTargetRepository.GetPriceTargetByID(id);
            return View(priceTarget);
        }

        //
        // GET: /PriceTarget/Create

        public ActionResult Create()
        {
            PriceTarget newObj = new PriceTarget();
            newObj.CreatedBy = User.Identity.Name;
            return View(newObj);
        }

        //
        // POST: /PriceTarget/Create

        [HttpPost]
        public ActionResult Create(PriceTarget priceTarget)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    priceTarget.CreatedOn = DateTime.Now;
                    priceTarget.CreatedBy = User.Identity.Name;
                    priceTargetRepository.InsertPriceTarget(priceTarget);
                    priceTargetRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(priceTarget);
        }

        //
        // GET: /PriceTarget/Edit/5

        public ActionResult Edit(int id)
        {
            PriceTarget priceTarget = priceTargetRepository.GetPriceTargetByID(id);
            return View(priceTarget);
        }

        //
        // POST: /PriceTarget/Edit/5

        [HttpPost]
        public ActionResult Edit(PriceTarget priceTarget)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    priceTarget.ModifiedOn = DateTime.Now;
                    priceTarget.ModifiedBy = User.Identity.Name;
                    priceTargetRepository.UpdatePriceTarget(priceTarget);
                    priceTargetRepository.Save();
                    ActionResult ar = View(priceTarget);
                    return ar;
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(priceTarget);
        }

        //
        // GET: /PriceTarget/Delete/5

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            PriceTarget priceTarget = priceTargetRepository.GetPriceTargetByID(id);
            return View(priceTarget);
        }


        //
        // POST: /PriceTarget/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                PriceTarget priceTarget = priceTargetRepository.GetPriceTargetByID(id);
                priceTargetRepository.DeletePriceTarget(id);
                priceTargetRepository.Save();
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException)
                return RedirectToAction("Delete",
                    new System.Web.Routing.RouteValueDictionary { 
                { "id", id }, 
                { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            priceTargetRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}