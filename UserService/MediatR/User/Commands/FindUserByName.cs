using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.MediatR.User.Commands
{
    public class FindUserByCommand:IRequest<UserDTOs>
    {
        public FindUserByCommand(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }
    }
}
