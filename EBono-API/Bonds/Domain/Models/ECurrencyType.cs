using System.ComponentModel;

namespace EBono_API.Bonds.Domain.Models
{
    public enum ECurrencyType : int
    {
        [Description("DOL")]
        Dollar = 1,
        [Description("PEN")]
        Sol = 2
    }
}