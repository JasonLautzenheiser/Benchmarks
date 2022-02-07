using BenchmarkDotNet.Running;
using StringCompare;

var summary = BenchmarkRunner.Run<StringCompareBenchMark>();

// var xx = new StringCompareBenchMark();
// Console.WriteLine(xx.CompareStrings_ToUpper());
// Console.WriteLine(xx.CompareStrings_Equals_IgnoreCase());
// Console.WriteLine(xx.CompareStrings_StringCompare_IgnoreCase());
// Console.WriteLine(xx.CompareStrings_StringEquals_IgnoreCase());
// Console.WriteLine(xx.CompareStrings_StringComparer_OrdinalIgnoreCase());
