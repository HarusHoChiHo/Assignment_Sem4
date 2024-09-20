using Assign3_ClassLibrary_ChiHo;

namespace Assign3_TestProject_ChiHo;


[TestClass]
public class UnitTest
{
    [TestMethod]
    public void BasicRooterTest()
    {
        // Create an instance to test:
        Rooter rooter = new Rooter();
        // Define a test input and output
        value: double expectedResult = 2.0;
        double        input          = expectedResult * expectedResult;
        // Run the method under test:
        double actualResult = rooter.SquareRoot(input);
        // Verify the result:
        Assert.AreEqual(expectedResult, actualResult,
                        delta: expectedResult / 100);
    }
    
    [TestMethod]
    public void RooterValueRange()
    {
        // Create an instance to test:
        Rooter rooter = new Rooter();
        // Try a range of values:
        for (double expectedResult = 1e-8;
             expectedResult < 1e+8;
             expectedResult = expectedResult * 3.2)
        {
            RooterOneValue(rooter, expectedResult);
        }
    }
    private void RooterOneValue(Rooter rooter, double expectedResult)
    {
        double input        = expectedResult * expectedResult;
        double actualResult = rooter.SquareRoot(input);
        Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 1000);
    }
    
    [TestMethod]
    public void RooterTestNegativeInputx()
    {
        Rooter rooter = new Rooter();
        try
        {
            rooter.SquareRoot(-10);
        }
        catch (ArgumentOutOfRangeException e)
        {
            return;
        }
        Assert.Fail();
    }
}