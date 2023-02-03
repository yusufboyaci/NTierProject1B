using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierProject1B.CORE.Entity;
using NTierProject1B.CORE.Mapping;
using NTierProject1B.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierProject1B.ENTITIES.Mapping
{
    public class CategoryMap : CoreMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categories");
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
            builder.HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
            base.Configure(builder);
        }
    }
}
