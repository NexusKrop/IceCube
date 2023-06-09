namespace NexusKrop.IceCube.Util;
using System.Text;

/// <summary>
/// Provide utilities to manipulate URL paths.
/// </summary>
public static class UrlPath
{
    /// <summary>
    /// Combines two or more URL paths to a single URL path.
    /// </summary>
    /// <param name="parts">The parts of the URL path to combine.</param>
    /// <returns>The combined result.</returns>
    public static string Combine(params string[] parts)
    {
        var builder = new StringBuilder();

        foreach (var part in parts)
        {
            builder.Append(part);

            if (!part.EndsWith("/"))
            {
                builder.Append('/');
            }
        }

        return builder.ToString();
    }
}
