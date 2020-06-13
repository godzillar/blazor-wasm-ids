using Application.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Services
{
    public class ApiService: IApiService
    {
        private readonly HttpClient httpClient;

        public ApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> GetIdentityAsync()
        {
            var response = await httpClient.GetAsync("https://localhost:6001/api/identity").ConfigureAwait(false);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
