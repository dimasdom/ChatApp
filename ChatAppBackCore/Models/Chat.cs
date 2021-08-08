using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppBackCore.Models
{
    public class Chat
    {
        public Guid Id { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public string UserIDs { get; set; }

    }
}
