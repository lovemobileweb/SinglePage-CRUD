using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SinglePage.Models;

namespace SinglePage.DAL
{
    public class PriceTargetInitializer : DropCreateDatabaseIfModelChanges<PriceTargetContext>
    {
        protected override void Seed(PriceTargetContext context)
        {
            var Analysts = new List<Analyst>
            {
                new Analyst { analyst_name = "analyst_name1", analyst_initials = "analyst_initials1" },
                new Analyst { analyst_name = "analyst_name2", analyst_initials = "analyst_initials2" }
            };
            Analysts.ForEach(s => context.Analysts.Add(s));
            context.SaveChanges();

            /*var PriceTargets = new List<PriceTarget>
            {
                new PriceTarget { QA_Id = "QA_Id", AsofDate = DateTime.Parse("2016-04-06"), PT_Period = "PT_Period", PriceTarget1 = 1, DownsidePT = 2, BullPT = 3, BearPT = 4, CoveredBy = "CoveredBy", PT_Note = "PT_Note", CreatedOn = DateTime.Now, CreatedBy = "", ModifiedOn = null, ModifiedBy = "" }
            };
            PriceTargets.ForEach(s => context.PriceTargets.Add(s));
            context.SaveChanges();*/
        }
    }
}