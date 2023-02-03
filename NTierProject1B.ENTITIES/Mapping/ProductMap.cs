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
    public class ProductMap : CoreMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");//Postgre SQL küçük büyük harf duyarlı olduğu için eklendi
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
            base.Configure(builder);
        }
    }
}
