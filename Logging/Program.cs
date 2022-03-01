using BenchmarkDotNet.Running;

class Program
{
    public static  void Main()
    {
        var summary = BenchmarkRunner.Run<LoggingBenchmarks>();

// var logger = new LoggingBenchmarks();
// logger.BaseLogging();
    }
}