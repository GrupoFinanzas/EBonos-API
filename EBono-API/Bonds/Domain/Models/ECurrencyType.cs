using System.ComponentModel;

namespace EBono_API.Bonds.Domain.Models
{
    public enum ECurrencyType : byte
    {
        [Description("DOL")]
        Dollar = 1,
        [Description("SOL")]
        Sol = 2
    }
}