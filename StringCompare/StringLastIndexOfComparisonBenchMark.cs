using BenchmarkDotNet.Attributes;

namespace StringCompare;

[MemoryDiagnoser]
public class StringLastIndexOfComparisonBenchMark
{
    const string baseString = "jason";
    private const string upperString = "JASON";

    [Benchmark]
    public int LastIndexOfCompare() => baseString.LastIndexOf("s");
 
    [Benchmark]
    public int LastIndexOfCompare_Ordinal() => baseString.LastIndexOf("s", StringComparison.Ordinal);

    [Benchmark]
    public int LastIndexOfCompare_OrdinalIgnoreCase() => baseString.LastIndexOf("s", StringComparison.OrdinalIgnoreCase);
}