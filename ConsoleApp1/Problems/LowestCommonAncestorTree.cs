namespace ConsoleApp1.Problems;

public class LowestCommonAncestorTree
{
    private int result = 0;
    
    public TreeNode LcaDeepestLeaves(TreeNode root) {
        return DFS(root).Node;
    }
    
    public TreeNode SubtreeWithAllDeepest(TreeNode root) {
        return DFS(root).Node;
    }

    public (TreeNode Node, int Dist) DFS(TreeNode node)
    {
        if (node is null)
        {
            return (null, 0);
        }
        
        var L = DFS(node.left);
        var R = DFS(node.right);

        if (L.Dist > R.Dist)
        {
            return (L.Node, L.Dist + 1);
        }

        if (R.Dist > L.Dist)
        {
            return (R.Node, R.Dist + 1);
        }
        return (node, L.Dist + 1);
    }
    
}