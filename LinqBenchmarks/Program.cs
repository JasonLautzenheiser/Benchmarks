// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using LinqBenchmarks;

var summary = BenchmarkRunner.Run<AnyBenchmarks>();