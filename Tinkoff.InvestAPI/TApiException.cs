using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;


namespace Tinkoff.InvestAPI
{
    [GeneratedCode("NSwag", "13.0.6.0 (NJsonSchema v10.0.23.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class ApiException<TResult> : ApiException
    {
        public TResult Result { get; private set; }

        public ApiException(
            string message, 
            int statusCode, 
            string response, 
            IReadOnlyDictionary<string, IEnumerable<string>> headers, 
            TResult result, 
            Exception innerException)
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    }
}