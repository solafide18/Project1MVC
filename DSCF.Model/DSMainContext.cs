using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DSCF.Model
{
    public class DSMainContext : DbContext
    {
        public DSMainContext()
            : base("DSMainConn")
        {
            Database.SetInitializer<DSMainContext>(new CreateDatabaseIfNotExists<DSMainContext>());
        }
        public DbSet<EMPLOYEE> employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
