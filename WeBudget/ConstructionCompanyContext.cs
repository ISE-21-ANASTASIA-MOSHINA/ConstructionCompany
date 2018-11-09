using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WeBudget.Models;

namespace WeBudget
{
    public class ConstructionCompanyContext : DbContext
    {
        public DbSet <User> Users { get; set; }
        public DbSet<ZdanieForPokupka> ZdanieForPokupkas { get; set; }
        public DbSet<ZdanieForArenda> ZdanieForArendas { get; set; }
    }
}