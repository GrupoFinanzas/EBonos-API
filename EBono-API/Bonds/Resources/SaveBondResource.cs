using System.ComponentModel.DataAnnotations;

namespace EBono_API.Bonds.Resources
{
    public class SaveBondResource
    {
        [Required]
        [MaxLength(50)]
        public string BondName { get; set; }
        
        [Required]
        [Range(1, 2)]
        public int CurrencyType { get; set; }
        
        [Required]
        public decimal NominalValue { get; set; }
        
        [Required]
        public float Rate { get; set; }
        
        [Required]
        [Range(1, 8)]
        public int RateType { get; set; }
        
        [Required]
        public float ExpireDate { get; set; }
        
        [Required]
        [Range(1, 8)]
        public int ExpirationType { get; set; }
        
        [Required]
        public string CreatedAt { get; set; }
        
        [Required]
        public int AccountId { get; set; }
    }
}