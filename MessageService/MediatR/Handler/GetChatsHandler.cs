using MediatR;
using MessageService.Context;
using MessageService.MediatR.Command;
using MessageService.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MessageService.MediatR.Handler
{
    public class GetChatsHandler : IRequestHandler<GetChatsCommand, List<Chat>>
    {
        private readonly MassageServiceContext _context;

        public GetChatsHandler(MassageServiceContext context)
        {
            _context = context;
        }

        public async Task<List<Chat>> Handle(GetChatsCommand request, CancellationToken cancellationToken)
        {
            List<Chat> chats = new List<Chat>();
            var chatsId = JsonSerializer.Deserialize<string[]>(request.ChatIdsJSON);
            foreach(string chatId in chatsId)
            {
                var chat = await _context.Chats.FindAsync(Guid.Parse(chatId));
                chats.Add(chat);
            }
            return chats;
        }
    }
}
