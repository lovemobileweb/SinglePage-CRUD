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
    public class AnalystController : Controller
    {
        private PriceTargetContext db = new PriceTargetContext();


        //
        // GET: /Analyst/Index

        public ViewResult Index(string key)
        {
            var Analysts = from s in db.Analysts
                           select s;
            if (!String.IsNullOrEmpty(key))
            {
                Analysts = Analysts.Where(s => s.analyst_name.ToUpper().Contains(key.ToUpper()));
            }
            Analysts = Analysts.OrderBy(s => s.analyst_name);

            int pageSize = 32;
            int pageIndex = 0;
            return View(Analysts.ToPagedList(pageIndex, pageSize));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}