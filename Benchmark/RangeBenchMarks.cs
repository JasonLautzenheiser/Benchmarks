using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using NI.Tools.Ranges;
#if NET6_0_OR_GREATER
#endif

namespace Benchmark;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
public class RangeBenchMarks
{
#if NET6_0_OR_GREATER
  [Benchmark]
  public bool CheckListWithAny()
  {
    int count = 10;
    var xx = (0..count).ToEnumerable();
    return xx.Any();
  }    
#endif    

#if !NET6_0_OR_GREATER
  [Benchmark]
  public bool CheckListWithAny()
  {
    int count = 10;
    var xx = (0..count).ToEnumerable();
    return xx.Any();
  }
#endif
}