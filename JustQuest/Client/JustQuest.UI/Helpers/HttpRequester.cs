namespace JustQuest.UI.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class HttpRequester
    {
        protected string baseUrl = "http://localhost:17888/";

        private HttpClient client;

        public HttpRequester()
        {
            this.Client = new HttpClient();
        }

        public HttpClient Client
        {
            get
            {
                return this.client;
            }
            set
            {
                this.client = value;
            }
        }

        public async Task<HttpResponseMessage> Login(string username, string password)
        {
            var formContent = new Dictionary<string, string>
                            {
                                {"Username", username },
                                {"Password", password },
                                {"grant_type", "password" }
                            };

            var content = new FormUrlEncodedContent(formContent);

            var response = await client.PostAsync(baseUrl + "api/account/login", content);

            return response;
        }

        public async Task<HttpResponseMessage> Register(string username, string email, string password,
            string confirmPassword)
        {
            var formContent = new Dictionary<string, string>
                            {
                                {"Username", username },
                                {"Email", email },
                                {"Password", password },
                                {"ConfirmPassword", confirmPassword }
                            };
            var content = new FormUrlEncodedContent(formContent);

            var response = await client.PostAsync(baseUrl + "api/account/register", content);

            return response;
        }

        public async Task<HttpResponseMessage> PostData(object data, string url, string token)
        {
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                var json = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(data));
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await this.client.PostAsync(baseUrl + url, content);

                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        public async Task<HttpResponseMessage> GetDataAuthorize(string url, string token)
        {
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await this.GetData(url);
        }

        public async Task<HttpResponseMessage> GetData(string url)
        {
            try
            {
                var response = await this.client.GetAsync(this.baseUrl + url);

                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
