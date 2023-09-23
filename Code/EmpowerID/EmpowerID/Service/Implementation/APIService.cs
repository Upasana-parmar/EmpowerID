using EmpowerID.Service.Interface;
using System.Net.Http;
using System.Net.Http.Headers;

namespace EmpowerID.Service.Implementation
{
    public class APIService : IAPIService
    {
        private static HttpClient client = null;
        private readonly IConfiguration _configuration;
        public APIService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Public Methods
        public async Task<T> Post<T>(string url, HttpContent content)
        {
            LoadConfigurations();
            return await ConvertToType<T>(await Post(url, content).ConfigureAwait(false)).ConfigureAwait(false);
        }

        public async Task<T> Post<T>(string url, object param)
        {
            LoadConfigurations();
            return await ConvertToType<T>(await PostHttpClient(url, param).ConfigureAwait(false)).ConfigureAwait(false);
        }

        public async Task<T> Get<T>(string url, params object[] param)
        {
            LoadConfigurations();
            return await ConvertToType<T>(await GetHttpClient(PopulateOrderedQueryString(url, param)).ConfigureAwait(false)).ConfigureAwait(false);
        }
        public async Task<T> Delete<T>(string url, params object[] param)
        {
            LoadConfigurations();
            return await ConvertToType<T>(await DeleteHttpClient(PopulateOrderedQueryString(url, param)).ConfigureAwait(false)).ConfigureAwait(false);
        }
        public async Task Get(string url, params object[] param)
        {
            LoadConfigurations();
            await GetHttpClient(PopulateOrderedQueryString(url, param)).ConfigureAwait(false);
        }

        #endregion

        #region private methods and declarations
        private void LoadConfigurations()
        {
            //var handler = new HttpClientHandler
            //{
            //    ClientCertificateOptions = ClientCertificateOption.Manual,
            //    ServerCertificateCustomValidationCallback =
            //         (httpRequestMessage, cert, cetChain, policyErrors) =>
            //         {
            //             return true;
            //         }
            //};

            //client = new HttpClient(handler);
            client = new HttpClient();
            client.Timeout = new TimeSpan(0, 3, 0);
            client.BaseAddress = new Uri($"{_configuration["APIUrl"]}");
        }
        async static Task<T> ConvertToType<T>(HttpResponseMessage response)
        {
            return await response.Content.ReadAsAsync<T>().ConfigureAwait(false);
        }
        static string PopulateOrderedQueryString(string baseUri, object[] data)
        {
            foreach (var obj in data)
            {
                baseUri = baseUri + "/" + Convert.ToString(obj);
            }
            return baseUri;
        }

        async Task<HttpResponseMessage> Post(string baseUri, StringContent content)
        {
            HttpResponseMessage response = await client.PostAsync(baseUri, content).ConfigureAwait(false);
            return response.EnsureSuccessStatusCode();
        }
        async Task<HttpResponseMessage> Post(string baseUri, HttpContent content)
        {
            using (client)
            {
                System.Threading.CancellationToken cancellationToken = new System.Threading.CancellationToken();
                HttpResponseMessage response = await client.PostAsync(baseUri, content, cancellationToken).ConfigureAwait(false);
                return response.EnsureSuccessStatusCode();
            }
        }

        async Task<HttpResponseMessage> PostHttpClient(string baseUri, object data)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(baseUri, data).ConfigureAwait(false);
            return response.EnsureSuccessStatusCode();
        }
        async Task<HttpResponseMessage> GetHttpClient(string baseUri)
        {
            HttpResponseMessage response = await client.GetAsync(baseUri);
            return response.EnsureSuccessStatusCode();
        }
        async Task<HttpResponseMessage> DeleteHttpClient(string baseUri)
        {
            HttpResponseMessage response = await client.DeleteAsync(baseUri).ConfigureAwait(false);
            return response.EnsureSuccessStatusCode();
        }

        #endregion
    }
}
