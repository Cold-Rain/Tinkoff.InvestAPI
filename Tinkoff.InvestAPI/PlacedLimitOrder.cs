using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Tinkoff.InvestAPI
{
    [GeneratedCode("NJsonSchema", "10.0.23.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PlacedLimitOrder
    {
        [JsonProperty("orderId", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string OrderId { get; set; }

        [JsonProperty("operation", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(StringEnumConverter))]
        public OperationType Operation { get; set; }

        [JsonProperty("status", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderStatus Status { get; set; }

        [JsonProperty("rejectReason", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string RejectReason { get; set; }

        [JsonProperty("requestedLots", Required = Required.Always)]
        public int RequestedLots { get; set; }

        [JsonProperty("executedLots", Required = Required.Always)]
        public int ExecutedLots { get; set; }

        [JsonProperty("commission", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public MoneyAmount Commission { get; set; }

        private IDictionary<string, object> additionalProperties = new Dictionary<string, object>();

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return additionalProperties; }
            set { additionalProperties = value; }
        }
    }
}
