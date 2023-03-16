using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmark
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net70)]
    public class StringBoxing
    {
        private const int numC = 5;
        private const string strC = "test";

        private const int num2C = 5;
        private const string str2C = "test";
        private const string str3C = "test";
        private const string str4C = "test";

        private readonly int numRO = 5;
        private readonly string strRO = "test";

        private readonly int num2RO = 5;
        private readonly string str2RO = "test";
        private readonly string str3RO = "test";
        private readonly string str4RO = "test";

        [Benchmark]
        public string IntBoxingConstant() => $"Some {numC} thing {strC}";
        [Benchmark]
        public string IntToStringConstant() => $"Some {numC.ToString()} thing {strC}";        
        [Benchmark]
        public string IntBoxingReadOnly() => $"Some {numRO} thing {strRO}";
        [Benchmark]
        public string IntToStringReadOnly() => $"Some {numRO.ToString()} thing {strRO}";

        [Benchmark]
        public string IntBoxingMoreArgsConstant() => $"Some {numC} thing {strC} {num2C} {str2C} {str3C} {str4C}";
        [Benchmark]
        public string IntToStringMoreArgsConstant() => $"Some {numC.ToString()} thing {strC} {num2C.ToString()} {str2C} {str3C} {str4C}";
        [Benchmark]
        public string IntBoxingMoreArgsReadOnly() => $"Some {numRO} thing {strRO} {num2RO} {str2RO} {str3RO} {str4RO}";
        [Benchmark]
        public string IntToStringMoreArgsReadOnly() => $"Some {numRO.ToString()} thing {strRO} {num2RO.ToString()} {str2RO} {str3RO} {str4RO}";
    }
}