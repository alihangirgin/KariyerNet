using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KariyerNet.Business.Interfaces;
using KariyerNet.Common.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KariyerNet.WebApp.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult SendMessage(int selectedUserId)
        {

            var model = _messageService.GetSendMessageFormData();
            model.ReceiverUserIds.Add(selectedUserId);
            return View(model);
        }

        [HttpPost]
        public IActionResult SendMessage(SendMessageViewModel model)
        {
            _messageService.SendMessage(model);
            return Redirect(Url.Action("ListSendedMessages", "Message"));
        }

        public IActionResult ListMessages()
        {
            
            var model = _messageService.GetMessages();
            return View(model);
        }

        public IActionResult GetMessageDetail(int messageId)
        {
            var model = _messageService.GetMessagesDetail(messageId);
            return View(model);
        }


        public IActionResult ListSendedMessages()
        {
            var model = _messageService.GetSendedMessages();
            return View(model);
        }

        public IActionResult GetSendedMessageDetail(int messageId)
        {
            var model = _messageService.GetSendedMessagesDetail(messageId);
            return View(model);
        }
    }
}
