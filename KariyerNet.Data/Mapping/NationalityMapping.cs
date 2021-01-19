using KariyerNet.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Mapping
{
    public class NationalityMapping:BaseMapping<Nationality>
    {
        public override void Configure(EntityTypeBuilder<Nationality> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.NationalityName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.DeleteDate);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Nationalities)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

        }

    }
}
