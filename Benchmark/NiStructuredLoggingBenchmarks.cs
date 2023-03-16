using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using NI.Logging.Structured;
using Serilog;
using Serilog.Events;

namespace Benchmark;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net60)]
// [SimpleJob(RuntimeMoniker.Net70)]
public class NiStructuredLoggingBenchmarks
{

  IStructuredLogger structuredLogger;
  [GlobalSetup]
  public void Setup()
  {
    Log.Logger = new LoggerConfiguration()
      .MinimumLevel.Information()
      .WriteTo.Console().CreateLogger();

    structuredLogger = new SerilogStructuredLogger(Log.Logger);
  }
  
  
  [Benchmark]
  public void BaseLogging()
  {
    Log.Verbose("No one listens to me!");
  }

  [Benchmark]
  public void NIBaseLogging()
  {
    structuredLogger.Log(LogLevel.Verbose, "No one listens to me!");
  }

  [Benchmark]
  public void NIProposedLogging()
  {
    Log.Write(LogEventLevel.Verbose, "No one listens to me!");
  }
  

  [Benchmark]
  public void NIProposedLogging_EnumParse()
  {
    Log.Write(ToSerilogLevelParse(LogLevel.Verbose), "No one listens to me!");
  }

  private LogEventLevel ToSerilogLevelParse(LogLevel logLevel) => (LogEventLevel)Enum.Parse(typeof(LogEventLevel), logLevel.ToString());
}