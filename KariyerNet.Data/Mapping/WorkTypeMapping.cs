using KariyerNet.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Mapping
{
    public class WorkTypeMapping:BaseMapping<WorkType>
    {
        public override void Configure(EntityTypeBuilder<WorkType> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.WorkTypeName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.DeleteDate);

            builder.HasOne(x => x.User)
                .WithMany(x => x.WorkTypes)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
