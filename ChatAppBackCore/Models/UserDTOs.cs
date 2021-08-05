using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppBackCore.Models
{
    public class UserDTOs
    {
        public string Token { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string UsersFriends { get; set; }
        public string UsersFriendRequests { get; set; }
    }
}
