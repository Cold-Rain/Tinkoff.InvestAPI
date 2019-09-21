using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace Tinkoff.InvestAPI
{
    [GeneratedCode("NJsonSchema", "10.0.23.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum InstrumentType
    {
        [EnumMember(Value = @"Stock")]
        Stock = 0,

        [EnumMember(Value = @"Currency")]
        Currency = 1,

        [EnumMember(Value = @"Bond")]
        Bond = 2,

        [EnumMember(Value = @"Etf")]
        Etf = 3,
    }
}
