using BenchmarkDotNet.Running;
using Strings;

class Program
{
    public static  void Main()
    {
        var summary = BenchmarkRunner.Run<StringFormatBenchmarks>();

// var logger = new LoggingBenchmarks();
// logger.BaseLogging();
    }
}