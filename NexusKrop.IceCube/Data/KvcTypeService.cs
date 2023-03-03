namespace NexusKrop.IceCube.Data;
using System;
using System.Collections.Generic;

/// <summary>
/// Provides value type and type to value lookup service for <see cref="KeyValueContainer"/>.
/// </summary>
public static class KvcTypeService
{
    /// <summary>
    /// Gets a value indicating whether the type dictionaries have been built.
    /// </summary>
    public static bool Built { get; private set; }

    private static readonly KvcValueType[] KvcTypeEnums =
#if NET6_0_OR_GREATER
        Enum.GetValues<KvcValueType>();
#else
        (KvcValueType[])Enum.GetValues(typeof(KvcValueType));
#endif

    private static readonly Type[] KvcTypeBin = new Type[]
    {
        typeof(byte),
#if NET7_0_OR_GREATER
        typeof(sbyte),
#endif
        typeof(char),
        typeof(short),
        typeof(ushort),
        typeof(int),
        typeof(uint),
        typeof(long),
        typeof(ulong),
        typeof(string),
        typeof(bool),
        typeof(float),
        typeof(double),
    };

    internal static readonly Dictionary<KvcValueType, Type> KvcValueTypes = new();
    internal static readonly Dictionary<Type, KvcValueType> KvcTypeValues = new();

    static KvcTypeService()
    {
        Build();
    }

    /// <summary>
    /// Rebuild the type dictionaries, regardless if the dictionaries have been already built or not.
    /// </summary>
    public static void Rebuild()
    {
        Built = false;
        Build();
    }

    /// <summary>
    /// Build the type dictionaries, if the dictionaries have not already been built.
    /// </summary>
    /// <remarks>
    /// The type dictionaries is automatically built by the static constructor of the
    /// <see cref="KvcTypeService"/> class. There is no need to call this method.
    /// </remarks>
    public static void Build()
    {
        if (!Built)
        {
            KvcValueTypes.Clear();
            KvcTypeValues.Clear();

            for (int i = 0; i < KvcTypeEnums.Length; i++)
            {
                KvcValueTypes.Add(KvcTypeEnums[i], KvcTypeBin[i]);
                KvcTypeValues.Add(KvcTypeBin[i], KvcTypeEnums[i]);
            }
        }
    }
}
