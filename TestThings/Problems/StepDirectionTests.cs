using ConsoleApp1.Problems;

namespace TestThings.Problems;

[TestClass]
public class StepDirectionTests
{
    [TestMethod]
    [DynamicData(nameof(AdditionalData), DynamicDataSourceType.Method)]
    public void TestStepByStep(int?[] firstNode, int start, int dest, string expResult)
    {
        var executor = new StepDirections();

        var Node = TestHelper.CreateNode(firstNode, 0);

        var result = executor.GetDirections(Node, start, dest);

        Assert.AreEqual(result, expResult);
    }
    public static IEnumerable<object[]> AdditionalData()
    {
        yield return new object[]
        {
            new int?[] { 5, 1, 2, 3, null, 6, 4}.ToArray(),
            3,
            6,
            "UURL"
        }; 
        
        yield return new object[]
        {
            new int?[] { 5, 1, 2, 3, null, 6, 4}.ToArray(),
            2,
            4,
            "R"
        };
        
         yield return new object[]
        {
            new int?[] { 5, 1, 2, 3, null, 6, 4}.ToArray(),
            2,
            1,
            "UL"
        };
          yield return new object[]
        {
            new int?[] { 5, 1, 2, 3, null, 6, 4}.ToArray(),
            6,
            4,
            "UR"
        };
        
        yield return new object[]
        {
            new int?[] { 2,1}.ToArray(),
            2,
            1,
            "L"
        };
    }
}