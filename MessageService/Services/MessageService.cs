using Grpc.Core;
using MediatR;
using MessageService.MediatR.Command;
using MessageService.Models.Chat;
using MessageService.Models.Message;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MessageService.Services
{
    public class MessageService:Message.MessageBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MessageService> _logger;

        public MessageService(IMediator mediator, ILogger<MessageService> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public override async Task<Reply> SendMessage(MessageData request, ServerCallContext context)
        {
            var message = new MessageModel { ChatId = request.ChatId, Data = request.Data, UserId = request.UserId, Type = request.Type };
            var command = new CreateMessageCommand(message);
            var result = await _mediator.Send(command);
            return new Reply
            {
                Message = "Well Done"
            };
        }
        public override async Task<Reply> CreateChat(ChatData request,ServerCallContext context)
        {
            var chat = new Chat
            {
                Name=request.Name,
                OwnerId=request.OwnerId,
                UserIDs=request.UserIDs
            };
            var command = new CreateChatCommand(chat);
            var result = await _mediator.Send(command);
            return new Reply
            {
                Message = "Well Done"
            };

        }
        public override async Task<Reply> GetMessagesByChatId(ChatId request,ServerCallContext context)
        {
            var command = new GetMessagesByChatIdCommand(request.Id);
            var messages = await _mediator.Send(command);
            return new Reply
            {
                Message = JsonSerializer.Serialize(messages)
            };
        }
        public override async Task<Reply> GetChats(ChatId request, ServerCallContext context)
        {
            var command = new GetChatsCommand(request.Id);
            var chats = await _mediator.Send(command);
            return new Reply
            {
                Message = JsonSerializer.Serialize(chats)
            };
        }
        public override async Task<Reply> DeleteChat(ChatId request,ServerCallContext context)
        {
            var command = new DeleteChatCommand(request.Id);
            var result = await _mediator.Send(command);
            return new Reply
            {
                Message = "Ok"
            };
        }
        public override async Task<Reply> DeleteMessage(MessageId request,ServerCallContext context)
        {
            var command = new DeleteMessageCommand(request.Id);
            var result = await _mediator.Send(command);
            return new Reply
            {
                Message = "Ol"
            };
        }
    }
}
