using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppBackCore.Models
{
    public class MessageModel
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string UserId { get; set; }
        public string ChatId { get; set; }
        public DateTime Date { get; set; }
        public bool Seen { get; set; }
        public string Data { get; set; }
    }
}
