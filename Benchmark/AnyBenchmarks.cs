using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmark;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
public class AnyBenchmarks
{
    [Params(10,100,1000)]
    public static int listCount;

    private List<int> list = Enumerable.Range(0, listCount).ToList();
    
    [Benchmark]
    public bool CheckListWithAny()
    {
        return list.Any(x=>x == listCount/2);
    }    
    
    [Benchmark]
    public bool CheckListWithCount()
    {
        return list.Count(x=>x == listCount/2) > 0;
    }
}