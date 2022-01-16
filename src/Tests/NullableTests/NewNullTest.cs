#nullable enable

using System;
using System.Collections.Generic;
using Shane32.NullabilityInfo;
using Xunit;

namespace NullableTests
{
    public class NewNullTest
    {

        public static IEnumerable<object[]> NestedGenericsCorrectOrderData()
        {
            yield return new object[] {
                "MethodReturnsNonTupleNonTupleNullStringNullStringNullString",
                new[] { NullabilityState.NotNull, NullabilityState.NotNull, NullabilityState.Nullable, NullabilityState.Nullable, NullabilityState.Nullable },
                new[] { typeof(Tuple<Tuple<string, string>, string>), typeof(Tuple<string, string>), typeof(string), typeof(string), typeof(string) }
            };
            yield return new object[] {
                "MethodReturnsNonTupleNonTupleNullStringNullStringNonString",
                new[] { NullabilityState.NotNull, NullabilityState.NotNull, NullabilityState.Nullable, NullabilityState.Nullable, NullabilityState.NotNull },
                new[] { typeof(Tuple<Tuple<string, string>, string>), typeof(Tuple<string, string>), typeof(string), typeof(string), typeof(string) }
            };
        }

        [Theory]
        [MemberData(nameof(NestedGenericsCorrectOrderData))]
        public void NestedGenericsCorrectOrderTest(string methodName, NullabilityState[] nullStates, Type[] types)
        {
            var context = new NullabilityInfoContext();
            var parentInfo = context.Create(typeof(MyTestType).GetMethod(methodName)!.ReturnParameter);
            var dataIndex = 0;
            Examine(parentInfo);
            Assert.Equal(nullStates.Length, dataIndex);
            Assert.Equal(types.Length, dataIndex);

            void Examine(NullabilityInfo info)
            {
                Assert.Equal(types[dataIndex], info.Type);
                Assert.Equal(nullStates[dataIndex++], info.ReadState);
                for (var i = 0; i < info.GenericTypeArguments.Length; i++) {
                    Examine(info.GenericTypeArguments[i]);
                }
            }
        }

        public class MyTestType
        {
            public Tuple<Tuple<string?, string?>, string?> MethodReturnsNonTupleNonTupleNullStringNullStringNullString() => null!;
            public Tuple<Tuple<string?, string?>, string> MethodReturnsNonTupleNonTupleNullStringNullStringNonString() => null!;
        }
    }
}
