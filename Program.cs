using System.Drawing;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace ChatGPT
{
    class Program
    {
        private const string APPSETTING_FILE = "appsettings.json";
        private static ConsoleColor questionColor = Console.ForegroundColor;
        private static ConsoleColor answerColor = ConsoleColor.DarkBlue;

        static async Task Main(string[] args)
        {
            Console.ForegroundColor = GetInvertedKnownColor(Console.BackgroundColor);

            if (!File.Exists(APPSETTING_FILE))
            {
                PutAnswer("Please get & enter your API key from OpenAPI.org");
                var enteredKey = GetQuestion();
                File.WriteAllText(APPSETTING_FILE, "{\n  \"OpenAI\": {\n    \"ApiKey\": \"" + enteredKey + "\",\n    \"Model\": \"text-davinci-003\",\n    \"EndPoint\": \"https://api.openai.com/v1/completions\"\n  }\n}");
                PutAnswer("Ok, I'll try to use the key.");
            }

            var appsettings = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(APPSETTING_FILE, optional: true, reloadOnChange: false)
                .Build();

            var section = appsettings.GetSection("OpenAI");
            var children = section.GetChildren();
            Dictionary<string, string> config = children.ToDictionary(x => x.Key, x => x.Value)!;

            string apiKey = config["ApiKey"];
            string model = config["Model"];
            string endPoint = config["EndPoint"];

            PutAnswer(String.Format("\n\nChatGPT Terminal\n  model:'{0}'\n  end-point:'{1}'\n", model, endPoint));

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

                                    if (res!.choices!.Count > 0)
                                    {
                                        foreach (var c in res!.choices)
                                        {
                                            PutAnswer(c.text!);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        private static Dictionary<ConsoleColor, int[]> colorMap = new Dictionary<ConsoleColor, int[]>
        {
            { ConsoleColor.Black, new int[] { 0, 0, 0 } },
            { ConsoleColor.DarkBlue, new int[] { 0, 0, 170 } },
            { ConsoleColor.DarkGreen, new int[] { 0, 170, 0 } },
            { ConsoleColor.DarkCyan, new int[] { 0, 170, 170 } },
            { ConsoleColor.DarkRed, new int[] { 170, 0, 0 } },
            { ConsoleColor.DarkMagenta, new int[] { 170, 0, 170 } },
            { ConsoleColor.DarkYellow, new int[] { 170, 170, 0 } },
            { ConsoleColor.Gray, new int[] { 170, 170, 170 } },
            { ConsoleColor.DarkGray, new int[] { 85, 85, 85 } },
            { ConsoleColor.Blue, new int[] { 85, 85, 255 } },
            { ConsoleColor.Green, new int[] { 85, 255, 85 } },
            { ConsoleColor.Cyan, new int[] { 85, 255, 255 } },
            { ConsoleColor.Red, new int[] { 255, 85, 85 } },
            { ConsoleColor.Magenta, new int[] { 255, 85, 255 } },
            { ConsoleColor.Yellow, new int[] { 255, 255, 85 } },
            { ConsoleColor.White, new int[] { 255, 255, 255 } }
        };


        private static ConsoleColor GetInvertedKnownColor(ConsoleColor consoleColor)
        {
            Color color = Color.FromName(consoleColor.ToString());
            int[] colorRGB = new int[] { color.R, color.G, color.B };
            ConsoleColor invertedColor = ConsoleColor.Gray;
            int maxDistance = 0;
            
            foreach (var c in colorMap)
            {
                int distance = c.Value.Zip(colorRGB, (x, y) => Math.Abs(x - y)).Sum();

                if (distance > maxDistance)
                {
                    invertedColor = c.Key;
                    maxDistance = distance;
                }
            }

            return invertedColor;
        }

        private static void PutAnswer(string text, bool indent = false)
        {
            Console.ForegroundColor = answerColor;

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
            Console.ForegroundColor = questionColor;

            return Console.ReadLine()!;
        }
 
    }
}
