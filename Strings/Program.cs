using BenchmarkDotNet.Running;

class Program
{
    public static  void Main()
    {
        // var summary = BenchmarkRunner.Run<StringFormatBenchmarks>();
        var summary = BenchmarkRunner.Run<StringBoxing>();

    }
}