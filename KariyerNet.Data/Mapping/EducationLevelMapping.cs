using KariyerNet.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Mapping
{
    public class EducationLevelMapping:BaseMapping<EducationLevel>
    {
        public override void Configure(EntityTypeBuilder<EducationLevel> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.EducationName)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.DeleteDate);

            builder.HasOne(x => x.User)
                .WithMany(x => x.EducationLevels)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
