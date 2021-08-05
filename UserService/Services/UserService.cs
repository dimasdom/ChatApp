using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using UserService.MediatR.User.Commands;
using UserService.Models;

namespace UserService
{
    public class UserService: User.UserBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly IMediator _mediator;

        public UserService(ILogger<GreeterService> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public override async  Task<UserInfo> GetUserInfo(UserId request, ServerCallContext context)
        {
            var command = new GetUserInfoCommand(request.Id);
            var user = await _mediator.Send(command);

            return new UserInfo
            {
                Id = user.Id.ToString(),
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                UsersFriendRequests = user.UsersFriendRequests,
                UsersFriends = user.UsersFriends 
            };
        }
        public override async Task<UserInfo> GetUserByName(UserName request, ServerCallContext context)
        {
            var command = new FindUserByCommand(request.Name);
            var user = await _mediator.Send(command);
            return new UserInfo
            {
                Id = user.Id,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
            };
        }
        public override async Task<CreateUserResult> CreateUser(UserInfo request, ServerCallContext context)
        {
            var newUser = new UserModel
            {
                Id = Guid.Parse(request.Id),
                UserName=request.UserName,
                PhoneNumber=request.PhoneNumber,
                UsersFriendRequests="[]",
                UsersFriends="[]"
            };
            var command = new CreateUserCommand(newUser);
            var result = await _mediator.Send(command);
            return new CreateUserResult
            {
               Id=result.Id,
               UserName=result.UserName
            }; 
        }


    }
}
