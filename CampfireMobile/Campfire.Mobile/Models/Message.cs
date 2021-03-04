using System;
namespace Campfire.Mobile.Models
{
    public class Message
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Value { get; set; }
        public bool IsOwner { get; set; }

    }
}
