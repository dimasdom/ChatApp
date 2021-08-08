using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppBackCore.MediatR.Security.Commands
{
    public class DeleteChatCommand:IRequest<bool>
    {
        public DeleteChatCommand(string id)
        {
            this.id = id;
        }

        public string id { get; set; }
    }
}
