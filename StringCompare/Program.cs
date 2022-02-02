// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using StringCompare;

var summary = BenchmarkRunner.Run<StringCompareBenchMark>();