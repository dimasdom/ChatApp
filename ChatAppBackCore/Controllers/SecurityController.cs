using ChatAppBackCore.Context;
using ChatAppBackCore.MediatR.Security.Commands;
using ChatAppBackCore.Models;
using Grpc.Core;
using Grpc.Net.Client;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UserService;

namespace ChatAppBackCore.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SecurityController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly SecurityContext context;

        public SecurityController(IMediator mediator, SecurityContext context)
        {
            _mediator = mediator;
            this.context = context;
        }

        [HttpGet("Main")]
        public async Task<ActionResult<string>> MigrationForMain()
        {
            context.Database.Migrate();
            //var httpHandler = new HttpClientHandler();
            //// Return `true` to allow certificates that are untrusted/invalid
            //httpHandler.ServerCertificateCustomValidationCallback =
            //    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            //using var channel = GrpcChannel.ForAddress("https://UserService:443",
            //    new GrpcChannelOptions { HttpHandler = httpHandler });
            //var client = new Greeter.GreeterClient(channel);
            //var reply = await client.SayHelloAsync(
            //                  new HelloRequest { Name = "YES ITS WORKS" });
            //using var channe2 = GrpcChannel.ForAddress("https://MessageService:443",
            //    new GrpcChannelOptions { HttpHandler = httpHandler });
            //var client2 = new Greeter.GreeterClient(channe2);
            //var reply2 = await client2.SayHelloAsync(
            //                  new HelloRequest { Name = " YES ITS WORKS2" });
            return "Ture";
        }
        [HttpGet("User")]
        public async Task<ActionResult<string>> MigrationForUser()
        {

            var httpHandler = new HttpClientHandler();
            // Return `true` to allow certificates that are untrusted/invalid
            httpHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            using var channel = GrpcChannel.ForAddress("https://UserService:443",
                new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "YES ITS WORKS" });
            //using var channe2 = GrpcChannel.ForAddress("https://MessageService:443",
            //    new GrpcChannelOptions { HttpHandler = httpHandler });
            //var client2 = new Greeter.GreeterClient(channe2);
            //var reply2 = await client2.SayHelloAsync(
            //                  new HelloRequest { Name = " YES ITS WORKS2" });
            return reply.Message;
        }
        [HttpGet("Message")]
        public async Task<ActionResult<string>> MigrationForMessage()
        {

            var httpHandler = new HttpClientHandler();
            // Return `true` to allow certificates that are untrusted/invalid
            httpHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            //using var channel = GrpcChannel.ForAddress("https://UserService:443",
            //    new GrpcChannelOptions { HttpHandler = httpHandler });
            //var client = new Greeter.GreeterClient(channel);
            //var reply = await client.SayHelloAsync(
            //                  new HelloRequest { Name = "YES ITS WORKS" });
            using var channe2 = GrpcChannel.ForAddress("https://MessageService:443",
                new GrpcChannelOptions { HttpHandler = httpHandler });
            var client2 = new Greeter.GreeterClient(channe2);
            var reply2 = await client2.SayHelloAsync(
                              new HelloRequest { Name = " YES ITS WORKS2" });
            return reply2.Message;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTOs>> Login(LoginDTOs login)
        {
            var command = new LoginCommand(login);
                var result = await _mediator.Send(command);
            if (result.Token != "")
            {
                return result;
            }
            return NotFound();
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDTOs>> Register(RegisterDTOs register)
        {
            var command = new RegisterCommand(register);
            var result = await _mediator.Send(command);
            if (result!=null)
            {
                return result;
            }
            return NotFound();
        }
    }
}
