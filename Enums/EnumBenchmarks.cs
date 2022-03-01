using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Enums
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net461)]
    [SimpleJob(RuntimeMoniker.Net60)]
    public class EnumBenchmarks
    {
        
    }
}