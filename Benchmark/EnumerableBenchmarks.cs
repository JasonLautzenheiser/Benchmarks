using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmark;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
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

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
public class EnumerableDuplicatesBenchmarks
{
  [Benchmark]
  [ArgumentsSource(nameof(Data))]
  public void Duplicates_AddHashsetCheck_Foreach(int[] array)
  {
    ContainsDuplicates1<int>(array);
  }  
  
  [Benchmark]
  [ArgumentsSource(nameof(Data))]
  public void Duplicates_AddHashsetCheck_Linq(int[] array)
  {
    ContainsDuplicates2<int>(array);
  }
  
  [Benchmark]
  [ArgumentsSource(nameof(Data))]
  public void Duplicates_AddHashsetCheck_enumerable_all(int[] array)
  {
    var hs = new HashSet<int>();
    array.All(hs.Add);
  }

  private static bool ContainsDuplicates1<T>(IEnumerable<T> enumerable)
  {
    HashSet<T> knownElements = new();
    foreach (T element in enumerable)
    {
      if (!knownElements.Add(element)) return true;
    }

    return false;
  }  
  
  private static bool ContainsDuplicates2<T>(IEnumerable<T> enumerable)
  {
    HashSet<T> knownElements = new();
    return enumerable.Any(element => !knownElements.Add(element));
  }
  
  public IEnumerable<int[]> Data()
  {
    // yield return new int[] { 1, 2, 2, 3 };
    
    var array = Enumerable.Range(0, 1000).ToArray();
    // array[500] = 1;
    yield return array;

    // var array2 = Enumerable.Range(0, 1000).ToArray();
    // array[3] = 1;
    //
    // yield return array;
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
  