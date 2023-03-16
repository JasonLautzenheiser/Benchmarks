using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmark;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
public class DateAddBenchmarks
{
    private DateTime endDate;
    
    // [GlobalSetup]
    // public void Setup()
    // {
    //     endDate = new DateTime(2022,2,2,0,0,0);
    // }
    
    [Benchmark]
    public DateTime AddThenSubtract()
    {
        DateTime myDate = new DateTime(2022,2,2,0,0,0);;
        myDate = myDate.AddDays(1);
        myDate = myDate.AddSeconds(-1);
        return myDate;
    }
    
    [Benchmark]
    public DateTime AddTimeSpan()
    {
        DateTime myDate = new DateTime(2022,2,2,0,0,0);;
        myDate = myDate.Add(new TimeSpan(1,0,0,-1));
        return myDate;
    }
}