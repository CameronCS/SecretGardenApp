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
            APILoginResponse? response;
            try {
                HttpResponseMessage responseMessage = await client.PostAsync($"{this.apiUrl}/{routeName}", content);
                response = await responseMessage.Content.ReadFromJsonAsync<APILoginResponse>();
            } catch (HttpRequestException) {
                response = new(0, "No Connection", new("", "", "", "", "", false, ""));
            }
            return response ?? throw new NullReferenceException("API Response Came back as NULL");
        }

        public async Task<APIGetChildrenResponse> GetChildren(string routeName, string userid) {
            APIGetChildrenResponse? response;
            try {
                HttpResponseMessage responseMessage = await client.GetAsync($"{this.apiUrl}/{routeName}/{userid}");
                response = await responseMessage.Content.ReadFromJsonAsync<APIGetChildrenResponse>();
            } catch (HttpRequestException) {
                response = new APIGetChildrenResponse(0, "No Connection", []);
            }
            return response ?? throw new NullReferenceException("API Response Came back as NULL");
        }

        public async Task<APIResponseNewsLetters> GetNewsLetters(string routeName, string classId) {
            APIResponseNewsLetters? response;
            try {
                HttpResponseMessage responseMessage = await client.GetAsync($"{this.apiUrl}/{routeName}/{classId}");
                response = await responseMessage.Content.ReadFromJsonAsync<APIResponseNewsLetters>();
            } catch (HttpRequestException) {
                response = new APIResponseNewsLetters();
            }
            return response ?? throw new NullReferenceException("API Response Came back as NULL");
        }
    }
}
