using ChatAppBackCore.MediatR.Security.Commands;
using Grpc.Net.Client;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MessageService;
namespace ChatAppBackCore.MediatR.Security.Handlers
{
    public class DeleteChatHandler : IRequestHandler<DeleteChatCommand, bool>
    {

        public async Task<bool> Handle(DeleteChatCommand request, CancellationToken cancellationToken)
        {
            var httpHandler = new HttpClientHandler();
            // Return `true` to allow certificates that are untrusted/invalid
            httpHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            using var channel = GrpcChannel.ForAddress("https://MessageService:443",
                new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new MessageService.Message.MessageClient(channel);
            //var reply = await client.DeleteMessageAsync()
            return true;
        }
    }
}
