using ChatAppBackCore.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppBackCore.MediatR.Security.Commands
{
    public class LoginCommand:IRequest<UserDTOs>
    {
        public LoginCommand(LoginDTOs login)
        {
            Login = login;
        }

        public LoginDTOs Login { get; set; }
    }
}
