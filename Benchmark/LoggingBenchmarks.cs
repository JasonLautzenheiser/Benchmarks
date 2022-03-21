using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Serilog;
using Serilog.Events;

namespace Benchmark;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net461)]
[SimpleJob(RuntimeMoniker.Net60)]
public class LoggingBenchmarks
{
    
    [GlobalSetup]
    public void Setup()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console().CreateLogger();    }
    
    [Benchmark]
    public void BaseLogging()
    {

        Log.Verbose("No one listens to me!");
    }

    [Benchmark]
    public void CheckForMinLevelBeforeLogging()
    {
        if (Log.IsEnabled(LogEventLevel.Verbose))
            Log.Verbose("No one listens to me!");
        
    }
}