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

/// <summary>
/// Provides methods for assisting the creation of delegates.
/// </summary>
public static class Delegates
{
    /// <summary>
    /// Creates a <see cref="Func{TResult}"/> with no parameters that always returns the specified <paramref name="value"/>.
    /// </summary>
    /// <typeparam name="T">The type of value.</typeparam>
    /// <param name="value">The value to return.</param>
    /// <returns>A a <see cref="Func{TResult}"/> with no parameters that always returns the specified <paramref name="value"/>.</returns>
    public static Func<T> Of<T>(T value) => () => value;
}
