using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppBackCore.MediatR.Security.Commands
{
    public class DeleteMessageCommand:IRequest<bool>
    {
        public DeleteMessageCommand(string id)
        {
            this.id = id;
        }

        public string id { get; set; }
    }
}
