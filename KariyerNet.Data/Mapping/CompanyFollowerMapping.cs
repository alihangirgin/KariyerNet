using KariyerNet.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Mapping
{
    public class CompanyFollowerMapping:BaseMapping<CompanyFollower>
    {
        public override void Configure(EntityTypeBuilder<CompanyFollower> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.DeleteDate);
                
            builder.HasOne(x => x.User)
                .WithMany(x=>x.CompanyFollowers)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

        }

    }
}
