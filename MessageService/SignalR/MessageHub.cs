using MediatR;
using MessageService.MediatR.Command;
using MessageService.Models.Message;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.SignalR
{
    public class MessageHub:Hub
    {
        //private readonly IMediator _mediator;

        //public MessageHub(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}
        //public override async Task OnConnectedAsync()
        //{
        //    var httpContext = Context.GetHttpContext();
        //    var ChatId = httpContext.Request.Query["chatId"];
        //    await Groups.AddToGroupAsync(Context.ConnectionId, ChatId);
        //}
        //public async Task SendMessage(MessageModel message)
        //{
        //    var command = new CreateMessageCommand(message);
        //    var result = await _mediator.Send(command);
        //    await Clients.Group(message.ChatId.ToString()).SendAsync("ReceiveMessage", message);
        //}
        //public async Task GetMessages(string ChatId)
        //{
        //    var command = new GetMessagesByChatIdCommand(ChatId);
        //    var messages = await _mediator.Send(command);
        //    await Clients.Group(ChatId).SendAsync("ReceiveMessage", messages);
        //}
    }
}
