using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailXamarin.Utils
{
    public static class ServerRequestFacade
    {
        private static HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://192.168.0.103:5000")
        };

        public static async Task<bool> CheckConnection()
        {
            try
            {
                CancellationTokenSource cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(3));
                await _httpClient.GetAsync(_httpClient.BaseAddress, cancellationToken.Token);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static async Task<string> Send(string partURL, HttpMethod method, object data = null)
        {
            HttpRequestMessage request = new HttpRequestMessage(method, partURL);

            SettingData(request, data);

            HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(request);
            httpResponseMessage.EnsureSuccessStatusCode();

            string result = await httpResponseMessage.Content.ReadAsStringAsync();
            return result;
        }

        private static void SettingData(HttpRequestMessage request, object data)
        {
            if (data == null)
            {
                return;
            }

            Dictionary<bool, Action> dataTypeActions = new Dictionary<bool, Action>()
            {
                [data is string] = () => SettingJSON(request, data as string),
            };

            dataTypeActions[true]?.Invoke();
        }

        private static void SettingJSON(HttpRequestMessage request, string data)
        {
            request.Content = new StringContent(data, Encoding.UTF8, "application/json");
        }
    }
}