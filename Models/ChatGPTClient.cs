using RestSharp;

namespace _521Final.Models
{
    public class ChatGPTClient
    {
        private readonly string _apiKey;
        private readonly RestClient _client;

        public ChatGPTClient(string apiKey)
        {
            _apiKey = apiKey;
            _client = new RestClient("https://api.openai.com/v1/");
        }

        public string GetChatResponse(string message)
        {
            //uncomment this out when its time to get the chat GOT going
            //var request = new RestRequest("engines/davinci-codex/completions", Method.POST);
            //request.AddHeader("Authorization", $"Bearer {_apiKey}");
            //request.AddJsonBody(new
            //{
            //    prompt = message,
            //    max_tokens = 100,
            //    n = 1,
            //    stop = "\n",
            //    temperature = 0.7
            //});

            //var response = _client.Execute<dynamic>(request);
            //return response.Data.choices[0].text;
            return "";
        }
    }
}
