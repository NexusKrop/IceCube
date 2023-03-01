namespace NexusKrop.IceCube.Tests;

using NUnit.Framework;

public class MathUtilTest
{
    [Test]
    public void PrecentageTest()
    {
        Assert.That(MathUtil.CalculatePercentage(2, 10), Is.EqualTo(20));
    }
}
