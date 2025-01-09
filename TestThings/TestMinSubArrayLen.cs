using ConsoleApp1.Problems;

namespace TestThings;

[TestClass]
public class TestMinSubArrayLen
{

    [TestMethod]
    [DataRow(7, new []{2,3,1,2,4,3}, 2)]
    [DataRow(11, new []{1,1,1,1,1,1}, 0)]
    [DataRow(213, new []{12,28,83,4,25,26,25,2,25,25,25,12}, 8)]
    [DataRow(11, new []{1,2,3,4,5}, 3)]
    public void TestProblem(int target, int[] nums, int expResult)
    {
        //Arrange
        var calc = new MinSubarraySum();
        


        //Act
        var result = calc.MinSubArrayLen(target, nums);

        //Assert
        Assert.AreEqual(result, expResult);
    }
    
}