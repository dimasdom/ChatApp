using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;
namespace UserService.MediatR.User.Commands
{
    public class CreateUserCommand:IRequest<UserDTOs>
    {
        public CreateUserCommand(UserModel userData)
        {
            UserData = userData;
        }

        public UserModel UserData { get; set; }
    }
}
