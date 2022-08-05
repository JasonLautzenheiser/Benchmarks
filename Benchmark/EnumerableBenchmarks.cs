using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmark;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net60)]
public class EnumerableBenchmarks
{


  [Benchmark]
  public void PassAPredicateNullAssigning()
  {
    IEnumerable<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    list.IsNullOrEmpty1<int>(p=>p == 2);
  }

  [Benchmark]
  public void PassAPredicateCheckForNull()
  {
    IEnumerable<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    list.IsNullOrEmpty2<int>(p=>p == 2);
  }

  
  [Benchmark]
  public void AssignNullPredicateToTrue()
  {
    IEnumerable<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    list.IsNullOrEmpty1<int>();
  }

  [Benchmark]
  public void IgnoreNullPredicate()
  {
    IEnumerable<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    list.IsNullOrEmpty2<int>();
  }

}

public static class EnumerableExtensions
{
  public static bool IsNullOrEmpty1<ItemType>(this IEnumerable<ItemType>? enumerable,
    Func<ItemType, bool>? predicate = null)
  {
    predicate ??= (i) => true;
    return enumerable == null || !enumerable.Any(predicate);

    // if (enumerable == null) return true;
    // return predicate == null
    //   ? !enumerable.Any()
    //   : !enumerable.Any(predicate);
  }

  public static bool IsNullOrEmpty2<ItemType>(this IEnumerable<ItemType>? enumerable,
    Func<ItemType, bool>? predicate = null)
  {
    if (enumerable == null) return true;
    return predicate == null
      ? !enumerable.Any()
      : !enumerable.Any(predicate);
  }
} 
  