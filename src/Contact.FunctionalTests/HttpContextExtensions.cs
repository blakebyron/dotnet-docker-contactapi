using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Contact.FunctionalTests
{
    public static class HttpContextExtensions
    {
        public static async Task<TResult> ReadAsJsonAsync<TResult>(this HttpContent content)
        {
            var responseString = await content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResult>(responseString);
        }
    }
}
