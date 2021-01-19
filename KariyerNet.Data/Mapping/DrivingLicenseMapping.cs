using KariyerNet.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Mapping
{
    public class DrivingLicenseMapping:BaseMapping<DrivingLicense>
    {
        public override void Configure(EntityTypeBuilder<DrivingLicense> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.DeleteDate);
            builder.Property(x => x.DrivingLicenseType)
                .HasMaxLength(2)
                .IsRequired();


            builder.HasOne(x => x.User)
                .WithMany(x => x.DrivingLicenses)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
