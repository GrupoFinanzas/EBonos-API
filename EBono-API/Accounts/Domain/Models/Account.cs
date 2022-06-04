
using System.Collections.Generic;
using EBono_API.Bonds.Domain.Models;

namespace EBono_API.Accounts.Domain.Models
{
    public class Account
    {
        public int Id;
        public string Name;
        public string Email;
        public string Password;
        public string CreatedAt;

        public IList<Bond> Bonds { get; set; } = new List<Bond>();
    }
}