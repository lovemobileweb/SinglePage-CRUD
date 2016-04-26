using System;
using System.Collections.Generic;
using System.Data.Entity;
using SinglePage.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SinglePage.Models
{
    public class PriceTargetContext : DbContext
    {
        public DbSet<PriceTarget> PriceTargets { get; set; }
        public DbSet<Analyst> Analysts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}