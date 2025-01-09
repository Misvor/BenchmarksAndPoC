namespace ConsoleApp1.Problems;

public class LeavesEqual
{
    
    public bool LeafSimilar(TreeNode root1, TreeNode root2) {

        if (GetLeaves(root1).SequenceEqual(GetLeaves(root2)))
        {
            return true;
        }
        return false;
    }
    
    IEnumerable<int> GetLeaves(TreeNode node)
    {
        if (node.left == null && node.right == null)
        {
            yield return node.val;
        }
        if(node.left != null)
        {
            foreach (var leaf in GetLeaves(node.left))
            {
                yield return leaf;
            }
        }
        if (node.right != null)
        {
            foreach (var leaf in GetLeaves(node.right))
            {
                yield return leaf;
            }  
        }
    }
}



public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}