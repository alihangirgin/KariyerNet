using KariyerNet.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Mapping
{
    public class AdvertisementApplyMapping : BaseMapping<AdvertisementApply>
    {
        public override void Configure(EntityTypeBuilder<AdvertisementApply> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.DeleteDate);

            builder.HasOne(x => x.JobAdvertisement)
                .WithMany(x => x.AdvertisementApplies)
                .HasForeignKey(x => x.JobAdvertisementId)
                .IsRequired();
            builder.HasOne(x => x.User)
                .WithMany(x => x.AdvertisementApplies)
                .HasForeignKey(x=>x.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
