using System.Net.Http.Json;

namespace APIHandler {
    public class APIController {
        private readonly HttpClient client;
        private readonly string apiUrl;
        public APIController(string apiUrl) {
            HttpClientHandler handler = new();
            this.client = new(handler);
            this.apiUrl = apiUrl;
        }

        public async Task<APILoginResponse> PostLogIn(string routeName, Dictionary<string, string> data) {
            FormUrlEncodedContent content = new(data);
            HttpResponseMessage responseMessage = await client.PostAsync($"{this.apiUrl}/{routeName}", content);

            APILoginResponse? response = await responseMessage.Content.ReadFromJsonAsync<APILoginResponse>();
            return response ?? throw new NullReferenceException("API Response Came back as NULL");
        }

        public async Task<APIGetChildrenResponse> GetChildren(string routeName) {
            HttpResponseMessage responseMessage = await client.GetAsync($"{apiUrl}/{routeName}");

            APIGetChildrenResponse? response = await responseMessage.Content.ReadFromJsonAsync<APIGetChildrenResponse>();
            return response ?? throw new NullReferenceException("API Response Came back as NULL");
        }
    }
}
