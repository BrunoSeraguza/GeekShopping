using System.Net.Http.Headers;
using System.Text.Json;

namespace GeekShopping.web.Utils
{
    public static class HttpClienteExtensios
    {
        private static MediaTypeHeaderValue contentType = new MediaTypeHeaderValue("application/json");
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if(!response.IsSuccessStatusCode)
                throw new ApplicationException($"Algo de errado aconteceu com a chamada da API" +
                $"{response.ReasonPhrase}");          
            var dataString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<T>(
                dataString, new JsonSerializerOptions 
                { PropertyNameCaseInsensitive = true });
        }

        public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpClient, string url, T data) 
        {
            var dataString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataString);
            content.Headers.ContentType = contentType;

            return httpClient.PostAsync(url, content);
        } 
        public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpClient, string url, T data) 
        {
            var dataString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataString);
            content.Headers.ContentType = contentType;

            return httpClient.PutAsync(url, content);
        }

            
       
    }
}
