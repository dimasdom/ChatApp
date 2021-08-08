using ChatAppBackCore.MediatR.Security.Commands;
using Grpc.Net.Client;
using MediatR;
using MessageService;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace ChatAppBackCore.MediatR.Security.Handlers
{
    public class SendMessageHandler : IRequestHandler<SendMessageCommand, bool>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SendMessageHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var httpHandler = new HttpClientHandler();
            // Return `true` to allow certificates that are untrusted/invalid
            httpHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            using var channel = GrpcChannel.ForAddress("https://MessageService:443",
                new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new MessageService.Message.MessageClient(channel);
            var reply = await client.SendMessageAsync(new MessageData
            {
                Type = request.message.Type,
                UserId = currentUserId,
                ChatId = request.message.ChatId,
                Data = request.message.Data
            });
            if (reply.Message == "Well Done")
            {
                return true;
            }
            return false;
        }
    }
}
