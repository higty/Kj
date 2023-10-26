using Azure.AI.OpenAI;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatGPTApp
{
    internal class Program
    {
        public static string ApiKey = File.ReadAllText("C:\\Dev\\ChatGPTApiKey.txt");
        public static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        static async Task Main(string[] args)
        {
            var functionList = new List<FunctionDefinition>();

            Console.WriteLine("Function callingを使う場合はYを入力してEnterキーを押してください。");
            if (string.Equals(Console.ReadLine(), "Y", StringComparison.OrdinalIgnoreCase))
            {
                functionList.Add(CreateFunction());
                Console.WriteLine("Functionを追加しました。");
            }

            while (true)
            {
                Console.WriteLine("Please input prompt.");
                Console.WriteLine();

                var line = Console.ReadLine();
                if (string.Equals(line, "Exit", StringComparison.OrdinalIgnoreCase)) { return; }

                if (string.IsNullOrEmpty(line)) { continue; }
                await Execute(line, functionList);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        private static async Task Execute(string text)
        {
            await Execute(text, Array.Empty<FunctionDefinition>());
        }
        private static async Task Execute(string text, IEnumerable<FunctionDefinition> functionList)
        {
            using (var tokenSource = new CancellationTokenSource())
            {
                tokenSource.CancelAfter(TimeSpan.FromMinutes(3));

                var options = new ChatCompletionsOptions();
                options.User = "Kj_User01";
                options.Messages.Add(new ChatMessage(ChatRole.System, "あなたは優秀なアドバイザーです。"));
                options.Messages.Add(new ChatMessage(ChatRole.User, text));
                options.Temperature = 1.0f;

                foreach (var function in functionList)
                {
                    options.Functions.Add(function);
                }

                var cl = new OpenAIClient(ApiKey);
                if (false)
                {
                    cl = new OpenAIClient(new Uri("https://xxx.openai.azure.com/"), new Azure.AzureKeyCredential(ApiKey));
                }

                var modelName = "gpt-3.5-turbo-0613";
                //modelName = "gpt-4";
                var results = await cl.GetChatCompletionsStreamingAsync(modelName, options, tokenSource.Token);

                var functionName = "";
                var arguments = new StringBuilder();
                await foreach (var choice in results.Value.GetChoicesStreaming(tokenSource.Token))
                {
                    await foreach (var msg in choice.GetMessageStreaming())
                    {
                        if (msg.FunctionCall == null)
                        {
                            Console.Write(msg.Content);
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(msg.FunctionCall.Name) == false)
                            {
                                functionName = msg.FunctionCall.Name;
                            }
                            arguments.Append(msg.FunctionCall.Arguments);
                        }
                    }
                }

                if (functionName != "")
                {
                    Console.WriteLine("Function callingが選択されました。");
                    Console.WriteLine($"Function Name: {functionName}");
                    Console.WriteLine($"Arguments: {arguments}");
                }
            }
        }
        private static FunctionDefinition CreateFunction()
        {
            var f = new FunctionDefinition("ParagraphList");
            f.Description = "Create text from paragraph list.";
            f.Parameters = BinaryData.FromObjectAsJson(new
            {
                type = "object",
                properties = new
                {
                    paragraphList = new
                    {
                        type = "array",
                        description = "Paragraph list as array.",
                        items = new
                        {
                            type = "object",
                            properties = new
                            {
                                title = new { Type = "string", description = "Title of paragraph" },
                                subTitleList = new
                                {
                                    type = "array",
                                    description = "Subtitle of paragraph",
                                    items = new
                                    {
                                        type = "string"
                                    }
                                },
                            }
                        }
                    }
                },
            }, JsonSerializerOptions);
            return f;
        }

    }
}