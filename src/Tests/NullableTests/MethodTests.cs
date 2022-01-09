using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using Shane32.NullabilityInfo;
using Shouldly;
using Xunit;

namespace NullableTests
{
    public class MethodTests
    {
        [Theory]
        [InlineData(typeof(NullableClass1), "Field1", typeof(string), Nullability.Nullable)]
        [InlineData(typeof(NullableClass1), "Field2", typeof(string), Nullability.Nullable)]
        [InlineData(typeof(NullableClass1), "Field3", typeof(int), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass1), "Field4", typeof(int), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass1), "Field5", typeof(int), Nullability.Nullable)]
        [InlineData(typeof(NullableClass1), "Field6", typeof(int), Nullability.Nullable)]
        [InlineData(typeof(NullableClass1), "Field7", typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass1), "Field8", typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass1), "Field9", typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass1), "Field10", typeof(List<string>), Nullability.NonNullable, typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass2), "Field1", typeof(string), Nullability.Nullable)]
        [InlineData(typeof(NullableClass2), "Field2", typeof(string), Nullability.Nullable)]
        [InlineData(typeof(NullableClass2), "Field3", typeof(int), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass2), "Field4", typeof(int), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass2), "Field5", typeof(int), Nullability.Nullable)]
        [InlineData(typeof(NullableClass2), "Field6", typeof(int), Nullability.Nullable)]
        [InlineData(typeof(NullableClass2), "Field7", typeof(string), Nullability.Nullable)]
        [InlineData(typeof(NullableClass2), "Field8", typeof(string), Nullability.Nullable)]
        [InlineData(typeof(NullableClass2), "Field9", typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass2), "Field10", typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass2), "Field11", typeof(List<string>), Nullability.Nullable, typeof(string), Nullability.Nullable)]
        [InlineData(typeof(NullableClass5), "Test", typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass6), "Field1", typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass6), "Field2", typeof(string), Nullability.Nullable)]
        [InlineData(typeof(NullableClass7), "Field1", typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass7), "Field2", typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass7), "Field3", typeof(string), Nullability.Nullable)]
        [InlineData(typeof(NullableClass8), "Field1", typeof(string), Nullability.Nullable)]
        [InlineData(typeof(NullableClass8), "Field2", typeof(string), Nullability.Nullable)]
        [InlineData(typeof(NullableClass8), "Field3", typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass8), "Field4", typeof(int), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass9), "Field1", typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass10), "Field1", typeof(string), Nullability.Nullable)]
        [InlineData(typeof(NullableClass11), "Field1", typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass11), "Field2", typeof(string), Nullability.Nullable)]
        [InlineData(typeof(NullableClass12), "Field1", typeof(IDataLoaderResult<string>), Nullability.NonNullable, typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass12), "Field2", typeof(IDataLoaderResult<string>), Nullability.NonNullable, typeof(string), Nullability.Nullable)]
        [InlineData(typeof(NullableClass12), "Field3", typeof(IDataLoaderResult<string>), Nullability.Nullable, typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass12), "Field4", typeof(IDataLoaderResult<string>), Nullability.Nullable, typeof(string), Nullability.Nullable)]
        [InlineData(typeof(NullableClass13), "Field1", typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass13), "Field2", typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass14), "Field1", typeof(string), Nullability.Nullable)]
        [InlineData(typeof(NullableClass14), "Field2", typeof(string), Nullability.Nullable)]
        [InlineData(typeof(NullableClass15), "Field1", typeof(Task<string>), Nullability.NonNullable, typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass15), "Field2", typeof(Task<string>), Nullability.NonNullable, typeof(string), Nullability.Nullable)]
        [InlineData(typeof(NullableClass15), "Field3", typeof(Task<string>), Nullability.Nullable, typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass15), "Field4", typeof(Task<string>), Nullability.Nullable, typeof(string), Nullability.Nullable)]
        [InlineData(typeof(NullableClass16), "Field1", typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass16), "Field2", typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass16), "Field3", typeof(string), Nullability.Nullable)]
        [InlineData(typeof(NullableClass16.NestedClass1), "Field1", typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass16.NestedClass1), "Field2", typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass16.NestedClass1), "Field3", typeof(string), Nullability.Nullable)]
        [InlineData(typeof(NullableClass17), "Field1", typeof(Task<string>), Nullability.NonNullable, typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass17), "Field2", typeof(Task<string>), Nullability.NonNullable, typeof(string), Nullability.NonNullable)]
        [InlineData(typeof(NullableClass17), "Field3", typeof(Task<string>), Nullability.NonNullable, typeof(string), Nullability.Nullable)]
        public void Method_GetNullability(Type type, string methodName, Type expectedType, Nullability expectedNullability, Type expectedType2 = null, Nullability? expectedNullability2 = null)
        {
            var method = type.GetMethod(methodName);
            var actual = method.ReturnParameter.GetNullabilityInformation().ToList();
            actual.Count.ShouldBe(expectedType2 == null ? 1 : 2);
            actual[0].Type.ShouldBe(expectedType);
            actual[0].Nullable.ShouldBe(expectedNullability);
            if (expectedType2 != null) {
                actual[1].Type.ShouldBe(expectedType2);
                actual[1].Nullable.ShouldBe(expectedNullability2.Value);
            }
        }

        public static IEnumerable<object[]> Class18_GetNullability_TestCases()
        {
            return new object[][] {
            new object[] { "Field1", new List<(Type, Nullability)>() {
                (typeof(Tuple<string, string>), Nullability.NonNullable),
                (typeof(string), Nullability.NonNullable),
                (typeof(string), Nullability.Nullable),
            } },
            new object[] { "Field2", new List<(Type, Nullability)>() {
                (typeof(Tuple<Tuple<string, string>, string>), Nullability.NonNullable),
                (typeof(Tuple<string, string>), Nullability.NonNullable),
                (typeof(string), Nullability.Nullable),
                (typeof(string), Nullability.Nullable),
                (typeof(string), Nullability.NonNullable),
            } },
            new object[] { "Field3", new List<(Type, Nullability)>() {
                (typeof(Tuple<int?, string>), Nullability.NonNullable),
                (typeof(int), Nullability.Nullable),
                (typeof(string), Nullability.Nullable),
            } },
            new object[] { "Field4", new List<(Type, Nullability)>() {
                (typeof(Tuple<Guid, string>), Nullability.NonNullable),
                (typeof(Guid), Nullability.NonNullable),
                (typeof(string), Nullability.Nullable),
            } },
            new object[] { "Field5", new List<(Type, Nullability)>() {
                (typeof(Tuple<string[], string>), Nullability.NonNullable),
                (typeof(string[]), Nullability.NonNullable),
                (typeof(string), Nullability.NonNullable),
                (typeof(string), Nullability.Nullable),
            } },
            new object[] { "Field6", new List<(Type, Nullability)>() {
                (typeof(Tuple<int[], string>), Nullability.NonNullable),
                (typeof(int[]), Nullability.NonNullable),
                (typeof(int), Nullability.NonNullable),
                (typeof(string), Nullability.Nullable),
            } },
            new object[] { "Field7", new List<(Type, Nullability)>() {
                (typeof(Tuple<(int, string), string>), Nullability.NonNullable),
                (typeof((int, string)), Nullability.NonNullable),
                (typeof(int), Nullability.NonNullable),
                (typeof(string), Nullability.NonNullable),
                (typeof(string), Nullability.Nullable),
            } },
            new object[] { "Field8", new List<(Type, Nullability)>() {
                (typeof(Tuple<(int, string), string>), Nullability.NonNullable),
                (typeof((int, string)), Nullability.NonNullable),
                (typeof(int), Nullability.NonNullable),
                (typeof(string), Nullability.NonNullable),
                (typeof(string), Nullability.Nullable),
            } },
            new object[] { "Field9", new List<(Type, Nullability)>() {
                (typeof(Tuple<TestStruct<Guid>, string>), Nullability.NonNullable),
                (typeof(TestStruct<Guid>), Nullability.NonNullable),
                (typeof(Guid), Nullability.NonNullable),
                (typeof(string), Nullability.Nullable),
            } },
            new object[] { "Field10", new List<(Type, Nullability)>() {
                (typeof(Tuple<,>).MakeGenericType(typeof(NullableClass18<>).GetGenericArguments()[0], typeof(string)), Nullability.NonNullable),
                (typeof(NullableClass18<>).GetGenericArguments()[0], Nullability.NonNullable),
                (typeof(string), Nullability.Nullable),
            } },
        };
        }

        [Theory]
        [MemberData(nameof(Class18_GetNullability_TestCases))]
        public void Method_GetNullability_Class18(string methodName, List<(Type, Nullability)> expected)
        {
            var method = typeof(NullableClass18<>).GetMethod(methodName).ShouldNotBeNull();
            if (methodName == "Field10")
            {

            }
            var actual = method.ReturnParameter.GetNullabilityInformation().ToList();
            actual.ShouldBe(expected);
        }

        [Theory]
        [InlineData("Field1A", NullabilityState.NotNull)]
        [InlineData("Field1B", NullabilityState.Unknown)]
        [InlineData("Field1C", NullabilityState.Unknown)]
        [InlineData("Field1D", NullabilityState.NotNull)]
        [InlineData("Field1E", NullabilityState.Unknown)]
        [InlineData("Field1F", NullabilityState.Unknown)]
        [InlineData("Field1G", NullabilityState.NotNull)]
        [InlineData("Field1H", NullabilityState.NotNull)]
        [InlineData("Field1I", NullabilityState.Unknown)]
        [InlineData("Field1J", NullabilityState.Unknown)]
        [InlineData("Field1K", NullabilityState.Unknown)]
        [InlineData("Field1L", NullabilityState.Unknown)]
        [InlineData("Field1M", NullabilityState.NotNull)]
        [InlineData("Field1N", NullabilityState.Unknown)]
        [InlineData("Field2A", NullabilityState.Nullable)]
        [InlineData("Field2B", NullabilityState.Nullable)]
        [InlineData("Field2C", NullabilityState.Nullable)]
        [InlineData("Field2D", NullabilityState.Nullable)]
        [InlineData("Field2E", NullabilityState.Nullable)]
        [InlineData("Field2F", NullabilityState.Nullable)]
        [InlineData("Field2G", NullabilityState.Nullable)]
        [InlineData("Field2H", NullabilityState.Nullable)]
        [InlineData("Field2I", NullabilityState.Nullable)]
        public void Test_OpenGeneric(string fieldName, NullabilityState state)
        {
            var t = typeof(Parent1<,>.Complex1<,,,,,,,,,,,>);
            var method = t.GetMethod(fieldName).ShouldNotBeNull();
            var context = new NullabilityInfoContext();
            var info = context.Create(method.ReturnParameter);
            var info2 = info.GenericTypeArguments[1];
            info2.ReadState.ShouldBe(state);
        }
    }
}
