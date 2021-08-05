using MediatR;
using MessageService.Models.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.MediatR.Command
{
    public class CreateMessageCommand:IRequest<bool>
    {
        public CreateMessageCommand(MessageModel message)
        {
            Message = message;
        }

        public MessageModel Message { get; set; }
    }
}
