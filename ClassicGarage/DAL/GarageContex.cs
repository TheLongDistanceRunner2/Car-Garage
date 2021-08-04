using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassicGarage.Models;
using System.Data.Entity;

namespace ClassicGarage.DAL
{
    public class GarageContex : DbContext
    {
        public GarageContex() : base("name=ClassicGarageConnection") { }

        public DbSet<CarModels> Car { get; set; }
        public DbSet<OwnerModels> Owner { get; set; }

        public DbSet<PartsModels> Part { get; set; }

        public DbSet<RepairsModels> Repair { get; set; }

        public DbSet<AdvertismentModels> Advertisment { get; set; }

    }
}