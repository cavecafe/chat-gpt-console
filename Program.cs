using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace ChatGPT
{
    class Program
    {
        private const string APPSETTING_FILE = "appsettings.json";

        static async Task Main(string[] args)
        {
            if (!File.Exists(APPSETTING_FILE))
            {
                PutAnswer("Please get & enter your API key from OpenAPI.org");
                var enteredKey = GetQuestion();
                File.WriteAllText(APPSETTING_FILE, "{\n  \"OpenAI\": {\n    \"ApiKey\": \"" + enteredKey + "\",\n    \"Model\": \"text-davinci-003\",\n    \"EndPoint\": \"https://api.openai.com/v1/completions\"\n  }\n}");
                PutAnswer("Ok, I'll try to use the key.");
            }

            var appsettings = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(APPSETTING_FILE, optional: true, reloadOnChange: true)
                .Build();

            var section = appsettings.GetSection("OpenAI");
            var children = section.GetChildren();
            Dictionary<string, string> config = children.ToDictionary(x => x.Key, x => x.Value)!;

            string apiKey = config["ApiKey"];
            string model = config["Model"];
            string endPoint = config["EndPoint"];

            PutAnswer(String.Format("\n\nWelcome to ChatGPT.\nI'm model '{0}'\n\n", model));

            while (true)
            {
                string question = GetQuestion();
                if (string.IsNullOrWhiteSpace(question))
                {
                    PutAnswer("Tell me something, or type 'bye' to exit");
                }
                else if (question.ToLower().Equals("bye"))
                {
                    PutAnswer("Bye!");
                    break;
                }
                else
                {
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
                        var body = new
                        {
                            prompt = question,
                            model = model,
                            temperature = 0.5,
                            max_tokens = 1000
                        };

                        using (var response = await client.PostAsync(endPoint,
                            new StringContent(JsonSerializer.Serialize(body),
                            Encoding.UTF8, "application/json")))
                        {
                            using (Stream stream = await response.Content.ReadAsStreamAsync())
                            {
                                using (var reader = new StreamReader(stream))
                                {
                                    var result = await reader.ReadToEndAsync();
                                    var res = JsonSerializer.Deserialize<Response>(result);

                                    if (res!.choices.Count > 0)
                                    {
                                        foreach (var c in res!.choices)
                                        {
                                            PutAnswer(c.text);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void PutAnswer(string text, bool indent = false)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (text.StartsWith("\n\n"))
            {
                text = text.Substring(1, text.Length - 1);
            }

            var lines = text.Split("\n");
            foreach(var line in lines)
            {
                Console.WriteLine(indent ? line.PadLeft(1,'|') : line);
            }
            Console.WriteLine();
        }

        private static string GetQuestion()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            return Console.ReadLine()!;
        }
    }
}
