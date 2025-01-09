using ConsoleApp1.Problems;

namespace TestThings.Problems;

[TestClass]
public class LeavesEqualTests
{
    [TestMethod]
    [DynamicData(nameof(AdditionalData), DynamicDataSourceType.Method)]
    public void TestEqualLeaves(int?[] firstNode, int?[] secondNode, bool expResult)
    {
        var executor = new LeavesEqual();

        var Node = TestHelper.CreateNode(firstNode, 0);
        var NodeTwo = TestHelper.CreateNode(secondNode, 0);

        var result = executor.LeafSimilar(Node, NodeTwo);

        Assert.AreEqual(result, expResult);
    }
    
    

    public static IEnumerable<object[]> AdditionalData()
    {
        yield return new object[]
        {
            new int?[] { 3, 5, 1, 6, 2, 9, 8, null, null, 7, 4 }.ToArray(),
            new int?[] { 3, 5, 1, 6, 7, 4, 2, null, null, null, null, null, null, 9, 8 }.ToArray(),
            true,
        };

        yield return new object[]
        {
            new[] { 1, 2, 3 }.Cast<int?>().ToArray(),
            new[] { 1, 3, 2 }.Cast<int?>().ToArray(),
            false
        }; 
        yield return new object[]
        {
            new[] { 1, 2 }.Cast<int?>().ToArray(),
            new[] { 2, 2 }.Cast<int?>().ToArray(),
            true
        };
        
        yield return new object[]
        {
            new int?[] { 119,113,null,11,30,43,76,15,60,67,74 }.ToArray(), // can't build this tree
            new int?[] { 11,69,60,115,66,15,60,67,74,null,76 }.ToArray(),
            true
        };
    }
}

public static class TestHelper
{
    public static TreeNode CreateNode(int?[] source, int nodeValPos)
    {
        var rootNode = new TreeNode();
        rootNode.val = source[nodeValPos].Value;

        while (true)
        {
            var leftNodePos = (nodeValPos) * 2+1;
            if (source.Length > leftNodePos && source[leftNodePos].HasValue)
            {
                rootNode.left = CreateNode(source, leftNodePos);
            }

            var rightNodePos = (nodeValPos + 1) * 2;
            if (source.Length > rightNodePos && source[rightNodePos].HasValue)
            {
                rootNode.right = CreateNode(source, rightNodePos);
            }

            return rootNode;
        }
    } 
}