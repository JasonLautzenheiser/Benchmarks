using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmark;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
public class IfvsSwitchBenchmarks
{
    private string[] args;

    [GlobalSetup]
    public void Setup()
    {
        args = new[] { "arg1", "arg2", "arg2" };
    }

    [Benchmark]
    public bool IfStatement()
    {
        if (args.Length > 0)
            return true;
        else
            return false;
    }
    
    [Benchmark]
    public bool SwitchExpression()
    {
        return args.Length switch
        {
            > 0 => true,
            _ => false
        };
    }
    
    [Benchmark]
    public bool SwitchStatement()
    {
        switch (args.Length)
        {
            case > 0:
                return true;
            default:
                return false;
        }
    }

    [Benchmark]
    public bool SwitchObjectArguments()
    {
        switch (args)
        {
            case { Length: > 0 }:
                return true;
            default:
                return false;
        }
    }


}
