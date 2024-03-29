﻿using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmark
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net70)]
    public class StringFormatBenchmarks
    {
        private string firstname = "jason";
        private string lastname = "lautzenheiser";
        
        [Benchmark]
        public string StringFormat()
        {
            return string.Format("{0} {1}", firstname, lastname);
        }

        [Benchmark]
        public string StringInterpolation()
        {
            return $"{firstname} {lastname}";
        }

        [Benchmark]
        public string StringConcat()
        {
            return string.Concat(firstname, " ", lastname);
        }

        [Benchmark]
        public string StringConcatExplicit()
        {
            return firstname + " " + lastname;
        }

        
        [Benchmark]
        public string StringBuilder()
        {
            var sb = new StringBuilder();
            sb.Append(firstname);
            sb.Append(lastname);
            return sb.ToString();
        }

        
    }
}