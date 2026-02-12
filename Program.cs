using Microsoft.SemanticKernel;
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel.Connectors.OpenAI;

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

builder.Plugins.AddFromType<TimeInformationPlugin>();

var kernel = builder.Build();

OpenAIPromptExecutionSettings settings = new()
{
    ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
};

var result = await kernel.InvokePromptAsync(
    "現在幾點了？請包含今天的日期。", 
    new(settings)
);
Console.WriteLine($"AI 回覆：{result}");