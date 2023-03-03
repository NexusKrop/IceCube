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
