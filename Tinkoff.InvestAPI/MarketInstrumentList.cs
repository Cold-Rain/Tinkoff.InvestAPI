using Newtonsoft.Json;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tinkoff.InvestAPI
{
    [GeneratedCode("NJsonSchema", "10.0.23.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class MarketInstrumentList
    {
        [JsonProperty("total", Required = Required.Always)]
        public double Total { get; set; }

        [JsonProperty("instruments", Required = Required.Always)]
        [Required]
        public ICollection<MarketInstrument> Instruments { get; set; } = new System.Collections.ObjectModel.Collection<MarketInstrument>();

        private IDictionary<string, object> additionalProperties = new Dictionary<string, object>();

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return additionalProperties; }
            set { additionalProperties = value; }
        }
    }
}
