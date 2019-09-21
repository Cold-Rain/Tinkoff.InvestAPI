using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace Tinkoff.InvestAPI
{
    /// <summary>Тип заявки</summary>
    [GeneratedCode("NJsonSchema", "10.0.23.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum OrderType
    {
        [EnumMember(Value = @"Limit")]
        Limit = 0,

        [EnumMember(Value = @"Market")]
        Market = 1,

    }
}
