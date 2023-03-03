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

/// <summary>
/// Specifies the status of the API.
/// </summary>
public enum ApiStatus
{
    /// <summary>
    /// Indicates that the API is stable and may be used for production.
    /// </summary>
    Stable,
    /// <summary>
    /// Indicates that the API is not stable and should not be used for production yet.
    /// </summary>
    Unstable,
    /// <summary>
    /// Indicates that the API is in rapid development and must not be used for production.
    /// </summary>
    Alpha
}
