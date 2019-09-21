using Newtonsoft.Json;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tinkoff.InvestAPI
{
    [GeneratedCode("NSwag", "13.0.6.0 (NJsonSchema v10.0.23.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class RestClient
    {
        private const string StockExchangeUrl   = "https://api-invest.tinkoff.ru/openapi/";
        private const string SandboxUrl         = "https://api-invest.tinkoff.ru/openapi/sandbox";
        private bool useSandbox = true;
        private string token;
        private HttpClient httpClient;
        private Lazy<JsonSerializerSettings> settings;

        public RestClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            settings = new Lazy<JsonSerializerSettings>(() =>
            {
                var settings = new JsonSerializerSettings();
                UpdateJsonSerializerSettings(settings);
                return settings;
            });
        }

        public string Token
        {
            get { return token; }
            set { token = value; }
        }

        public string BaseUrl
        {
            get { return UseSandbox ? SandboxUrl : StockExchangeUrl; }
        }

        public bool UseSandbox
        {
            get { return useSandbox; }
            set { useSandbox = value; }
        }

        protected JsonSerializerSettings JsonSerializerSettings { get { return settings.Value; } }

        void UpdateJsonSerializerSettings(JsonSerializerSettings settings)
        {

        }

        void PrepareRequest(HttpClient client, HttpRequestMessage request, string url)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        }

        void PrepareRequest(HttpClient client, HttpRequestMessage request, StringBuilder urlBuilder)
        {

        }

        void ProcessResponse(HttpClient client, HttpResponseMessage response)
        {

        }

        /// <summary>Регистрация клиента в sandbox</summary>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<Empty> RegisterAsync()
        {
            return RegisterAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Регистрация клиента в sandbox</summary>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<Empty> RegisterAsync(CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl != null ? StockExchangeUrl.TrimEnd('/') : "").Append("/sandbox/register");

            var client = httpClient;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
                    request.Method = new HttpMethod("POST");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client, request, urlBuilder);
                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client, request, url);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        ProcessResponse(client, response);

                        var status = ((int)response.StatusCode).ToString();
                        if (status == "200")
                        {
                            var objectresponse = await ReadObjectResponseAsync<Empty>(response, headers).ConfigureAwait(false);
                            return objectresponse.Object;
                        }
                        else
                        if (status == "500")
                        {
                            var objectresponse = await ReadObjectResponseAsync<Error>(response, headers).ConfigureAwait(false);
                            throw new ApiException<Error>(
                                "\u041e\u0448\u0438\u0431\u043a\u0430 \u0437\u0430\u043f\u0440\u043e\u0441\u0430", 
                                (int)response.StatusCode, 
                                objectresponse.Text, 
                                headers, 
                                objectresponse.Object, 
                                null);
                        }
                        else
                        if (status != "200" && status != "204")
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException(
                                "The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", 
                                (int)response.StatusCode, 
                                responseData, 
                                headers, 
                                null);
                        }

                        return default(Empty);
                    }
                    finally
                    {
                        if (response != null)
                            response.Dispose();
                    }
                }
            }
            finally
            {
            }
        }

        /// <summary>Выставление баланса по валютным позициям</summary>
        /// <param name="body">Запрос на выставление баланса по валютным позициям</param>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<Empty> CurrenciesBalanceAsync(SandboxSetCurrencyBalanceRequest body)
        {
            return CurrenciesBalanceAsync(body, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Выставление баланса по валютным позициям</summary>
        /// <param name="body">Запрос на выставление баланса по валютным позициям</param>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<Empty> CurrenciesBalanceAsync(SandboxSetCurrencyBalanceRequest body, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl != null ? StockExchangeUrl.TrimEnd('/') : "").Append("/sandbox/currencies/balance");

            var client = httpClient;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(body, settings.Value));
                    content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    request.Content = content;
                    request.Method = new HttpMethod("POST");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client, request, urlBuilder);
                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client, request, url);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        ProcessResponse(client, response);

                        var status = ((int)response.StatusCode).ToString();
                        if (status == "200")
                        {
                            var objectresponse = await ReadObjectResponseAsync<Empty>(response, headers).ConfigureAwait(false);
                            return objectresponse.Object;
                        }
                        else
                        if (status == "500")
                        {
                            var objectresponse = await ReadObjectResponseAsync<Error>(response, headers).ConfigureAwait(false);
                            throw new ApiException<Error>("\u041e\u0448\u0438\u0431\u043a\u0430 \u0437\u0430\u043f\u0440\u043e\u0441\u0430", (int)response.StatusCode, objectresponse.Text, headers, objectresponse.Object, null);
                        }
                        else
                        if (status != "200" && status != "204")
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", (int)response.StatusCode, responseData, headers, null);
                        }

                        return default(Empty);
                    }
                    finally
                    {
                        if (response != null)
                            response.Dispose();
                    }
                }
            }
            finally
            {
            }
        }

        /// <summary>Выставление баланса по инструментным позициям</summary>
        /// <param name="body">Запрос на выставление баланса по инструментным позициям</param>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<Empty> PositionsBalanceAsync(SandboxSetPositionBalanceRequest body)
        {
            return PositionsBalanceAsync(body, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Выставление баланса по инструментным позициям</summary>
        /// <param name="body">Запрос на выставление баланса по инструментным позициям</param>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<Empty> PositionsBalanceAsync(SandboxSetPositionBalanceRequest body, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl != null ? StockExchangeUrl.TrimEnd('/') : "").Append("/sandbox/positions/balance");

            var client = httpClient;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(body, settings.Value));
                    content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    request.Content = content;
                    request.Method = new HttpMethod("POST");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client, request, urlBuilder);
                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client, request, url);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        ProcessResponse(client, response);

                        var status = ((int)response.StatusCode).ToString();
                        if (status == "200")
                        {
                            var objectresponse = await ReadObjectResponseAsync<Empty>(response, headers).ConfigureAwait(false);
                            return objectresponse.Object;
                        }
                        else
                        if (status == "500")
                        {
                            var objectresponse = await ReadObjectResponseAsync<Error>(response, headers).ConfigureAwait(false);
                            throw new ApiException<Error>("\u041e\u0448\u0438\u0431\u043a\u0430 \u0437\u0430\u043f\u0440\u043e\u0441\u0430", (int)response.StatusCode, objectresponse.Text, headers, objectresponse.Object, null);
                        }
                        else
                        if (status != "200" && status != "204")
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", (int)response.StatusCode, responseData, headers, null);
                        }

                        return default(Empty);
                    }
                    finally
                    {
                        if (response != null)
                            response.Dispose();
                    }
                }
            }
            finally
            {
            }
        }

        /// <summary>Удаление всех позиций</summary>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<Empty> ClearAsync()
        {
            return ClearAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Удаление всех позиций</summary>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<Empty> ClearAsync(CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl != null ? StockExchangeUrl.TrimEnd('/') : "").Append("/sandbox/clear");

            var client = httpClient;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
                    request.Method = new HttpMethod("POST");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client, request, urlBuilder);
                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client, request, url);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        ProcessResponse(client, response);

                        var status = ((int)response.StatusCode).ToString();
                        if (status == "200")
                        {
                            var objectresponse = await ReadObjectResponseAsync<Empty>(response, headers).ConfigureAwait(false);
                            return objectresponse.Object;
                        }
                        else
                        if (status == "500")
                        {
                            var objectresponse = await ReadObjectResponseAsync<Error>(response, headers).ConfigureAwait(false);
                            throw new ApiException<Error>("\u041e\u0448\u0438\u0431\u043a\u0430 \u0437\u0430\u043f\u0440\u043e\u0441\u0430", (int)response.StatusCode, objectresponse.Text, headers, objectresponse.Object, null);
                        }
                        else
                        if (status != "200" && status != "204")
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", (int)response.StatusCode, responseData, headers, null);
                        }

                        return default(Empty);
                    }
                    finally
                    {
                        if (response != null)
                            response.Dispose();
                    }
                }
            }
            finally
            {
            }
        }

        /// <summary>Получение списка активных заявок</summary>
        /// <returns>Список заявок</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<OrdersResponse> OrdersAsync()
        {
            return OrdersAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Получение списка активных заявок</summary>
        /// <returns>Список заявок</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<OrdersResponse> OrdersAsync(CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/orders");

            var client = httpClient;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Method = new HttpMethod("GET");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client, request, urlBuilder);
                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client, request, url);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        ProcessResponse(client, response);

                        var status = ((int)response.StatusCode).ToString();
                        if (status == "200")
                        {
                            var objectresponse = await ReadObjectResponseAsync<OrdersResponse>(response, headers).ConfigureAwait(false);
                            return objectresponse.Object;
                        }
                        else
                        if (status == "500")
                        {
                            var objectresponse = await ReadObjectResponseAsync<Error>(response, headers).ConfigureAwait(false);
                            throw new ApiException<Error>("\u0418\u043d\u0441\u0442\u0440\u0443\u043c\u0435\u043d\u0442 \u043d\u0435 \u043d\u0430\u0439\u0434\u0435\u043d", (int)response.StatusCode, objectresponse.Text, headers, objectresponse.Object, null);
                        }
                        else
                        if (status != "200" && status != "204")
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", (int)response.StatusCode, responseData, headers, null);
                        }

                        return default(OrdersResponse);
                    }
                    finally
                    {
                        if (response != null)
                            response.Dispose();
                    }
                }
            }
            finally
            {
            }
        }

        /// <summary>Создание лимитной заявки</summary>
        /// <param name="figi">FIGI инструмента</param>
        /// <returns>Созданная заявка</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<LimitOrderResponse> LimitOrderAsync(string figi, LimitOrderRequest body)
        {
            return LimitOrderAsync(figi, body, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Создание лимитной заявки</summary>
        /// <param name="figi">FIGI инструмента</param>
        /// <returns>Созданная заявка</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<LimitOrderResponse> LimitOrderAsync(string figi, LimitOrderRequest body, CancellationToken cancellationToken)
        {
            if (figi == null)
                throw new ArgumentNullException("figi");

            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/orders/limit-order?");
            urlBuilder.Append(Uri.EscapeDataString("figi") + "=").Append(Uri.EscapeDataString(ConvertToString(figi, CultureInfo.InvariantCulture))).Append("&");
            urlBuilder.Length--;

            var client = httpClient;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(body, settings.Value));
                    content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    request.Content = content;
                    request.Method = new HttpMethod("POST");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client, request, urlBuilder);
                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client, request, url);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        ProcessResponse(client, response);

                        var status = ((int)response.StatusCode).ToString();
                        if (status == "200")
                        {
                            var objectresponse = await ReadObjectResponseAsync<LimitOrderResponse>(response, headers).ConfigureAwait(false);
                            return objectresponse.Object;
                        }
                        else
                        if (status == "500")
                        {
                            var objectresponse = await ReadObjectResponseAsync<Error>(response, headers).ConfigureAwait(false);
                            throw new ApiException<Error>("\u041e\u0448\u0438\u0431\u043a\u0430 \u0437\u0430\u043f\u0440\u043e\u0441\u0430", (int)response.StatusCode, objectresponse.Text, headers, objectresponse.Object, null);
                        }
                        else
                        if (status != "200" && status != "204")
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", (int)response.StatusCode, responseData, headers, null);
                        }

                        return default(LimitOrderResponse);
                    }
                    finally
                    {
                        if (response != null)
                            response.Dispose();
                    }
                }
            }
            finally
            {
            }
        }

        /// <summary>Отмена заявки</summary>
        /// <param name="orderId">ID заявки</param>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<Empty> CancelAsync(string orderId, Empty body)
        {
            return CancelAsync(orderId, body, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Отмена заявки</summary>
        /// <param name="orderId">ID заявки</param>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<Empty> CancelAsync(string orderId, Empty body, CancellationToken cancellationToken)
        {
            if (orderId == null)
                throw new ArgumentNullException("orderId");

            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/orders/cancel?");
            urlBuilder.Append(Uri.EscapeDataString("orderId") + "=").Append(Uri.EscapeDataString(ConvertToString(orderId, CultureInfo.InvariantCulture))).Append("&");
            urlBuilder.Length--;

            var client = httpClient;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(body, settings.Value));
                    content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    request.Content = content;
                    request.Method = new HttpMethod("POST");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client, request, urlBuilder);
                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client, request, url);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        ProcessResponse(client, response);

                        var status = ((int)response.StatusCode).ToString();
                        if (status == "200")
                        {
                            var objectresponse = await ReadObjectResponseAsync<Empty>(response, headers).ConfigureAwait(false);
                            return objectresponse.Object;
                        }
                        else
                        if (status == "500")
                        {
                            var objectresponse = await ReadObjectResponseAsync<Error>(response, headers).ConfigureAwait(false);
                            throw new ApiException<Error>("\u041e\u0448\u0438\u0431\u043a\u0430 \u0437\u0430\u043f\u0440\u043e\u0441\u0430", (int)response.StatusCode, objectresponse.Text, headers, objectresponse.Object, null);
                        }
                        else
                        if (status != "200" && status != "204")
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", (int)response.StatusCode, responseData, headers, null);
                        }

                        return default(Empty);
                    }
                    finally
                    {
                        if (response != null)
                            response.Dispose();
                    }
                }
            }
            finally
            {
            }
        }

        /// <summary>Получение списка операций</summary>
        /// <param name="from">Начало временного промежутка</param>
        /// <param name="interval">Длительность временного промежутка</param>
        /// <param name="figi">Figi инструмента для фильтрации</param>
        /// <returns>Список операций</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<OperationsResponse> OperationsAsync(DateTimeOffset from, OperationInterval interval, string figi)
        {
            return OperationsAsync(from, interval, figi, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Получение списка операций</summary>
        /// <param name="from">Начало временного промежутка</param>
        /// <param name="interval">Длительность временного промежутка</param>
        /// <param name="figi">Figi инструмента для фильтрации</param>
        /// <returns>Список операций</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<OperationsResponse> OperationsAsync(DateTimeOffset from, OperationInterval interval, string figi, CancellationToken cancellationToken)
        {
            if (from == null)
                throw new ArgumentNullException("from");
            
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/operations?");
            urlBuilder.Append(Uri.EscapeDataString("from") + "=").Append(Uri.EscapeDataString(from.ToString("s", CultureInfo.InvariantCulture))).Append("&");
            urlBuilder.Append(Uri.EscapeDataString("interval") + "=").Append(Uri.EscapeDataString(ConvertToString(interval, CultureInfo.InvariantCulture))).Append("&");
            if (figi != null)
            {
                urlBuilder.Append(Uri.EscapeDataString("figi") + "=").Append(Uri.EscapeDataString(ConvertToString(figi, CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder.Length--;

            var client = httpClient;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Method = new HttpMethod("GET");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client, request, urlBuilder);
                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client, request, url);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        ProcessResponse(client, response);

                        var status = ((int)response.StatusCode).ToString();
                        if (status == "200")
                        {
                            var objectresponse = await ReadObjectResponseAsync<OperationsResponse>(response, headers).ConfigureAwait(false);
                            return objectresponse.Object;
                        }
                        else
                        if (status == "500")
                        {
                            var objectresponse = await ReadObjectResponseAsync<Error>(response, headers).ConfigureAwait(false);
                            throw new ApiException<Error>("\u0411\u0440\u043e\u043a\u0435\u0440\u0441\u043a\u0438\u0439 \u0441\u0447\u0435\u0442 \u043d\u0435 \u043d\u0430\u0439\u0434\u0435\u043d", (int)response.StatusCode, objectresponse.Text, headers, objectresponse.Object, null);
                        }
                        else
                        if (status != "200" && status != "204")
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", (int)response.StatusCode, responseData, headers, null);
                        }

                        return default(OperationsResponse);
                    }
                    finally
                    {
                        if (response != null)
                            response.Dispose();
                    }
                }
            }
            finally
            {
            }
        }

        /// <summary>Получение портфеля клиента</summary>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<PortfolioResponse> PortfolioAsync()
        {
            return PortfolioAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Получение портфеля клиента</summary>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<PortfolioResponse> PortfolioAsync(CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/portfolio");

            var client = httpClient;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Method = new HttpMethod("GET");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client, request, urlBuilder);
                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client, request, url);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        ProcessResponse(client, response);

                        var status = ((int)response.StatusCode).ToString();
                        if (status == "200")
                        {
                            var objectresponse = await ReadObjectResponseAsync<PortfolioResponse>(response, headers).ConfigureAwait(false);
                            return objectresponse.Object;
                        }
                        else
                        if (status == "500")
                        {
                            var objectresponse = await ReadObjectResponseAsync<Error>(response, headers).ConfigureAwait(false);
                            throw new ApiException<Error>("\u0418\u043d\u0441\u0442\u0440\u0443\u043c\u0435\u043d\u0442 \u043d\u0435 \u043d\u0430\u0439\u0434\u0435\u043d", (int)response.StatusCode, objectresponse.Text, headers, objectresponse.Object, null);
                        }
                        else
                        if (status != "200" && status != "204")
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", (int)response.StatusCode, responseData, headers, null);
                        }

                        return default(PortfolioResponse);
                    }
                    finally
                    {
                        if (response != null)
                            response.Dispose();
                    }
                }
            }
            finally
            {
            }
        }

        /// <summary>Получение валютных активов клиента</summary>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<PortfolioCurrenciesResponse> PortfolioCurrenciesAsync()
        {
            return PortfolioCurrenciesAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Получение валютных активов клиента</summary>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<PortfolioCurrenciesResponse> PortfolioCurrenciesAsync(CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/portfolio/currencies");

            var client = httpClient;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Method = new HttpMethod("GET");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client, request, urlBuilder);
                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client, request, url);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        ProcessResponse(client, response);

                        var status = ((int)response.StatusCode).ToString();
                        if (status == "200")
                        {
                            var objectresponse = await ReadObjectResponseAsync<PortfolioCurrenciesResponse>(response, headers).ConfigureAwait(false);
                            return objectresponse.Object;
                        }
                        else
                        if (status == "500")
                        {
                            var objectresponse = await ReadObjectResponseAsync<Error>(response, headers).ConfigureAwait(false);
                            throw new ApiException<Error>("\u0418\u043d\u0441\u0442\u0440\u0443\u043c\u0435\u043d\u0442 \u043d\u0435 \u043d\u0430\u0439\u0434\u0435\u043d", (int)response.StatusCode, objectresponse.Text, headers, objectresponse.Object, null);
                        }
                        else
                        if (status != "200" && status != "204")
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", (int)response.StatusCode, responseData, headers, null);
                        }

                        return default(PortfolioCurrenciesResponse);
                    }
                    finally
                    {
                        if (response != null)
                            response.Dispose();
                    }
                }
            }
            finally
            {
            }
        }

        /// <summary>Получение списка акций</summary>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<MarketInstrumentListResponse> StocksAsync()
        {
            return StocksAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Получение списка акций</summary>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<MarketInstrumentListResponse> StocksAsync(CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/market/stocks");

            var client = httpClient;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Method = new HttpMethod("GET");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client, request, urlBuilder);
                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client, request, url);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        ProcessResponse(client, response);

                        var status = ((int)response.StatusCode).ToString();
                        if (status == "200")
                        {
                            var objectresponse = await ReadObjectResponseAsync<MarketInstrumentListResponse>(response, headers).ConfigureAwait(false);
                            return objectresponse.Object;
                        }
                        else
                        if (status == "500")
                        {
                            var objectresponse = await ReadObjectResponseAsync<Error>(response, headers).ConfigureAwait(false);
                            throw new ApiException<Error>("\u0418\u043d\u0441\u0442\u0440\u0443\u043c\u0435\u043d\u0442 \u043d\u0435 \u043d\u0430\u0439\u0434\u0435\u043d", (int)response.StatusCode, objectresponse.Text, headers, objectresponse.Object, null);
                        }
                        else
                        if (status != "200" && status != "204")
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", (int)response.StatusCode, responseData, headers, null);
                        }

                        return default(MarketInstrumentListResponse);
                    }
                    finally
                    {
                        if (response != null)
                            response.Dispose();
                    }
                }
            }
            finally
            {
            }
        }

        /// <summary>Получение списка облигаций</summary>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<MarketInstrumentListResponse> BondsAsync()
        {
            return BondsAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Получение списка облигаций</summary>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<MarketInstrumentListResponse> BondsAsync(CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/market/bonds");

            var client = httpClient;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Method = new HttpMethod("GET");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client, request, urlBuilder);
                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client, request, url);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        ProcessResponse(client, response);

                        var status = ((int)response.StatusCode).ToString();
                        if (status == "200")
                        {
                            var objectresponse = await ReadObjectResponseAsync<MarketInstrumentListResponse>(response, headers).ConfigureAwait(false);
                            return objectresponse.Object;
                        }
                        else
                        if (status == "500")
                        {
                            var objectresponse = await ReadObjectResponseAsync<Error>(response, headers).ConfigureAwait(false);
                            throw new ApiException<Error>("\u0418\u043d\u0441\u0442\u0440\u0443\u043c\u0435\u043d\u0442 \u043d\u0435 \u043d\u0430\u0439\u0434\u0435\u043d", (int)response.StatusCode, objectresponse.Text, headers, objectresponse.Object, null);
                        }
                        else
                        if (status != "200" && status != "204")
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", (int)response.StatusCode, responseData, headers, null);
                        }

                        return default(MarketInstrumentListResponse);
                    }
                    finally
                    {
                        if (response != null)
                            response.Dispose();
                    }
                }
            }
            finally
            {
            }
        }

        /// <summary>Получение списка ETF</summary>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<MarketInstrumentListResponse> EtfsAsync()
        {
            return EtfsAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Получение списка ETF</summary>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<MarketInstrumentListResponse> EtfsAsync(CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/market/etfs");

            var client = httpClient;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Method = new HttpMethod("GET");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client, request, urlBuilder);
                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client, request, url);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        ProcessResponse(client, response);

                        var status = ((int)response.StatusCode).ToString();
                        if (status == "200")
                        {
                            var objectresponse = await ReadObjectResponseAsync<MarketInstrumentListResponse>(response, headers).ConfigureAwait(false);
                            return objectresponse.Object;
                        }
                        else
                        if (status == "500")
                        {
                            var objectresponse = await ReadObjectResponseAsync<Error>(response, headers).ConfigureAwait(false);
                            throw new ApiException<Error>("\u0418\u043d\u0441\u0442\u0440\u0443\u043c\u0435\u043d\u0442 \u043d\u0435 \u043d\u0430\u0439\u0434\u0435\u043d", (int)response.StatusCode, objectresponse.Text, headers, objectresponse.Object, null);
                        }
                        else
                        if (status != "200" && status != "204")
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", (int)response.StatusCode, responseData, headers, null);
                        }

                        return default(MarketInstrumentListResponse);
                    }
                    finally
                    {
                        if (response != null)
                            response.Dispose();
                    }
                }
            }
            finally
            {
            }
        }

        /// <summary>Получение списка валютных пар</summary>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<MarketInstrumentListResponse> MarketCurrenciesAsync()
        {
            return MarketCurrenciesAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Получение списка валютных пар</summary>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<MarketInstrumentListResponse> MarketCurrenciesAsync(CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/market/currencies");

            var client = httpClient;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Method = new HttpMethod("GET");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client, request, urlBuilder);
                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client, request, url);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        ProcessResponse(client, response);

                        var status = ((int)response.StatusCode).ToString();
                        if (status == "200")
                        {
                            var objectresponse = await ReadObjectResponseAsync<MarketInstrumentListResponse>(response, headers).ConfigureAwait(false);
                            return objectresponse.Object;
                        }
                        else
                        if (status == "500")
                        {
                            var objectresponse = await ReadObjectResponseAsync<Error>(response, headers).ConfigureAwait(false);
                            throw new ApiException<Error>("\u0418\u043d\u0441\u0442\u0440\u0443\u043c\u0435\u043d\u0442 \u043d\u0435 \u043d\u0430\u0439\u0434\u0435\u043d", (int)response.StatusCode, objectresponse.Text, headers, objectresponse.Object, null);
                        }
                        else
                        if (status != "200" && status != "204")
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", (int)response.StatusCode, responseData, headers, null);
                        }

                        return default(MarketInstrumentListResponse);
                    }
                    finally
                    {
                        if (response != null)
                            response.Dispose();
                    }
                }
            }
            finally
            {
            }
        }

        /// <summary>Получение инструмента по FIGI</summary>
        /// <param name="figi">FIGI</param>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<MarketInstrumentResponse> ByFigiAsync(string figi)
        {
            return ByFigiAsync(figi, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Получение инструмента по FIGI</summary>
        /// <param name="figi">FIGI</param>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<MarketInstrumentResponse> ByFigiAsync(string figi, CancellationToken cancellationToken)
        {
            if (figi == null)
                throw new ArgumentNullException("figi");

            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/market/search/by-figi?");
            urlBuilder.Append(Uri.EscapeDataString("figi") + "=").Append(Uri.EscapeDataString(ConvertToString(figi, CultureInfo.InvariantCulture))).Append("&");
            urlBuilder.Length--;

            var client = httpClient;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Method = new HttpMethod("GET");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client, request, urlBuilder);
                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client, request, url);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        ProcessResponse(client, response);

                        var status = ((int)response.StatusCode).ToString();
                        if (status == "200")
                        {
                            var objectresponse = await ReadObjectResponseAsync<MarketInstrumentResponse>(response, headers).ConfigureAwait(false);
                            return objectresponse.Object;
                        }
                        else
                        if (status == "500")
                        {
                            var objectresponse = await ReadObjectResponseAsync<Error>(response, headers).ConfigureAwait(false);
                            throw new ApiException<Error>("\u0418\u043d\u0441\u0442\u0440\u0443\u043c\u0435\u043d\u0442 \u043d\u0435 \u043d\u0430\u0439\u0434\u0435\u043d", (int)response.StatusCode, objectresponse.Text, headers, objectresponse.Object, null);
                        }
                        else
                        if (status != "200" && status != "204")
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", (int)response.StatusCode, responseData, headers, null);
                        }

                        return default(MarketInstrumentResponse);
                    }
                    finally
                    {
                        if (response != null)
                            response.Dispose();
                    }
                }
            }
            finally
            {
            }
        }

        /// <summary>Получение инструмента по тикеру</summary>
        /// <param name="ticker">Тикер инструмента</param>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<MarketInstrumentListResponse> ByTickerAsync(string ticker)
        {
            return ByTickerAsync(ticker, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Получение инструмента по тикеру</summary>
        /// <param name="ticker">Тикер инструмента</param>
        /// <returns>Успешный ответ</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<MarketInstrumentListResponse> ByTickerAsync(string ticker, CancellationToken cancellationToken)
        {
            if (ticker == null)
                throw new ArgumentNullException("ticker");

            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/market/search/by-ticker?");
            urlBuilder.Append(Uri.EscapeDataString("ticker") + "=").Append(Uri.EscapeDataString(ConvertToString(ticker, CultureInfo.InvariantCulture))).Append("&");
            urlBuilder.Length--;

            var client = httpClient;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Method = new HttpMethod("GET");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client, request, urlBuilder);
                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client, request, url);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        ProcessResponse(client, response);

                        var status = ((int)response.StatusCode).ToString();
                        if (status == "200")
                        {
                            var objectresponse = await ReadObjectResponseAsync<MarketInstrumentListResponse>(response, headers).ConfigureAwait(false);
                            return objectresponse.Object;
                        }
                        else
                        if (status == "500")
                        {
                            var objectresponse = await ReadObjectResponseAsync<Error>(response, headers).ConfigureAwait(false);
                            throw new ApiException<Error>("\u0418\u043d\u0441\u0442\u0440\u0443\u043c\u0435\u043d\u0442 \u043d\u0435 \u043d\u0430\u0439\u0434\u0435\u043d", (int)response.StatusCode, objectresponse.Text, headers, objectresponse.Object, null);
                        }
                        else
                        if (status != "200" && status != "204")
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", (int)response.StatusCode, responseData, headers, null);
                        }

                        return default(MarketInstrumentListResponse);
                    }
                    finally
                    {
                        if (response != null)
                            response.Dispose();
                    }
                }
            }
            finally
            {
            }
        }

        protected struct ObjectResponseResult<T>
        {
            public ObjectResponseResult(T responseObject, string responseText)
            {
                Object = responseObject;
                Text = responseText;
            }

            public T Object { get; }

            public string Text { get; }
        }

        public bool ReadResponseAsString { get; set; }

        protected virtual async Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(HttpResponseMessage response, IReadOnlyDictionary<string, IEnumerable<string>> headers)
        {
            if (response == null || response.Content == null)
            {
                return new ObjectResponseResult<T>(default(T), string.Empty);
            }

            if (ReadResponseAsString)
            {
                var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    var typedBody = JsonConvert.DeserializeObject<T>(responseText, JsonSerializerSettings);
                    return new ObjectResponseResult<T>(typedBody, responseText);
                }
                catch (JsonException exception)
                {
                    var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
                }
            }
            else
            {
                try
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    using (var streamReader = new StreamReader(responseStream))
                    using (var jsonTextReader = new JsonTextReader(streamReader))
                    {
                        var serializer = JsonSerializer.Create(JsonSerializerSettings);
                        var typedBody = serializer.Deserialize<T>(jsonTextReader);
                        return new ObjectResponseResult<T>(typedBody, string.Empty);
                    }
                }
                catch (JsonException exception)
                {
                    var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
                }
            }
        }

        private string ConvertToString(object value, CultureInfo cultureInfo)
        {
            if (value is Enum)
            {
                string name = Enum.GetName(value.GetType(), value);
                if (name != null)
                {
                    var field = IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                    if (field != null)
                    {
                        var attribute = CustomAttributeExtensions.GetCustomAttribute(field, typeof(EnumMemberAttribute))
                            as EnumMemberAttribute;
                        if (attribute != null)
                        {
                            return attribute.Value != null ? attribute.Value : name;
                        }
                    }
                }
            }
            else if (value is bool)
            {
                return Convert.ToString(value, cultureInfo).ToLowerInvariant();
            }
            else if (value is byte[])
            {
                return Convert.ToBase64String((byte[])value);
            }
            else if (value != null && value.GetType().IsArray)
            {
                var array = Enumerable.OfType<object>((Array)value);
                return string.Join(",", Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
            }

            return Convert.ToString(value, cultureInfo);
        }
    }
}
