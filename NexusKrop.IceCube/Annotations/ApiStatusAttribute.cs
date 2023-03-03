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
