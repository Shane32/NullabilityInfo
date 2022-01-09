using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Shane32.NullabilityInfo
{
    /// <summary>
    /// Nullable reference annotation for a member.
    /// </summary>
    public enum Nullability
    {
        /// <summary>
        /// The member is a reference type not marked with nullable reference annotations.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// The member is a non-nullable value type or is a nullable reference type marked as non-nullable.
        /// </summary>
        NonNullable = 1,

        /// <summary>
        /// The member is a nullable value type or is a nullable reference type marked as nullable.
        /// </summary>
        Nullable = 2,
    }
    public static class Compat
    {
        public static IEnumerable<(Type Type, Nullability Nullable)> GetNullabilityInformation(this PropertyInfo property)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            return Interpret(new NullabilityInfoContext().Create(property));
        }

        public static IEnumerable<(Type Type, Nullability Nullable)> GetNullabilityInformation(this ParameterInfo parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            return Interpret(new NullabilityInfoContext().Create(parameter));
        }

        private static IEnumerable<(Type, Nullability)> Interpret(NullabilityInfo info)
        {
            var list = new List<(Type, Nullability)>();
            RecursiveLoop(info);
            return list;

            void RecursiveLoop(NullabilityInfo info)
            {
                if (info.Type.IsGenericType) {
                    if (info.Type.GetGenericTypeDefinition() == typeof(Nullable<>)) {
                        list.Add((info.Type.GetGenericArguments()[0], Nullability.Nullable));
                    } else {
                        list.Add((info.Type, Convert(info.ReadState)));
                    }
                    foreach (var t in info.GenericTypeArguments) {
                        RecursiveLoop(t);
                    }
                } else {
                    list.Add((info.Type, Convert(info.ReadState)));
                }
            }

            static Nullability Convert(NullabilityState state) => state switch {
                NullabilityState.Unknown => Nullability.Unknown,
                NullabilityState.NotNull => Nullability.NonNullable,
                NullabilityState.Nullable => Nullability.Nullable,
                _ => throw new ArgumentOutOfRangeException(nameof(state)),
            };
        }

    }
}
