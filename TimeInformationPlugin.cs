using System.ComponentModel;
using Microsoft.SemanticKernel;

public class TimeInformationPlugin
{
    [KernelFunction]
    [Description("提供當前的日期和時間資訊。")]
    public string GetCurrentTime()
    {
        return $"現在的日期和時間是：{DateTime.Now}";
    }
}