using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Tinkoff.InvestAPI
{
    [GeneratedCode("NJsonSchema", "10.0.23.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Operation
    {
        [JsonProperty("id", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string Id { get; set; }

        [JsonProperty("status", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(StringEnumConverter))]
        public OperationStatus Status { get; set; }

        [JsonProperty("trades", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<OperationTrade> Trades { get; set; }

        [JsonProperty("commission", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public MoneyAmount Commission { get; set; }

        [JsonProperty("currency", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Currency Currency { get; set; }

        [JsonProperty("payment", Required = Required.Always)]
        public double Payment { get; set; }

        [JsonProperty("price", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double Price { get; set; }

        [JsonProperty("quantity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int Quantity { get; set; }

        [JsonProperty("figi", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Figi { get; set; }

        [JsonProperty("instrumentType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public InstrumentType InstrumentType { get; set; }

        [JsonProperty("isMarginCall", Required = Required.Always)]
        public bool IsMarginCall { get; set; }

        /// <summary>ISO8601</summary>
        [JsonProperty("date", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public System.DateTimeOffset Date { get; set; }

        [JsonProperty("operationType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public OperationTypeWithCommission OperationType { get; set; }

        private IDictionary<string, object> additionalProperties = new Dictionary<string, object>();

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return additionalProperties; }
            set { additionalProperties = value; }
        }
    }
}
