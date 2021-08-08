using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.MediatR.Command
{
    public class DeleteChatCommand:IRequest<bool>
    {
        public DeleteChatCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
