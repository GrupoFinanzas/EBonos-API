using EBono_API.Bonds.Domain.Models;

namespace EBono_API.Results.Domain.Models
{
    public class Result
    {
        public int Id { get; set; }
        public double Tir { get; set; }
        public ETirType TirType { get; set; }
        public decimal BondValue { get; set; }
        public decimal Van { get; set; }
        public float Time { get; set; }
        public ETimeType TimeType { get; set; }
        public double Duration { get; set; }
        public double ModDuration { get; set; }
        public double Convexity { get; set; }

        public int BondId { get; set; }
        public Bond Bond { get; set; }
    }
}