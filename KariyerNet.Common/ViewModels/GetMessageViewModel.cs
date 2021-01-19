using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Common.ViewModels
{
    public class GetMessageViewModel
    {
        public int MessageId { get; set; }
        public int SenderUserId { get; set; }
        public string SenderUserName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ViewDate { get; set; }
        public int ReceiverUserId { get; set; }
        public string MessageText { get; set; }
    }
}
