using KariyerNet.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Business.Interfaces
{
    public interface IMessageService
    {
        void SendMessage(SendMessageViewModel model);
        List<GetMessageViewModel> GetMessages();
        List<GetMessageViewModel> GetSendedMessages();
        SendMessageViewModel GetSendMessageFormData();
        List<GetMessageViewModel> GetMessagesDetail(int messageId);
        List<GetMessageViewModel> GetSendedMessagesDetail(int messageId);
        int GetUnreadMessageCount();
        int GetUnreadSendedMessageCount();
    }
}
