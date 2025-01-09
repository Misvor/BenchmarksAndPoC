using ConsoleApp1.Problems;

namespace TestThings.Problems;

[TestClass]
public class InfectedBinaryTreeTests
{
    [TestMethod]
    [DynamicData(nameof(AdditionalData), DynamicDataSourceType.Method)]
    public void TestInfectedBinaryTree(int?[] firstNode, int path)
    {
        var executor = new InfectedBinaryTree();

        var Node = CreateNode(firstNode, 0);

        var result = executor.AmountOfTime(Node, 3);

        Assert.AreEqual(result, path);
    }

    public static IEnumerable<object[]> AdditionalData()
    {
        yield return new object[]
        {
            new int?[] { 3, 5, 1, 6, 2, 9, 8, null, null, 7, 4 }.ToArray(),
            3,
        };

        yield return new object[]
        {
            new[] { 1, 2, 3 }.Cast<int?>().ToArray(),
            4
        }; 
        yield return new object[]
        {
            new[] { 1, 2, 3 }.Cast<int?>().ToArray(),
            5
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