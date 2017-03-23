using Rest.Enity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Rest.DataContext
{
    public class AppDbContext: DbContext
    {
        public AppDbContext():base("DbConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRelation> UserRelations { get; set; }
    }
}