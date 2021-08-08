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
    public class CreateChatHandler : IRequestHandler<CreateChatCommand, bool>
    {
        private readonly MassageServiceContext _context;
        public async Task<bool> Handle(CreateChatCommand request, CancellationToken cancellationToken)
        {
            await _context.Chats.AddAsync(request.Chat);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
