
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using OpenAI.API;
using OpenAI.API.Files;
using OpenAI.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace _521Final.Models
{
    public class ChatGPTClient
    {
        private const string API_KEY = "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"; // Replace with your OpenAI API key

        public static async Task<string> GenerateSummary(string bookName)
        {
            var client = new OpenAIAPI(API_KEY);
            var completions = await client.Completions.CreateCompletionAsync(
                model: Model.DavinciCode,
                prompt: $"Write a summary of {bookName}.",
                max_tokens: 60,
                temperature: .7,
                numOutputs: 1,
                stopSequences: new string[] { "\n" }
            );

           return completions.OpenaiVersion[0].ToString();
           //return completions.Choices[0].Text.Trim();
        }

    }
}
