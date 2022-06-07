using EBono_API.Accounts.Domain.Models;

namespace EBono_API.Bonds.Domain.Models
{
    public class Bond
    {
        public int Id { get; set; }
        public string BondName { get; set; }
        public ECurrencyType CurrencyType { get; set; }
        public decimal NominalValue { get; set; }
        public float Rate { get; set; }
        public ERateType RateType { get; set; }
        public float ExpireDate { get; set; }
        public EExpirationType ExpirationType { get; set; }
        public string CreatedAt { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}