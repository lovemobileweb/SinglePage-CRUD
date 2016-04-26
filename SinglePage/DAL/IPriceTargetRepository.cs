using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SinglePage.Models;

namespace SinglePage.DAL
{
    public interface IPriceTargetRepository : IDisposable
    {
        IEnumerable<PriceTarget> GetPriceTargets();
        PriceTarget GetPriceTargetByID(int Id);
        void InsertPriceTarget(PriceTarget priceTarget);
        void DeletePriceTarget(int Id);
        void UpdatePriceTarget(PriceTarget priceTarget);
        void Save();
    }
}