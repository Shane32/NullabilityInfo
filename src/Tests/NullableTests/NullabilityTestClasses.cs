#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL.DataLoader;

namespace NullableTests
{
    public class NullableClass1
    {
        public static string? Field1() => "field1";
        [Required]
        public static string? Field2() => "field2";
        public static int Field3() => 1;
        [Optional]
        public static int Field4() => 1;
        public static int? Field5() => 1;
        [Required]
        public static int? Field6() => 1;
        public static string Field7() => "field1";
        [Optional]
        public static string Field8() => "field2";
        [Id]
        public static string Field9() => "field9";
        [OptionalList]
        public static List<string> Field10() => null!;
    }

    public class NullableClass2
    {
        public static string? Field1() => "field1";
        [Required]
        public static string? Field2() => "field2";
        public static int Field3() => 1;
        [Optional]
        public static int Field4() => 1;
        public static int? Field5() => 1;
        [Required]
        public static int? Field6() => 1;
        public static string? Field7() => "test";
        public static string? Field8() => "test";
        public static string Field9() => "field1";
        [Optional]
        public static string Field10() => "field2";
        [RequiredList]
        public static List<string?>? Field11() => null!;
    }

    public class NullableClass5
    {
        public static string Test() => "test";
    }

    public class NullableClass6
    {
        public static string Field1() => "test";
        public static string? Field2() => "test";
    }

    public class NullableClass7
    {
        public static string Field1() => "test";
        public static string Field2() => "test";
        public static string? Field3() => "test";
    }

    public class NullableClass8
    {
        public static string? Field1() => "test";
        public static string? Field2() => "test";
        public static string Field3() => "test";
        public static int Field4() => 3;
    }

    public class NullableClass9
    {
        public static string Field1(string? arg1, string? arg2) => "test";
    }

    public class NullableClass10
    {
        public static string? Field1(string arg1, string arg2) => "test";
    }

    public class NullableClass11
    {
        public static string Field1() => "test";
        public static string? Field2(string arg1, string arg2) => "test";
    }

    public class NullableClass12
    {
        public static IDataLoaderResult<string> Field1() => null!;
        public static IDataLoaderResult<string?> Field2() => null!;
        public static IDataLoaderResult<string>? Field3() => null!;
        public static IDataLoaderResult<string?>? Field4() => null!;
    }

    public class NullableClass13
    {
        public static string Field1() => "test";
        public static string Field2(string arg1, string? arg2, int arg3, int? arg4, [Optional] string arg5, IEnumerable<string> arg6, IEnumerable<string?> arg7, IEnumerable<string>? arg8, IEnumerable<string?>? arg9) => "test";
    }

    public class NullableClass14
    {
        public static string? Field1() => "test";
        public static string? Field2(string? arg1, string arg2, int arg3, int? arg4, [Required] string? arg5, IEnumerable<string> arg6, IEnumerable<string?> arg7, IEnumerable<string>? arg8, IEnumerable<string?>? arg9) => "test";
    }

    public class NullableClass15
    {
        public static Task<string> Field1() => null!;
        public static Task<string?> Field2() => null!;
        public static Task<string>? Field3() => null!;
        public static Task<string?>? Field4() => null!;
    }

    public class NullableClass16
    {
        public static string Field1() => "test";
        public static string Field2() => "test";
        public static string? Field3() => "test";

        public class NestedClass1
        {
            public static string Field1() => "test";
            public static string Field2() => "test";
            public static string? Field3() => "test";
        }
    }

    public class NullableClass17
    {
        public static Task<string> Field1() => null!;
        public static Task<string> Field2() => null!;
        public static Task<string?> Field3() => null!;
    }

    public class NullableClass18<T>
    {
        //reference type
        public static Tuple<string, string?> Field1() => null!;
        //check ordering of nested types
        public static Tuple<Tuple<string?, string?>, string> Field2() => null!;
        //nullable value type
        public static Tuple<int?, string?> Field3() => null!;
        //non-generic value type
        public static Tuple<Guid, string?> Field4() => null!;
        //array
        public static Tuple<string[], string?> Field5() => null!;
        public static Tuple<int[], string?> Field6() => null!;
        //value tuple
        public static Tuple<(int, string), string?> Field7() => null!;
        public static Tuple<ValueTuple<int, string>, string?> Field8() => null!;
        //generic value type
        public static Tuple<TestStruct<Guid>, string?> Field9() => null!;
        //type reference
        public static Tuple<T, string?> Field10() => null!;
    }

    public class Class1 { }

    public class Parent1<M, N>
        where M: notnull
        //N = unknown
    {
        public class Complex2 : Complex1<
            NullableClass18<string>, //non-null
            NullableClass18<string>, //non-null
            NullableClass18<string>?, //nullable
            Class1, //non-null
            Class1, //non-null
            Class1?, //nullable
            Tuple<int, int>, //non-null
            Guid, //non-null
            string, //non-null
            string?, //nullable
            M, //non-null
            N> //unknown
        {

        }

        public class Complex1<A, B, C, D, E, F, G, H, I, J, K, L>
            where A : NullableClass18<string> //non-null
            where B : NullableClass18<string>? //unknown
            where C : NullableClass18<string>? //unknown
            where D : class //non-null
            where E : class? //unknown
            where F : class? //unknown
            where G : notnull //non-null
            where H : struct //non-null
            //I = unknown
            //J = unknown
            //K = unknown
            //L = unknown
        {
            public static Tuple<Tuple<string, string?>, A> Field1A() => default!;
            public static Tuple<Tuple<string, string?>, B> Field1B() => default!;
            public static Tuple<Tuple<string, string?>, C> Field1C() => default!;
            public static Tuple<Tuple<string, string?>, D> Field1D() => default!;
            public static Tuple<Tuple<string, string?>, E> Field1E() => default!;
            public static Tuple<Tuple<string, string?>, F> Field1F() => default!;
            public static Tuple<Tuple<string, string?>, G> Field1G() => default!;
            public static Tuple<Tuple<string, string?>, H> Field1H() => default!;
            public static Tuple<Tuple<string, string?>, I> Field1I() => default!;
            public static Tuple<Tuple<string, string?>, J> Field1J() => default!;
            public static Tuple<Tuple<string, string?>, K> Field1K() => default!;
            public static Tuple<Tuple<string, string?>, L> Field1L() => default!;
            public static Tuple<Tuple<string, string?>, M> Field1M() => default!;
            public static Tuple<Tuple<string, string?>, N> Field1N() => default!;
            public static Tuple<Tuple<string, string?>, A?> Field2A() => default!;
            public static Tuple<Tuple<string, string?>, B?> Field2B() => default!;
            public static Tuple<Tuple<string, string?>, C?> Field2C() => default!;
            public static Tuple<Tuple<string, string?>, D?> Field2D() => default!;
            public static Tuple<Tuple<string, string?>, E?> Field2E() => default!;
            public static Tuple<Tuple<string, string?>, F?> Field2F() => default!;
            public static Tuple<Tuple<string, string?>, G?> Field2G() => default!;
            public static Tuple<Tuple<string, string?>, H?> Field2H() => default!;
            public static Tuple<Tuple<string, string?>, I?> Field2I() => default!;
            public static Tuple<Tuple<string, string?>, J?> Field2J() => default!;
            public static Tuple<Tuple<string, string?>, K?> Field2K() => default!;
            public static Tuple<Tuple<string, string?>, L?> Field2L() => default!;
            public static Tuple<Tuple<string, string?>, M?> Field2M() => default!;
            public static Tuple<Tuple<string, string?>, N?> Field2N() => default!;
        }
    }

    public struct TestStruct<T>
    {
        public T Value;
    }

    public class NullableClass19
    {
        public static string Field1() => null!;
        public static Task<string> Field2() => null!;
        public static string[] Field3() => null!;
        public static IEnumerable<string> Field4() => null!;
        public static IList<string> Field5() => null!;
        public static List<string> Field6() => null!;
        public static ICollection<string> Field7() => null!;
        public static IReadOnlyCollection<string> Field8() => null!;
        public static IReadOnlyList<string> Field9() => null!;
        public static HashSet<string> Field10() => null!;
        public static ISet<string> Field11() => null!;
        public static ICollection Field12() => null!;
        public static IEnumerable Field13() => null!;
        public static IDataLoaderResult<string> Field14() => null!;
        public static IDataLoaderResult Field15() => null!;
        public static Task<IDataLoaderResult<string[]>> Field16() => null!;
        public static object Field17() => null!;
        public static string Field18(string arg1 = "test", List<string> arg2 = null!, object arg3 = null!, object[] arg4 = null!) => null!;
    }

    public class NullableClass20
    {
        public static int Field1 => 0;
        public static string Field2 => null!;
        public static string? Field3 => null;
        public static List<string?> Field4 => null!;
        public static int? Field5 => null;
        public static string Field6 => null!;
    }
}
