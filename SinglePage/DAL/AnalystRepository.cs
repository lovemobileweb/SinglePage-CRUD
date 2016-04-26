using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using SinglePage.Models;

namespace SinglePage.DAL
{
    public class AnalystRepository : IDisposable
    {
        private PriceTargetContext context;

        public AnalystRepository(PriceTargetContext context)
        {
            this.context = context;
        }

        public IEnumerable<Analyst> GetAnalysts()
        {
            return context.Analysts.ToList();
        }

        public Analyst GetAnalystByID(string name)
        {
            return context.Analysts.Find(name);
        }

        public void InsertAnalyst(Analyst Analyst)
        {
            context.Analysts.Add(Analyst);
        }

        public void DeleteAnalyst(string name)
        {
            Analyst Analyst = context.Analysts.Find(name);
            context.Analysts.Remove(Analyst);
        }

        public void UpdateAnalyst(Analyst Analyst)
        {
            context.Entry(Analyst).State = EntityState.Modified;
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