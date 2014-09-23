using AndreiPopescu.CharazayPlus.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CharazayPlus.Tests
{
    
    
    /// <summary>
    ///This is m test class for LinearTest and is intended
    ///to contain all LinearTest Unit Tests
    ///</summary>
  [TestClass()]
  public class LinearAlgebraTest
  {
    /// <summary>
    ///A test for ArraySum
    ///</summary>
    [TestMethod()]
    //[DeploymentItem("CharazayPlus.exe")]
    public void ArraySumTest ( )
    {
      double[] in1 = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
      double expected = 55d;
      double actual = Linear.ArraySum(in1);
      Assert.AreEqual(expected, actual);
    }

    [TestMethod()]
    //[DeploymentItem("CharazayPlus.exe")]
    public void ArraySumNullTest ( )
    {
      double expected = 0F;
      double actual = Linear.ArraySum(null);
      Assert.AreEqual(expected, actual);      
    }

    /// <summary>
    ///A test for DotVectorProduct
    ///</summary>
    [TestMethod()]
    //[DeploymentItem("CharazayPlus.exe")]
    [ExpectedException(typeof(ArgumentNullException))]
    public void DotVectorProductNullTest1 ( )
    {
      Linear.DotVectorProduct(null, new double[]{});      
    }

    /// <summary>
    ///A test for DotVectorProduct
    ///</summary>
    [TestMethod()]
    //[DeploymentItem("CharazayPlus.exe")]
    [ExpectedException(typeof(ArgumentNullException))]
    public void DotVectorProductNullTest2 ( )
    {
      Linear.DotVectorProduct(new double[] { }, null);
    }

    [TestMethod()]
    //[DeploymentItem("CharazayPlus.exe")]
    [ExpectedException(typeof(ArgumentException))]
    public void DotVectorProductZeroLenTest2 ( )
    {
      Linear.DotVectorProduct(new double[] { }, new double[2]);
    }

    [TestMethod()]
    //[DeploymentItem("CharazayPlus.exe")]
    [ExpectedException(typeof(ArgumentException))]
    public void DotVectorProductZeroLenTest1 ( )
    {
      Linear.DotVectorProduct(new double[2], new double[0]);
    }

    [TestMethod()]
    //[DeploymentItem("CharazayPlus.exe")]
    [ExpectedException(typeof(ArgumentException))]
    public void DotVectorProductDiffLenTest ( )
    {
      Linear.DotVectorProduct(new double[2], new double[6]);
    }

    [TestMethod()]
    //[DeploymentItem("CharazayPlus.exe")]
    public void DotVectorProductTest ( )
    {
      double[] ard = new double[] { 0.2, 0.3, 0.5 };
      Assert.AreEqual (Linear.DotVectorProduct(ard,ard), 0.38d);
    }

    [TestMethod()]
    //[DeploymentItem("CharazayPlus.exe")]
    [ExpectedException(typeof(ArgumentException))]
    public void DotVectorProductNormExTest ( )
    {
      Assert.AreEqual(Linear.DotVectorProduct_Normalized(new double[] { 0.31, 0.3, 0.4 }, new double[] { 10, 20, 30 }), 21d);
    }

    [TestMethod()]
    //[DeploymentItem("CharazayPlus.exe")]
    public void DotVectorProductNormTest ( )
    {
      double[] ard = new double[] { 0.2, 0.3, 0.5 };
      Assert.AreEqual(Linear.DotVectorProduct_Normalized(ard, ard), 0.38d);
      Assert.AreEqual(Linear.DotVectorProduct_Normalized(new double[]{0.3,0.3,0.4}, new double[]{10,20,30}), 21d);
    }
   
  }
}
