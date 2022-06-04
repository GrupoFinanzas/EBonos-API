using EBono_API.Bonds.Domain.Models;

namespace EBono_API.Results.Domain.Models
{
    public class Result
    {
        public int Id;
        public float Tir;
        public string TirType;
        public decimal BondValue;
        public decimal Van;
        public float Time;
        public string TimeType;
        public float ModDuration;
        public float Convexity;

        public int BondId { get; set; }
        public Bond Bond { get; set; }
    }
}