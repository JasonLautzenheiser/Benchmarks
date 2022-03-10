using BenchmarkDotNet.Running;
using Strings;

class Program
{
    public static  void Main()
    {
        // var summary = BenchmarkRunner.Run<StringFormatBenchmarks>();
        var summary = BenchmarkRunner.Run<StringBoxing>();

    }
}