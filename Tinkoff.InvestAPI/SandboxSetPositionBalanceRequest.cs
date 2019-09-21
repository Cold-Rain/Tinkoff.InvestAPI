using Newtonsoft.Json;
using System.CodeDom.Compiler;
using System.Collections.Generic;


namespace Tinkoff.InvestAPI
{
    [GeneratedCode("NJsonSchema", "10.0.23.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class SandboxSetPositionBalanceRequest
    {
        [JsonProperty("figi", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Figi { get; set; }

        [JsonProperty("balance", Required = Required.Always)]
        public double Balance { get; set; }

        private IDictionary<string, object> additionalProperties = new Dictionary<string, object>();

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return additionalProperties; }
            set { additionalProperties = value; }
        }
    }
}
