namespace NexusKrop.IceCube;

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