using System.ComponentModel.DataAnnotations;

namespace EBono_API.Accounts.Resources
{
    public class SaveAccountResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(15)]
        public string Password { get; set; }
        
        public string CreatedAt { get; set; }
    }
}