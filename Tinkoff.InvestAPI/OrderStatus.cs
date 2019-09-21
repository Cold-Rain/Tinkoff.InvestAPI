using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace Tinkoff.InvestAPI
{
    /// <summary>Статус заявки</summary>
    [GeneratedCode("NJsonSchema", "10.0.23.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum OrderStatus
    {
        [EnumMember(Value = @"New")]
        New = 0,

        [EnumMember(Value = @"PartiallyFill")]
        PartiallyFill = 1,

        [EnumMember(Value = @"Fill")]
        Fill = 2,

        [EnumMember(Value = @"Cancelled")]
        Cancelled = 3,

        [EnumMember(Value = @"Replaced")]
        Replaced = 4,

        [EnumMember(Value = @"PendingCancel")]
        PendingCancel = 5,

        [EnumMember(Value = @"Rejected")]
        Rejected = 6,

        [EnumMember(Value = @"PendingReplace")]
        PendingReplace = 7,

        [EnumMember(Value = @"PendingNew")]
        PendingNew = 8,

    }
}
