using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.MediatR.Command
{
    public class DeleteMessageCommand:IRequest<bool>
    {
        public DeleteMessageCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
