using KariyerNet.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Mapping
{
    public class SectorMapping: BaseMapping<Sector>
    {
        public override void Configure(EntityTypeBuilder<Sector> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.SectorName)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.DeleteDate);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Sectors)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
