using KariyerNet.Business.Interfaces;
using KariyerNet.Common.ViewModels;
using KariyerNet.Data.Domain;
using KariyerNet.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KariyerNet.Business.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserService _userService;

        public MessageService(IMessageRepository messageRepository, IUserService userService)
        {
            _messageRepository = messageRepository;
            _userService = userService;
        }

        public void SendMessage(SendMessageViewModel model)
        {
            if (model.ReceiverUserIds != null)
            {
                var user = _userService.GetUser();
                foreach (var item in model.ReceiverUserIds)
                {
                    var message = new Message();
                    message.MessageText = model.MessageText;
                    message.ReceiverUserId = item;
                    message.SenderUserId = user.UserId;
                    message.CreateDate = DateTime.Now;

                    var entity = _messageRepository.Add(message);
                    if (entity != null)
                    {
                        try
                        {
                            _messageRepository.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            var errorMessage = ex.Message;
                            throw;
                        }
                    }

                }
            }

        }



        public List<GetMessageViewModel> GetMessages()
        {
            var user = _userService.GetUser();
            var checkMessages = _messageRepository.GetAll(x => x.ReceiverUserId == user.UserId).Include("SenderUser").ToList();
            var messageList = new List<GetMessageViewModel>();
            if (checkMessages != null)
            {
                foreach (var item in checkMessages)
                {
                    var message = new GetMessageViewModel();
                    message.MessageId = item.Id;
                    message.ReceiverUserId = item.ReceiverUserId;
                    message.SenderUserId = item.SenderUserId;
                    message.CreateDate = item.CreateDate;
                    message.ViewDate = item.ViewDate;
                    message.MessageText = item.MessageText;
                    message.SenderUserName = item.SenderUser.UserName;
                    messageList.Add(message);
                }
            }
            return messageList;
        }


        public List<GetMessageViewModel> GetSendedMessages()
        {
            var user = _userService.GetUser();
            var checkMessages = _messageRepository.GetAll(x => x.SenderUserId == user.UserId).Include("User").ToList();
            var messageList = new List<GetMessageViewModel>();
            if (checkMessages != null)
            {
                foreach (var item in checkMessages)
                {
                    var message = new GetMessageViewModel();
                    message.MessageId = item.Id;
                    message.ReceiverUserId = item.ReceiverUserId;
                    message.SenderUserId = item.SenderUserId;
                    message.CreateDate = item.CreateDate;
                    message.MessageText = item.MessageText;
                    message.SenderUserName = item.User.UserName;
                    message.ViewDate = item.ViewDate;
                    messageList.Add(message);
                }
            }
            return messageList;
        }


        public SendMessageViewModel GetSendMessageFormData()
        {
            var model = new SendMessageViewModel();
            model.ReceiverUserIds = new List<int>() { 0 };
            model.UserList = _userService.getAllEmployeeUsersToForm();

            return model;
        }






        public List<GetMessageViewModel> GetMessagesDetail(int messageId)
        {
            var user = _userService.GetUser();
            var checkMessages = _messageRepository.GetAll(x => x.ReceiverUserId == user.UserId).Include("SenderUser").ToList();
            var messageList = new List<GetMessageViewModel>();
            if (checkMessages != null)
            {
                foreach (var item in checkMessages)
                {
                    var message = new GetMessageViewModel();

                    if (item.Id == messageId)
                    {
                        var checkSelectedMessage = _messageRepository.GetAll(x => x.Id == messageId).Include("SenderUser").FirstOrDefault();
                        if (checkSelectedMessage != null)
                        {
                            if (checkSelectedMessage.ViewDate == null)
                            {
                                checkSelectedMessage.ViewDate = DateTime.Now;
                                try
                                {
                                    _messageRepository.SaveChanges();
                                }
                                catch (Exception ex)
                                {
                                    var errorMessage = ex.Message;
                                    throw;
                                }
                            }
                        }

                        message.MessageText = item.MessageText;

                    }
                    message.MessageId = item.Id;
                    message.ReceiverUserId = item.ReceiverUserId;
                    message.SenderUserId = item.SenderUserId;
                    message.CreateDate = item.CreateDate;
                    message.SenderUserName = item.User.UserName;
                    message.ViewDate = item.ViewDate;
                    messageList.Add(message);
                }
            }
            return messageList;
        }


        public List<GetMessageViewModel> GetSendedMessagesDetail(int messageId)
        {
            var user = _userService.GetUser();
            var checkMessages = _messageRepository.GetAll(x => x.SenderUserId == user.UserId).Include("User").ToList();
            var messageList = new List<GetMessageViewModel>();
            if (checkMessages != null)
            {
                foreach (var item in checkMessages)
                {
                    var message = new GetMessageViewModel();

                    if (item.Id == messageId)
                    {
                        var checkSelectedMessage = _messageRepository.GetAll(x => x.Id == messageId).Include("SenderUser").FirstOrDefault();
                        if (checkSelectedMessage != null)
                        {
                            if (checkSelectedMessage.ViewDate == null)
                            {
                                checkSelectedMessage.ViewDate = DateTime.Now;
                                try
                                {
                                    _messageRepository.SaveChanges();
                                }
                                catch (Exception ex)
                                {
                                    var errorMessage = ex.Message;
                                    throw;
                                }
                            }
                        }

                        message.MessageText = item.MessageText;

                    }
                    message.MessageId = item.Id;
                    message.ReceiverUserId = item.ReceiverUserId;
                    message.SenderUserId = item.SenderUserId;
                    message.CreateDate = item.CreateDate;
                    message.SenderUserName = item.User.UserName;
                    message.ViewDate = item.ViewDate;
                    messageList.Add(message);
                }
            }
            return messageList;
        }


        public int GetUnreadMessageCount()
        {
            var user = _userService.GetUser();
            return _messageRepository.GetAll(x => x.ReceiverUserId == user.UserId && x.ViewDate == null).ToList().Count();
        }

        public int GetUnreadSendedMessageCount()
        {
            var user = _userService.GetUser();
            return _messageRepository.GetAll(x => x.SenderUserId == user.UserId && x.ViewDate == null).ToList().Count();
        }


    }
}
