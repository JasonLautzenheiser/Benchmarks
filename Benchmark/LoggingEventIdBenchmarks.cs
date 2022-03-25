using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Benchmark;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net60)]
public class LoggingEventIdBenchmarks
{

    private static Microsoft.Extensions.Logging.ILogger _logger;
    private static Serilog.ILogger _loggerSerilog;

    [GlobalSetup]
    public void Setup()
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .CreateLogger();
        
        _logger = LoggerFactory.Create(builder => { }).CreateLogger<Program>();
        _loggerSerilog = Log.Logger;
    }

    [Benchmark]
    public void BaseLogging_NoId_Microsoft()
    {

        _logger.LogWarning("No one listens to me!");
    }

    [Benchmark]
    public void LogID_ImplicitConversion_Microsoft()
    {
        _logger.LogWarning(1, "No one listens to me!");

    }

    [Benchmark]
    public void LogID_NewEventId_Microsoft()
    {
        _logger.LogWarning(new EventId(1), "No one listens to me!");

    }

    [Benchmark]
    public void LogID_NewEventIdAndName_Microsoft()
    {
        _logger.LogWarning(new EventId(1, "Name"), "No one listens to me!");

    }    
    
    [Benchmark]
    public void BaseLogging_NoId_SeriLog()
    {

        _loggerSerilog.Warning("No one listens to me!");
    }

    [Benchmark]
    public void LogID_ImplicitConversion_SeriLog()
    {
        _loggerSerilog.Warning("No one listens to me!");

    }

    [Benchmark]
    public void LogID_NewEventId_SeriLog()
    {
        _loggerSerilog.Warning("No one listens to me!");

    }

    [Benchmark]
    public void LogID_NewEventIdAndName_SeriLog()
    {
        _loggerSerilog.Warning("No one listens to me!");

    }
}
