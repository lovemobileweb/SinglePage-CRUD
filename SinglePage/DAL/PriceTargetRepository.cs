using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using SinglePage.Models;

namespace SinglePage.DAL
{
    public class PriceTargetRepository : IPriceTargetRepository, IDisposable
    {
        private PriceTargetContext context;

        public PriceTargetRepository(PriceTargetContext context)
        {
            this.context = context;
        }

        public IEnumerable<PriceTarget> GetPriceTargets()
        {
            return context.PriceTargets.ToList();
        }

        public PriceTarget GetPriceTargetByID(int id)
        {
            return context.PriceTargets.Find(id);
        }

        public void InsertPriceTarget(PriceTarget priceTarget)
        {
            context.PriceTargets.Add(priceTarget);
        }

        public void DeletePriceTarget(int Id)
        {
            PriceTarget priceTarget = context.PriceTargets.Find(Id);
            context.PriceTargets.Remove(priceTarget);
        }

        public void UpdatePriceTarget(PriceTarget priceTarget)
        {
            context.Entry(priceTarget).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}