using ChatAppBackCore.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppBackCore.MediatR.Security.Commands
{
    public class SendMessageCommand:IRequest<bool>
    {
        public SendMessageCommand(MessageModel message)
        {
            this.message = message;
        }

        public MessageModel message { get; set; }
    }
}
