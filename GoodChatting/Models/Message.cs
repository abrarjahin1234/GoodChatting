using System;
using System.ComponentModel.DataAnnotations;

namespace GoodChatting.Models
{
    public class Message
    {
        public long Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string text { get; set; }
        public DateTime When { get; set; }
        public string UserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
