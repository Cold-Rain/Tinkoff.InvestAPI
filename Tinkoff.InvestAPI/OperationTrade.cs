using Newtonsoft.Json;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Tinkoff.InvestAPI
{
    [GeneratedCode("NJsonSchema", "10.0.23.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class OperationTrade
    {
        [JsonProperty("tradeId", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string TradeId { get; set; }

        /// <summary>ISO8601</summary>
        [JsonProperty("date", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public System.DateTimeOffset Date { get; set; }

        [JsonProperty("price", Required = Required.Always)]
        public double Price { get; set; }

        [JsonProperty("quantity", Required = Required.Always)]
        public int Quantity { get; set; }

        private IDictionary<string, object> additionalProperties = new Dictionary<string, object>();

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return additionalProperties; }
            set { additionalProperties = value; }
        }
    }
}
