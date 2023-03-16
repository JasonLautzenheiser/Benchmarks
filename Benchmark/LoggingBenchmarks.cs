using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Serilog;
using Serilog.Events;

namespace Benchmark;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
public class LoggingBenchmarks
{
  string firstName = "Jason";  
  
  
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

    [Benchmark]
    public void MessageCompileTypeConstant()
    {
      Log.Verbose("This is a test {firstName}", firstName);
    }

    [Benchmark]
    public void MessageInterpolation()
    {
      Log.Verbose($"This is a test {firstName}");
    }
}