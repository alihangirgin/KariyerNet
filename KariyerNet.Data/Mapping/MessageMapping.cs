using KariyerNet.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Mapping
{
    public class MessageMapping : BaseMapping<Message>
    {
        public override void Configure(EntityTypeBuilder<Message> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.MessageText)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(x => x.ViewDate);

            builder.HasOne(x => x.SenderUser)
                .WithMany(x => x.SendedMessages)
                .HasForeignKey(x => x.SenderUserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Messages)
                .HasForeignKey(x => x.ReceiverUserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
