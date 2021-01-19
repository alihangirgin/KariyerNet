using KariyerNet.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Mapping
{
    public class CompanyDetailMapping: BaseMapping<CompanyDetail>
    {
        public override void Configure(EntityTypeBuilder<CompanyDetail> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.CompanyName)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.FoundationYear)
                .IsRequired();
            builder.Property(x => x.Address)
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(x => x.WebSite)
                .HasMaxLength(200);
            builder.Property(x => x.NumberOfEmployees)
                .IsRequired();
            builder.Property(x => x.About)
                .IsRequired();
            builder.Property(x => x.ImageUrl)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithOne(x => x.CompanyDetail)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Sector)
                .WithMany(x => x.CompanyDetails)
                .IsRequired();

        }


    }
}
