using MediatR;
using MessageService.Context;
using MessageService.MediatR.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MessageService.MediatR.Handler
{
    public class CreateMessageHandler : IRequestHandler<CreateMessageCommand, bool>
    {
        private readonly MassageServiceContext _context;
        public  async Task<bool> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            await _context.Messages.AddAsync(request.Message);
            return true;
        }
    }
}
