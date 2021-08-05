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
    public class GetUserInfoHandler: IRequestHandler<GetUserInfoCommand, UserModel>
    {
        private readonly UserContext _context;

        public GetUserInfoHandler(UserContext context)
        {
            _context = context;
        }

        public async Task<UserModel> Handle(GetUserInfoCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(Guid.Parse(request.UserId));
            return user;
        }
    }
}
