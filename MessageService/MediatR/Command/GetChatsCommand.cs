using MediatR;
using MessageService.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.MediatR.Command
{
    public class GetChatsCommand:IRequest<List<Chat>>
    {
        public GetChatsCommand(string chatIdsJSON)
        {
            ChatIdsJSON = chatIdsJSON;
        }

        public string ChatIdsJSON { get; set; }
    }
}
