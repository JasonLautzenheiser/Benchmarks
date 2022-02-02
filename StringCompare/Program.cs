// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using StringCompare;

var obj = new StringCompareBenchMark();
var summary = BenchmarkRunner.Run<StringCompareBenchMark>();