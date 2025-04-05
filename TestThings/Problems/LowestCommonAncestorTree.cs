using ConsoleApp1.Problems;

namespace TestThings.Problems;

[TestClass]
public class LowestCommonAncestorTreeTests
{
    [TestMethod]
    [DynamicData(nameof(AdditionalData), DynamicDataSourceType.Method)]
    public void TestLowestCommonAncestorTree(int?[] firstNode, TreeNode resultNode)
    {
        var executor = new LowestCommonAncestorTree();

        var Node = CreateNode(firstNode, 0);

        var result = executor.LcaDeepestLeaves(Node);

        Assert.AreEqual(result, result);
    }

    public static IEnumerable<object[]> AdditionalData()
    {
        yield return new object[]
        {
            new int?[] { 3, 5, 1, 6, 2, 9, 8, null, null, 7, 4 }.ToArray(),
            CreateNode(new int?[] { 2,7,4}.ToArray(), 0),
        };
    }


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