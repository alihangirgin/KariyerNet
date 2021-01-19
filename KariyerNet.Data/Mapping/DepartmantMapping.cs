using KariyerNet.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Mapping
{
    public class DepartmantMapping:BaseMapping<Departmant>
    {
        public override void Configure(EntityTypeBuilder<Departmant> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.DeleteDate);
            builder.Property(x => x.DepartmantName)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(x => x.User)
               .WithMany(x => x.Departmants)
               .HasForeignKey(x=>x.UserId)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
