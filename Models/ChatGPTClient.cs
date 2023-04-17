using OpenAI.Api;
using OpenAI.Api.V1;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace _521Final.Models
{
    public class ChatGPTClient
    {
        private const string API_KEY = "YOUR_API_KEY_HERE"; // Replace with your OpenAI API key

        public static async Task<string> GenerateSummary(string bookName)
        {
            var client = new OpenAIApi(API_KEY);
            var completions = await client.Completions.CreateCompletionAsync(
                engine: Engine.Davinci,
                prompt: $"Write a summary of {bookName}.",
                maxTokens: 60,
                n: 1,
                stop: new List<string> { "\n" }
            );

            return completions.Choices[0].Text.Trim();
        }

        public async Task<string> GenerateSummary(string bookName)
        {
            var client = new OpenAIApi(API_KEY_HERE);
            var completions = await client.Completions.CreateCompletionAsync(
                engine: Engine.Davinci,
                prompt: $"Write a summary of {bookName}.",
                maxTokens: 60,
                n: 1,
                stop: new List<string> { "\n" }
            );

            return completions.Choices[0].Text.Trim();
        }
    }
}
