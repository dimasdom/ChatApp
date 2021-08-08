using MediatR;
using MessageService.Context;
using MessageService.MediatR.Command;
using MessageService.Models.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MessageService.MediatR.Handler
{
    public class DeleteChatHandler : IRequestHandler<DeleteChatCommand, bool>
    {

        private readonly MassageServiceContext _context;
        public async Task<bool> Handle(DeleteChatCommand request, CancellationToken cancellationToken)
        {
            var chat = await _context.Chats.FindAsync(Guid.Parse(request.Id));
            var messages = _context.Messages.Where(x => x.ChatId == request.Id).ToList();
            foreach(MessageModel message in messages)
            {
                _context.Messages.Remove(message);
            }
            _context.Chats.Remove(chat);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
