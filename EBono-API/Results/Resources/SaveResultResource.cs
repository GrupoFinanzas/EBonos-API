using System.ComponentModel.DataAnnotations;

namespace EBono_API.Results.Resources
{
    public class SaveResultResource
    {
        [Required]
        public double Tir { get; set; }
        
        [Required]
        [Range(1,8)]
        public int TirType { get; set; }
        
        [Required]
        public decimal BondValue { get; set; }
        
        [Required]
        public decimal Van { get; set; }
        
        [Required]
        [Range(1, 360)]
        public float Time { get; set; }
        
        [Required]
        [Range(1,8)]
        public int TimeType { get; set; }
        
        [Required]
        public double Duration { get; set; }
        
        [Required]
        public double ModDuration { get; set; }
        
        [Required]
        public double Convexity { get; set; }
        
        public int BondId { get; set; }
    }
}