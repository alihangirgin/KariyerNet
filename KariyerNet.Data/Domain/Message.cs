using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Domain
{
    public class Message:BaseEntity
    {
        public int SenderUserId { get; set; }
        public int ReceiverUserId { get; set; }
        public string MessageText { get; set; }
        public DateTime? ViewDate { get; set; }

        public User User { get; set; }
        public User SenderUser { get; set; }
    }
}
