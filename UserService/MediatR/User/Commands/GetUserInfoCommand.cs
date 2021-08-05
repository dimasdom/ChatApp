using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.MediatR.User.Commands
{
    public class GetUserInfoCommand:IRequest<UserModel>
    {
        public GetUserInfoCommand(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}
