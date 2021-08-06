using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECountry.IntegrationTests.Web
{
    public static class HttpContentTestHelperExtensions
    {
        public static async Task<HttpResponseMessage> PostJsonAsync<T>(this HttpClient client, string url, T value)
        {
            return await client.PostAsync(url, new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json"));
        }

        public static async Task<HttpResponseMessage> PutJsonAsync<T>(this HttpClient client, string url, T value)
        {
            return await client.PutAsync(url, new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json"));
        }

        public static async Task<T> ReadAsAsync<T>(this HttpContent content)
        {
            var responseString = await content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(responseString, new()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IgnoreNullValues = true,
                Converters =
                {
                    new ResultJsonConverterFactory(),
                    new FailureJsonConverter(),
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                }
            });
        }
    }
}
