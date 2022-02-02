using BenchmarkDotNet.Running;
using DateAdd;

var summary = BenchmarkRunner.Run<DateAddBenchmarks>();