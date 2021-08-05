using Grpc.Core;
using MessageService.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly MassageServiceContext _context;

        public GreeterService(ILogger<GreeterService> logger, MassageServiceContext context)
        {
            _logger = logger;
            _context = context;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            _context.Database.Migrate();
            return Task.FromResult(new HelloReply
            {
                Message = "Helloa " + request.Name
            });
        }
    }
}
