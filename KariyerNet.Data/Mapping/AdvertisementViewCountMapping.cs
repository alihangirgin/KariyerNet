using KariyerNet.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Mapping
{
    public class AdvertisementViewCountMapping:BaseMapping<AdvertisementViewCount>
    {
        public override void Configure(EntityTypeBuilder<AdvertisementViewCount> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.JobAdvertisement)
                .WithMany(x => x.AdvertisementViewCounts)
                .HasForeignKey(x => x.JobAdvertisementId)
                .IsRequired();
            builder.HasOne(x => x.User)
                .WithMany(x => x.AdvertisementViewCounts)
                .HasForeignKey(x => x.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

        }

    }
}
