using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace Tinkoff.InvestAPI
{
    /// <summary>Статус заявки</summary>
    [GeneratedCode("NJsonSchema", "10.0.23.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum OperationStatus
    {
        [EnumMember(Value = @"Done")]
        Done = 0,

        [EnumMember(Value = @"Decline")]
        Decline = 1,

        [EnumMember(Value = @"Progress")]
        Progress = 2,
    }
}
