using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNetCoreEFCore_App.Data.Entities;
using WebNetCoreEFCore_App.Data.Mapping;
using WebNetCoreEFCore_App.Data.Views;

namespace WebNetCoreEFCore_App.Data.Contexts
{
    public class ProjectContext:DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> opts):base(opts)
        {
            //EFCore birden fazla db kaynagı ile çalışabilir. Bu Sebeple constructorına hangi db ile calısacagını opts olarak gönderip yapılandırma gercekleştiririz. bu opts degerinide appsetting.json dosyasındaki connection stringden okuruz.

            //EFCore MySql,MSSql , PostgreSql gibi farklı databaseler ile çalışır. 
            //Opts.ile hangi providerı kullancagımızı sisteme tanıtıcaz. 
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategorySupplier> CategorySuppliers { get; set; }

        public DbSet<ProductView> ProductViews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProductView>().ToView("ProductViews").HasNoKey();
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new CategorySupplierMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
