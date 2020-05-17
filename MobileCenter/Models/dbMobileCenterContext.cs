using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MobileCenter.Models
{
    public class dbMobileCenterContext : DbContext
    {
        public dbMobileCenterContext() : base("name=dataMobileCenter")
        {

        }

        //public DbSet<> Customer { get; set; }
    }
}