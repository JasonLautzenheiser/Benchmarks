﻿using BenchmarkDotNet.Running;
using Enums;

class Program
{
    public static  void Main()
    {
        var summary = BenchmarkRunner.Run<EnumBenchmarks>();

// var logger = new LoggingBenchmarks();
// logger.BaseLogging();
    }
}