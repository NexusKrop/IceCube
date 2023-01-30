namespace NexusKrop.IceCube.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[TestClass]
public class MathUtilTest
{
    [TestMethod]
    public void PrecentageTest()
    {
        Assert.AreEqual(20, MathUtil.CalculatePercentage(2, 10));
    }
}
