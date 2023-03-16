using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmark;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
public class StringCompareBenchMark
{
    const string baseString = "jason";
    private const string upperString = "JASON";

    [Benchmark(Baseline = true)]
    public bool CompareStrings_ToUpper()
    {
        return baseString.ToUpper() == upperString;
    }

    [Benchmark]
    public bool CompareStrings_Equals_IgnoreCase() =>
        baseString.Equals(upperString, StringComparison.OrdinalIgnoreCase);

    [Benchmark]
    public bool CompareStrings_StringEquals_IgnoreCase() =>
        String.Equals(baseString, upperString, StringComparison.OrdinalIgnoreCase);

    [Benchmark]
    public bool CompareStrings_StringCompare_IgnoreCase() =>
        String.Compare(baseString, upperString, comparisonType: StringComparison.OrdinalIgnoreCase) == 0;
        
    [Benchmark]
    public bool CompareStrings_StringComparer_InvariantCultureIgnoreCase() =>
        StringComparer.InvariantCultureIgnoreCase.Compare(baseString, upperString) == 0;
 
    [Benchmark]
    public bool CompareStrings_StringComparer_OrdinalIgnoreCase() =>
        StringComparer.OrdinalIgnoreCase.Compare(baseString, upperString) == 0;

}