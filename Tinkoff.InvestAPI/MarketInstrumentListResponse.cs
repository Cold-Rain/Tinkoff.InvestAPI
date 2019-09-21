using Newtonsoft.Json;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Tinkoff.InvestAPI
{
    [GeneratedCode("NJsonSchema", "10.0.23.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class MarketInstrumentListResponse
    {
        [JsonProperty("trackingId", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string TrackingId { get; set; }

        [JsonProperty("status", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string Status { get; set; } = "Ok";

        [JsonProperty("payload", Required = Required.Always)]
        [Required]
        public MarketInstrumentList Payload { get; set; } = new MarketInstrumentList();

        private IDictionary<string, object> additionalProperties = new Dictionary<string, object>();

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return additionalProperties; }
            set { additionalProperties = value; }
        }
    }
}
