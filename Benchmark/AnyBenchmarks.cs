using BenchmarkDotNet.Attributes;

namespace Benchmark;

[MemoryDiagnoser]
public class AnyBenchmarks
{
    [Params(0,10,1000)]
    public static int listCount;
    private List<string> list = new List<string>(listCount);

    [Benchmark]
    public bool CheckListWithAny()
    {
        return list.Any();
    }    
    
    [Benchmark]
    public bool CheckListWithCount()
    {
        return list.Count > 0;
    }
}