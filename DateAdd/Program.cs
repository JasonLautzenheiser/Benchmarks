using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<DateAddBenchmarks>();

// var obj = new DateAddBenchmarks();
// Console.WriteLine(obj.AddThenSubtract());
// Console.WriteLine(obj.AddTimeSpan());
