using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Common.ViewModels
{
    public class SendMessageViewModel
    {
        public List<SelectListItem> UserList { get; set; }
        public int MessageId { get; set; }
        public int SenderUserId { get; set; }
        public string SenderUserName { get; set; }
        public DateTime CreateDate { get; set; }
        public List<int> ReceiverUserIds { get; set; }
        public string MessageText { get; set; }
    }
}
