using MediatR;
using MessageService.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.MediatR.Command
{
    public class CreateChatCommand : IRequest<bool>
    {
        public CreateChatCommand(Chat chat)
        {
            Chat = chat;
        }

        public Chat Chat { get; set; }
    }
}
