using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmark;

[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
public class SealedClass
{
  private SealedType _sealed = new();
  private NonSealedType _nonSealed = new();

  [Benchmark]
  public int NonSealedMethodCall() => _nonSealed.M() + 42;
10
  [Benchmark]
  public int SealedMethodCall() => _sealed.M() + 42;
  
  [Benchmark]
  public bool NonSealedTypeCheck() => _o is NonSealedType;

  [Benchmark]
  public bool SealedTypeCheck() => _o is SealedType;

  public class BaseType
  {
    public virtual int M() => 1;
  }

  public class NonSealedType : BaseType
  {
    public override int M() => 2;
  }

  public sealed class SealedType : BaseType
  {
    public override int M() => 2;
  }
  
  private object _o = "hello";
}