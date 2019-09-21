using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace Tinkoff.InvestAPI
{
    [GeneratedCode("NJsonSchema", "10.0.23.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum OperationType
    {
        [EnumMember(Value = @"Buy")]
        Buy = 0,

        [EnumMember(Value = @"Sell")]
        Sell = 1,
    }
}
