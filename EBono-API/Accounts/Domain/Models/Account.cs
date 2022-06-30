using System.Collections.Generic;
using EBono_API.Bonds.Domain.Models;
using Newtonsoft.Json;

namespace EBono_API.Accounts.Domain.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string CreatedAt { get; set; }

        public IList<Bond> Bonds { get; set; } = new List<Bond>();
    }
}