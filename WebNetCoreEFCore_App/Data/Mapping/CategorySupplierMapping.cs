using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNetCoreEFCore_App.Data.Entities;

namespace WebNetCoreEFCore_App.Data.Mapping
{
    public class CategorySupplierMapping : IEntityTypeConfiguration<CategorySupplier>
    {
        public void Configure(EntityTypeBuilder<CategorySupplier> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Category).WithMany(x => x.CategorySuppliers).HasForeignKey(x => x.CategoryId);
        }
    }
}
