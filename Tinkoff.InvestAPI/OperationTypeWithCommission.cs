using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace Tinkoff.InvestAPI
{
    [GeneratedCode("NJsonSchema", "10.0.23.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum OperationTypeWithCommission
    {
        [EnumMember(Value = @"Buy")]
        Buy = 0,

        [EnumMember(Value = @"Sell")]
        Sell = 1,

        [EnumMember(Value = @"BrokerCommission")]
        BrokerCommission = 2,

        [EnumMember(Value = @"ExchangeCommission")]
        ExchangeCommission = 3,

        [EnumMember(Value = @"ServiceCommission")]
        ServiceCommission = 4,

        [EnumMember(Value = @"MarginCommission")]
        MarginCommission = 5,

    }
}
