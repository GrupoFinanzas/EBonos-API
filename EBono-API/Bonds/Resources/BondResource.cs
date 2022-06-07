using EBono_API.Accounts.Domain.Models;

namespace EBono_API.Bonds.Resources
{
    public class BondResource
    {
        public int Id { get; set; }
        public string BondName { get; set; }
        public string CurrencyType { get; set; }
        public decimal NominalValue { get; set; }
        public float Rate { get; set; }
        public string RateType { get; set; }
        public float ExpireDate { get; set; }
        public string ExpirationType { get; set; }
        public string CreatedAt { get; set; }
        public Account Account { get; set; }
    }
}