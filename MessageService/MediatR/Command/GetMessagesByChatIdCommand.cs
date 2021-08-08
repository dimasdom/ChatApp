using MediatR;
using MessageService.Models.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.MediatR.Command
{
    public class GetMessagesByChatIdCommand:IRequest<List<MessageModel>>
    {
        public GetMessagesByChatIdCommand(string chatId)
        {
            ChatId = chatId;
        }

        public string ChatId { get; set; }
    }
}
