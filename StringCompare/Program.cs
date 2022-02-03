using BenchmarkDotNet.Running;
using StringCompare;

var summary = BenchmarkRunner.Run<StringCompareBenchMark>();