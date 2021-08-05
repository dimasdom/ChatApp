using ChatAppBackCore.MediatR.Security.Commands;
using ChatAppBackCore.Models;
using Grpc.Net.Client;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using UserService;
namespace ChatAppBackCore.MediatR.Security.Handlers
{
    public class RegisterHandler:IRequestHandler<RegisterCommand, UserDTOs>
    {
        private readonly SignInManager<Models.User> signInManager;
        private readonly UserManager<Models.User> userManager;

        public RegisterHandler(SignInManager<Models.User> signInManager, UserManager<Models.User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<UserDTOs> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Register.Email);
            


            if (user == null)
            {
                user = new Models.User
                {
                    Email = request.Register.Email,
                    PhoneNumber = request.Register.PhoneNumber,
                    UserName = request.Register.UserName
                };
               var result = await userManager.CreateAsync(user, request.Register.Password);
                if (result.Succeeded)
                {
                    var httpHandler = new HttpClientHandler();
                    // Return `true` to allow certificates that are untrusted/invalid
                    httpHandler.ServerCertificateCustomValidationCallback =
                        HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

                    using var channel = GrpcChannel.ForAddress("https://UserService:443",
                        new GrpcChannelOptions { HttpHandler = httpHandler });
                    var client = new UserService.User.UserClient(channel);
                    var newuser = await userManager.FindByEmailAsync(request.Register.Email);
                    var reply = await client.CreateUserAsync(new UserInfo
                    {
                        Id = newuser.Id,
                        UserName=newuser.UserName,
                        PhoneNumber=newuser.PhoneNumber
                        
                    });

                    if (reply.Id!=null)
                    {
                        return new UserDTOs
                        {
                            Token=newuser.Id,
                            Id=reply.Id,
                            UserName=reply.UserName
                        };
                    }
                    return null;
                }
                return null;
            }
            return null;
        }
    }
}
