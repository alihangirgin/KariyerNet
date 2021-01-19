using KariyerNet.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Mapping
{
    public class UserDetailMapping:BaseMapping<UserDetail>
    {
        public override void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.NameSurname)
                .IsRequired();
            builder.Property(x => x.BirthDate)
                .IsRequired();
            builder.Property(x => x.Gender)
                .IsRequired();
            builder.Property(x => x.ProfileImage);
            builder.HasOne(x => x.DrivingLicense)
                .WithMany(x => x.UserDetails)
                .HasForeignKey(x => x.DrivingLicenseId)
                .IsRequired();
            builder.HasOne(x => x.Nationality)
                .WithMany(x => x.UserDetails)
                .HasForeignKey(x => x.NationalityId)
                .IsRequired();
            builder.HasOne(x => x.User)
                .WithMany(x => x.UserDetails)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
