﻿using BenchmarkDotNet.Attributes;

namespace StringCompare;

[MemoryDiagnoser]
public class StringCompareBenchMark
{
    const string baseString = "jason";
    private const string upperString = "JASON";

    [Benchmark]
    public bool CompareStrings_ToUpper()
    {
        return baseString.ToUpper() == upperString;
    }

    [Benchmark]
    public bool CompareStrings_Equals_IgnoreCase() =>
        baseString.Equals(upperString, StringComparison.OrdinalIgnoreCase);

    [Benchmark]
    public bool CompareStrings_StringEquals_IgnoreCase() =>
        String.Equals(baseString, upperString, StringComparison.OrdinalIgnoreCase);

    [Benchmark]
    public int CompareStrings_StringCompare_IgnoreCase() =>
        String.Compare(baseString, upperString, comparisonType: StringComparison.OrdinalIgnoreCase);

    
}