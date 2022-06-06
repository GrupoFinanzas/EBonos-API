using System.ComponentModel;

namespace EBono_API.Bonds.Domain.Models
{
    public enum EExpirationType : byte
    {
        [Description("YR")] 
        Years = 1,
        [Description("SM")] 
        Semesters = 2,
        [Description("QT")]
        Quarters = 4,
        [Description("TM")]
        Trimesters = 5,
        [Description("MT")]
        Months = 6,
        [Description("FT")]
        Fortnight = 7,
        [Description("DS")]
        Days = 8
    }
}