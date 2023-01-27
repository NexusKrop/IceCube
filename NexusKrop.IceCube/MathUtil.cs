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

namespace NexusKrop.IceCube;

using System;

/// <summary>
/// Provides methods to perform certain calculations.
/// </summary>
public static class MathUtil
{
    /// <summary>
    /// Calculates the remaining precentage (of 100%) of the completed amount of works versus
    /// total amount of works.
    /// </summary>
    /// <param name="current">The amount of works that are currently complete.</param>
    /// <param name="total">The total amount of works to complete.</param>
    /// <returns>
    /// The remaining precentage (of 100%) of the completed amount of works versus total
    /// amount of works.
    /// </returns>
    public static int CalculatePercentage(int current, int total)
    {
        return (int)Math.Round(current / (double)total * 100);
    }
}