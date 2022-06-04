using EBono_API.Accounts.Domain.Models;

namespace EBono_API.Bonds.Domain.Models
{
    public class Bond
    {
        public int Id;
        public string BondName;
        public string CurrencyType;
        public decimal NominalValue;
        public float Rate;
        public string RateType;
        public float ExpireDate;
        public string ExpireType;
        public string CreatedAt;

        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}