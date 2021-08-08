using ChatAppBackCore.MediatR.Security.Commands;
using ChatAppBackCore.Models;
using Grpc.Net.Client;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MessageService;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ChatAppBackCore.MediatR.Security.Handlers
{
    public class CreateChatHandle : IRequestHandler<CreateChatCommand, Chat>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateChatHandle(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Chat> Handle(CreateChatCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var httpHandler = new HttpClientHandler();
            // Return `true` to allow certificates that are untrusted/invalid
            httpHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            using var channel = GrpcChannel.ForAddress("https://MessageService:443",
                new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new MessageService.Message.MessageClient(channel);
            var reply = await client.CreateChatAsync(new ChatData {
                Name = request.chat.Name, OwnerId = currentUserId, UserIDs = request.chat.UserIDs
            });
            return request.chat;
        }
    }
}
