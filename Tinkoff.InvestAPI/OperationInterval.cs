using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace Tinkoff.InvestAPI
{
    [GeneratedCode("NJsonSchema", "10.0.23.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum OperationInterval
    {
        [EnumMember(Value = @"1day")]
        _1day = 0,

        [EnumMember(Value = @"7days")]
        _7days = 1,

        [EnumMember(Value = @"14days")]
        _14days = 2,

        [EnumMember(Value = @"30days")]
        _30days = 3,

    }
}