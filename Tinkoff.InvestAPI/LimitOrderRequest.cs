using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tinkoff.InvestAPI
{
    [GeneratedCode("NJsonSchema", "10.0.23.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class LimitOrderRequest
    {
        [JsonProperty("lots", Required = Required.Always)]
        public int Lots { get; set; }

        [JsonProperty("operation", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(StringEnumConverter))]
        public OperationType Operation { get; set; }

        [JsonProperty("price", Required = Required.Always)]
        public double Price { get; set; }

        private IDictionary<string, object> additionalProperties = new Dictionary<string, object>();

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return additionalProperties; }
            set { additionalProperties = value; }
        }


    }
}