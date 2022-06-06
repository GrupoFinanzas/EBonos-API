using System.ComponentModel;

namespace EBono_API.Bonds.Domain.Models
{
    public enum ERateType : byte
    {
        [Description("AN")]
        Annual = 1,
        [Description("SA")]
        Semiannual = 2,
        [Description("FM")]
        FourMonthly = 3,
        [Description("QT")]
        Quarterly = 4,
        [Description("BI")]
        Bimonthly = 5,
        [Description("MO")]
        Monthly = 6,
        [Description("FTG")]
        Fortnightly = 7,
        [Description("DL")]
        Daily = 8
    }
}