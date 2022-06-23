using Client.Contract;
using System.Net.Http.Json;

namespace Client.Services
{
    public class RESTSpaceXDataService : ISpaceXDataService
    {
        private readonly HttpClient _httpclient;

        public RESTSpaceXDataService(HttpClient httpclient)
        {
            _httpclient = httpclient;
        }

        public async Task<RocketDTO[]> GetAllRockets()
        {
            var result = await _httpclient.GetFromJsonAsync<RocketDTO[]>("/rest/rockets") ?? Array.Empty<RocketDTO>();

            return result;
        }
    }
}
