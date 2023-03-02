// Copyright (C) 2023 NexusKrop & contributors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace NexusKrop.IceCube.Util;

using System;
using System.Collections.Generic;

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
