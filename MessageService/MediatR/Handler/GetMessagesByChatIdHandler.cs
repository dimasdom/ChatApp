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
    public class GetMessagesByChatIdHandler : IRequestHandler<GetMessagesByChatIdCommand, List<MessageModel>>
    {
        private readonly MassageServiceContext _context;

        public GetMessagesByChatIdHandler(MassageServiceContext context)
        {
            _context = context;
        }

        public async Task<List<MessageModel>> Handle(GetMessagesByChatIdCommand request, CancellationToken cancellationToken)
        {
            var messages = _context.Messages.Where(x => x.ChatId == request.ChatId).ToList();
            if (messages.Count != 0)
            {
                return messages;
            }
            return null;
        }
    }
}
