using KariyerNet.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Mapping
{
    public class PositionMapping:BaseMapping<Position>
    {
        public override void Configure(EntityTypeBuilder<Position> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.PositionName)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.DeleteDate);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Positions)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
