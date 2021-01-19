using KariyerNet.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Mapping
{
    public class JobAdvertisementMapping:BaseMapping<JobAdvertisement>
    {

        public override void Configure(EntityTypeBuilder<JobAdvertisement> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.JobTitle)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.JobDefinition)
                .IsRequired();
            builder.Property(x => x.RequiredExperience)
                .IsRequired();
            builder.Property(x => x.AvailableJobCount)
                .IsRequired();
            builder.Property(x => x.DeleteDate);
            builder.Property(x => x.ExpireDate)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.JobAdvertisements)
                .HasForeignKey(x=>x.CompanyUserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.City)
                .WithMany(x => x.JobAdvertisements)
                .HasForeignKey(x => x.CityId)
                .IsRequired();
            builder.HasOne(x => x.EducationLevel)
                .WithMany(x => x.JobAdvertisements)
                .HasForeignKey(x => x.EducationLevelId)
                .IsRequired();
            builder.HasOne(x => x.Departmant)
                .WithMany(x => x.JobAdvertisements)
                .HasForeignKey(x => x.DepartmantId)
                .IsRequired();
            builder.HasOne(x => x.WorkType)
                .WithMany(x => x.JobAdvertisements)
                .HasForeignKey(x => x.WorkTypeId)
                .IsRequired();
            builder.HasOne(x => x.Position)
                .WithMany(x => x.JobAdvertisements)
                .HasForeignKey(x => x.PositionId)
                .IsRequired();
            
        }

    }
}
