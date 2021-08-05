using Grpc.Core;
using MediatR;
using MessageService.MediatR.Command;
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

        public override Task<Reply> SendMessage(MessageData request, ServerCallContext context)
        {
            var command = new CreateMessageCommand(JsonSerializer.Deserialize<MessageModel>(request.Data));
            var result = _mediator.Send(command);
            return Task.FromResult(new Reply
            {
                Message = "Hello "
            });
        }
    }
}
