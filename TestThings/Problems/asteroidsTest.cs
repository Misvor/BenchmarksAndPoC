using ConsoleApp1.Problems;

namespace TestThings.Problems;

[TestClass]
public class asteroidsTest
{
    [TestMethod]
    [DataRow(new[]{1,1,-1,-2}, new []{-2})]
    [DataRow(new[]{-1,1,1,-2}, new []{-1,-2})]
    public void TestAsteroids(int[] data,  int[] expResult)
    {
        var executor = new Asteroids();

        var result = executor.AsteroidCollision(data);
        
        CollectionAssert.AreEquivalent(result, expResult);
    }    
}