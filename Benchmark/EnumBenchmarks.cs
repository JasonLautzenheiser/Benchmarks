using System.ComponentModel;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using NetEscapades.EnumGenerators;
// ReSharper disable MemberCanBePrivate.Global

namespace Benchmark
{
    [MemoryDiagnoser]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [SimpleJob(RuntimeMoniker.Net60)]
    public class EnumBenchmarks
    {
        [Params("Support", "Data Entry", "Implementation", "NotFound")]
        public static string findThis;
        
        [Params(TicketTypes.Implementation, TicketTypes.DataEntry, TicketTypes.Support)]
        public static TicketTypes2 typeToGetName;
        

        [Benchmark]
        public TicketTypes? GetEnumByDescription_Reflection()
        {
            return GetEnumFromDescription<TicketTypes>(findThis);
        }

        [Benchmark]
        public TicketTypes? GetEnumByDescription_CodeGenerator()
        {
            return TicketTypesHelper.GetEnumFromDescriptionFast(findThis);
        }

        [Benchmark]
        public string? GetStringNameFromEnum_ToString()
        {
            return typeToGetName.ToString();
        }


        [Benchmark]
        public string? GetStringNameFromEnum_ToStringFast()
        {
            return typeToGetName.ToStringFast();
        }

        
        private static TEnum? GetEnumFromDescription<TEnum>(string description)
        {
            var enumType = typeof(TEnum);
            foreach (var field in enumType.GetFields())
            {
                DescriptionAttribute attribute
                    = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))as DescriptionAttribute;
                if(attribute == null)
                    continue;
                if(attribute.Description == description)
                {
                    return (TEnum) field.GetValue(null);
                }
            }
            return default;
        }
    }

    [GenerateHelper(GenerateHelperOption.UseItselfWhenNoDescription)]
    public enum TicketTypes
    {
        [Description("Support")]
        Support,
        [Description("Training")]
        Training,
        [Description("Implementation")]
        Implementation,
        [Description("Data Entry")]
        DataEntry
    }
    
    [EnumExtensions]
    public enum TicketTypes2
    {
        [Description("Support")]
        Support,
        [Description("Training")]
        Training,
        [Description("Implementation")]
        Implementation,
        [Description("Data Entry")]
        DataEntry
    }
    
}