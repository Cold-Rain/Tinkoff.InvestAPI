using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tinkoff.InvestAPI
{
    [GeneratedCode("NJsonSchema", "10.0.23.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class MarketInstrument
    {
        [JsonProperty("figi", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string Figi { get; set; }

        [JsonProperty("ticker", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string Ticker { get; set; }

        [JsonProperty("isin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Isin { get; set; }

        [JsonProperty("minPriceIncrement", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double MinPriceIncrement { get; set; }

        [JsonProperty("lot", Required = Required.Always)]
        public int Lot { get; set; }

        [JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Currency Currency { get; set; }

        private IDictionary<string, object> additionalProperties = new Dictionary<string, object>();

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return additionalProperties; }
            set { additionalProperties = value; }
        }
    }
}
