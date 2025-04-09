using ConsoleApp1.Problems;

namespace TestThings.Problems;

[TestClass]
public class PartitionEqualSubsetSumProblemTests
{


    [TestMethod]
    [DynamicData(nameof(AdditionalData), DynamicDataSourceType.Method)]
    public void TestPartitionEqualSubsetSumProblem( int[] nums, bool testResult)
    {
        var calc = new PartitionEqualSubsetSumProblem();
        
        var result = calc.CanPartition(nums);
        
        Assert.AreEqual(testResult, result);
    }
    
    public static IEnumerable<object[]> AdditionalData()
    {
        yield return new object[]
        {
            new int[] { 1, 1}.ToArray(),
            true,
        }; 
        
        yield return new object[]
        {
            new int[] { 23, 13,11,7,6,5,5 }.ToArray(),
            true,
        };
        
        yield return new object[]
        {
            new int[] { 6,14,19,10,17,10,8,15,16,1,12,4,9,2,15}.ToArray(),
            true,
        };
        
        yield return new object[]
        {
            new int[] { 4,10,7,9,7,1,11,9,13,15}.ToArray(),
            true,
        };
        
        yield return new object[]
        {
            new int[] { 100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,99,97}.ToArray(),
            false,
        };
    }
}