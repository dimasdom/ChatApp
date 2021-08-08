using ChatAppBackCore.MediatR.Security.Commands;
using ChatAppBackCore.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatAppBackCore.SignalR
{
    public class ChatHub : Hub
    {
        private readonly IMediator mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string currentUserId { get; set; }
        public ChatHub(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            this.mediator = mediator;
            _httpContextAccessor = httpContextAccessor;

        }


        //private HubConnection connection { get; set; }
        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var ChatId = httpContext.Request.Query["chatId"];
            currentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await Groups.AddToGroupAsync(Context.ConnectionId, ChatId);
        }
        public async Task SendMessage(MessageModel message)
        {
            if (currentUserId != null)
            {
                var httpContext = Context.GetHttpContext();
                var ChatId = httpContext.Request.Query["chatId"];
                await Clients.Group(ChatId).SendAsync("ReceiveMessage", message);
                var command = new SendMessageCommand(message);
                var reply = await mediator.Send(command);
            }

        }
        public async Task DeleteMessage(string Id)
        {
            if (currentUserId != null)
            {
                var command = new DeleteMessageCommand(Id);
                var reply = await mediator.Send(command);
                var httpContext = Context.GetHttpContext();
                var ChatId = httpContext.Request.Query["chatId"];
                await Clients.Group(ChatId).SendAsync("ReceiveMessage", Id);
            }
        }
        public async Task CreateChat(Chat chat)
        {
            if (currentUserId != null)
            {
                var command = new CreateChatCommand(chat);
                var reply = await mediator.Send(command);
                var UserIds = JsonSerializer.Deserialize<string[]>(chat.UserIDs);
                foreach (string UserId in UserIds)
                {
                    await Clients.User(UserId).SendAsync("ChatWereCreated", chat);
                }

            }
        }

        public async Task DeleteChat(string id)
        {
            if (currentUserId != null)
            {
                var command = new DeleteChatCommand(id);
                var reply = await mediator.Send(command);

            }
        }
    }
}
