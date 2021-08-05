using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Context;

namespace UserService
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly UserContext _context;

        public GreeterService(ILogger<GreeterService> logger, UserContext context)
        {
            _logger = logger;
            _context = context;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            _context.Database.Migrate();
            return Task.FromResult(new HelloReply
            {
                Message = "Hello" + request.Name
            });
        }
        
    }
}
