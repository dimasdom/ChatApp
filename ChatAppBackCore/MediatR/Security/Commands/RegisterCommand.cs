using ChatAppBackCore.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppBackCore.MediatR.Security.Commands
{
    public class RegisterCommand:IRequest<UserDTOs>
    {
        public RegisterCommand(RegisterDTOs register)
        {
            Register = register;
        }

        public RegisterDTOs Register { get; set; }
    }
}
