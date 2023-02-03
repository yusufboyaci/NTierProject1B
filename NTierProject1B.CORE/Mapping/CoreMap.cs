using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierProject1B.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierProject1B.CORE.Mapping
{
    public class CoreMap<T> : IEntityTypeConfiguration<T> where T : CoreEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Status).IsRequired(true);

            builder.Property(x => x.CreatedComputerName).HasColumnName("Oluşturanın Bilgisayar Adı").IsRequired(false);
            builder.Property(x => x.CreatedDomainName).HasColumnName("Oluşturanın Bilgisayarının Domain Adı").IsRequired(false);
            builder.Property(x => x.CreatedDate).HasColumnName("Oluşturulma Zamanı").IsRequired(true);
            builder.Property(x => x.CreatedADUserName).HasColumnName("Oluşturan Yönetici Adı").IsRequired(false);
            builder.Property(x => x.CreatedBy).HasColumnName("Oluşturan Kişi").IsRequired(false);
            builder.Property(x => x.CreatedIp).HasColumnName("Oluşturan Ip").IsRequired(false);

            builder.Property(x => x.ModifiedComputerName).HasColumnName("Güncelleyen Bilgisayar Adı").IsRequired(false);
            builder.Property(x => x.ModifiedDomainName).HasColumnName("Güncelleyen Bilgisayarının Domain Adı").IsRequired(false);
            builder.Property(x => x.ModifiedDate).HasColumnName("Güncelleyen Zamanı").IsRequired(true);
            builder.Property(x => x.ModifiedADUserName).HasColumnName("Güncelleyen Yönetici Adı").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName("Güncelleyen Kişi").IsRequired(false);
            builder.Property(x => x.ModifiedIp).HasColumnName("Güncelleyen Ip").IsRequired(false);
        }
    }
}
