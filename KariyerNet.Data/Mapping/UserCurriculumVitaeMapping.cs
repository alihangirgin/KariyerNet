using KariyerNet.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Mapping
{
    public class UserCurriculumVitaeMapping:BaseMapping<UserCurriculumVitae>
    {
        public override void Configure(EntityTypeBuilder<UserCurriculumVitae> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.CVName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.FilePath)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(x => x.DeleteDate);
            builder.Property(x => x.PublishDate);
            builder.Property(x => x.PublishDeleteDate);

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserCurriculumVitaes)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

        }

    }
}
