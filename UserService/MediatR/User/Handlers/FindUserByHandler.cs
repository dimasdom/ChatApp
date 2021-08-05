using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class FindUserByHandler: IRequestHandler<FindUserByCommand, UserDTOs>
    {
        private readonly UserContext _context;

        public FindUserByHandler(UserContext context)
        {
            _context = context;
        }

       
        public async Task<UserDTOs> Handle(FindUserByCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Where(x => x.UserName == request.UserName).ToArrayAsync();
            if (user != null)
            {
                return new UserDTOs {
                UserName=user[0].UserName,
                Id=user[0].Id.ToString(),
                PhoneNumber=user[0].PhoneNumber};
            }
            return null;
        }
    }
}
