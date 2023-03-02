namespace NexusKrop.IceCube.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Provides extensions to the <see cref="Type"/> class.
/// </summary>
public static class TypeExtensions
{
#if NET6_0_OR_GREATER
    private static readonly IReadOnlySet<Type> Primitives = new HashSet<Type>
#else
    private static readonly Type[] Primitives = new Type[]
#endif
    {
        typeof(int),
        typeof(float),
        typeof(double),
        typeof(bool),
        typeof(string),
        typeof(byte),
        typeof(short),
        typeof(ushort),
        typeof(uint),
        typeof(ulong)
    };

    /// <summary>
    /// Determines whether the specified <see cref="Type"/> is a primitive type.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns><see langword="true"/> if the specified type is a primitive type; otherwise, <see langword="false" />.</returns>
    public static bool IsPrimitive(this Type type)
    {
        return Primitives.Contains(type);
    }
}
