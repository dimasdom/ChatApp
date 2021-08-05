using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UserService.Context;
using UserService.MediatR.User.Commands;
using UserService.Models;

namespace UserService.MediatR.User.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDTOs>
    {
        private readonly UserContext _context;

        public CreateUserHandler(UserContext context)
        {
            _context = context;
        }

        public Task<UserDTOs> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new UserModel
            {
                Id = request.UserData.Id,
                PhoneNumber =request.UserData.PhoneNumber ,
                UserName = request.UserData.UserName,
                UsersFriendRequests = "[]",
                UsersFriends = "[]"

            };
            _context.Users.Add(user);
            _context.SaveChanges();
            var newuser = _context.Users.Find(user.Id);
            if (newuser != null)
            {
                return Task.FromResult(new UserDTOs
                {
                    Id = newuser.Id.ToString(),
                    PhoneNumber = newuser.PhoneNumber,
                    UserName = newuser.UserName
                });
                
            }
            return null;
        }
    }
}
