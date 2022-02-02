using BenchmarkDotNet.Attributes;

namespace DateAdd;

[MemoryDiagnoser]
public class DateAddBenchmarks
{
    [Benchmark]
    public DateTime AddThenSubstract()
    {
        DateTime endDate = new DateTime(2022,2,2,0,0,0);
        endDate = endDate.AddDays(1);
        endDate = endDate.AddSeconds(-1);
        return endDate;
    }
    
    [Benchmark]
    public DateTime AddTimeSpan()
    {
        DateTime endDate = new DateTime(2022,2,2,0,0,0);
        endDate = endDate.Add(new TimeSpan(1,0,0,-1));
        return endDate;
    }
}