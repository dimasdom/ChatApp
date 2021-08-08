using ChatAppBackCore.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppBackCore.MediatR.Security.Commands
{
    public class CreateChatCommand:IRequest<Chat>
    {
        public CreateChatCommand(Chat chat)
        {
            this.chat = chat;
        }

        public Chat chat { get; set; }
    }
}
