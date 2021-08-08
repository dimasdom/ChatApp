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
    public class DeleteMessageHandler : IRequestHandler<DeleteMessageCommand, bool>
    {
        private readonly MassageServiceContext _context;
        public  async Task<bool> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var message = await _context.Messages.FindAsync(Guid.Parse(request.Id));
            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
