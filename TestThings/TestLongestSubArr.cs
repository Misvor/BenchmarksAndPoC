using ConsoleApp1.Problems;

namespace TestThings;

[TestClass]
public class TestLongestSubArr
{
    [TestMethod]
    [DataRow(new []{1,1,0,1}, 3)]
    [DataRow(new []{1,1,0,0,1}, 2)]
    [DataRow(new []{1,1,1,1,1,1,1,1,1,0,1}, 10)]
    [DataRow(new []{0,0,0,0,0,1}, 1)]
    [DataRow(new []{0,0,0,0,0}, 0)]
    [DataRow(new []{1,1,1,1,1}, 4)]
    [DataRow(new []{0,0,1,1}, 2)]
    [DataRow(new []{1}, 0)]
    public void TestProblem(int[] nums, int expResult)
    {
       //Arrange
       var solution = new LongstSubArr();
       
       //Act
       var result = solution.LongestSubarray(nums);

       //Assert
       
       Assert.AreEqual(result, expResult);
    }
    
}