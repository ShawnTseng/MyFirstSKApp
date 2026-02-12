using Microsoft.SemanticKernel;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

string githubPat = config["AI_API_KEY"]!;
string modelId = config["AI_MODEL_ID"]!;

var builder = Kernel.CreateBuilder();

builder.AddOpenAIChatCompletion(
    modelId: modelId,
    apiKey: githubPat,
    endpoint: new Uri("https://models.github.ai/inference")
);

var kernel = builder.Build();

Console.WriteLine("正在連線到 GitHub Models...");
var result = await kernel.InvokePromptAsync("請用一句話介紹你自己，並確認你已連接成功。");
Console.WriteLine($"\nAI 回覆：{result}");