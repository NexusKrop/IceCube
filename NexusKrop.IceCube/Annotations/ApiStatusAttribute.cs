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

namespace NexusKrop.IceCube.Annotations;
using System;

/// <summary>
/// Specifies the status of an API. This class cannot be inherited.
/// </summary>
[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
public sealed class ApiStatusAttribute :
    Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiStatusAttribute"/> class.
    /// </summary>
    /// <param name="status">The status.</param>
    public ApiStatusAttribute(ApiStatus status)
    {
        Status = status;
    }

    /// <summary>
    /// Gets or sets the status of the API specified.
    /// </summary>
    public ApiStatus Status { get; set; }
}
