using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Tinkoff.InvestAPI
{
    [GeneratedCode("NJsonSchema", "10.0.23.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PortfolioPosition
    {
        [JsonProperty("figi", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string Figi { get; set; }

        [JsonProperty("ticker", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Ticker { get; set; }

        [JsonProperty("isin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Isin { get; set; }

        [JsonProperty("instrumentType", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(StringEnumConverter))]
        public InstrumentType InstrumentType { get; set; }

        [JsonProperty("balance", Required = Required.Always)]
        public double Balance { get; set; }

        [JsonProperty("blocked", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double Blocked { get; set; }

        [JsonProperty("expectedYield", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public MoneyAmount ExpectedYield { get; set; }

        [JsonProperty("lots", Required = Required.Always)]
        public int Lots { get; set; }

        private IDictionary<string, object> additionalProperties = new Dictionary<string, object>();

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return additionalProperties; }
            set { additionalProperties = value; }
        }
    }
}
