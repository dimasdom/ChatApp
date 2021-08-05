using ChatAppBackCore.Context;
using ChatAppBackCore.MediatR.Security.Commands;
using ChatAppBackCore.Models;
using ChatAppBackCore.Services;
using Grpc.Net.Client;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ChatAppBackCore.MediatR.Security.Handlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, UserDTOs>
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly TokenService tokenService;
        private readonly SecurityContext _context;

        public LoginHandler(SignInManager<User> signInManager, UserManager<User> userManager, TokenService tokenService, SecurityContext context)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.tokenService = tokenService;
            _context = context;
        }

        public  async Task<UserDTOs> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Login.Email);
            if (user != null)
            {
               var result = await signInManager.CheckPasswordSignInAsync(user, request.Login.Password, false);
                if (result.Succeeded)
                {

                    var httpHandler = new HttpClientHandler();
                    // Return `true` to allow certificates that are untrusted/invalid
                    httpHandler.ServerCertificateCustomValidationCallback =
                        HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                    var user1 = _context.Users.Find(user.Id);
                    using var channel = GrpcChannel.ForAddress("https://UserService:443",
                        new GrpcChannelOptions { HttpHandler = httpHandler });
                    var client = new UserService.User.UserClient(channel);
                    var userinfo = await client.GetUserInfoAsync(new UserService.UserId
                    {
                        Id = user1.Id.ToString()
                    });

                    return new UserDTOs
                    {
                        Token=tokenService.CreateToken(user),
                        Id= userinfo.Id.ToString(),
                        PhoneNumber = userinfo.PhoneNumber,
                        UserName = userinfo.UserName,
                        UsersFriendRequests = userinfo.UsersFriendRequests,
                        UsersFriends = userinfo.UsersFriends

                    };
                }
                 return new UserDTOs
                {
                    Token = ""
                };
            }
            return  new UserDTOs
            {
                Token = ""
            };
        }

    }
}
