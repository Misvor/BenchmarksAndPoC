namespace ConsoleApp1.Problems;

public class InfectedBinaryTree
{
    private int result = 0;
    public int AmountOfTime(TreeNode root, int start)
    {
        // GetDepth(root, start);
        // return result;
        
        var queue = new Queue<TreeNode>();
        var undirGraph = new Dictionary<int, List<int>>();
        
        queue.Enqueue(root);
        while (queue.Count != 0) // build undirected graph
        {
            var curr = queue.Dequeue();
            if (!undirGraph.ContainsKey(curr.val))
            {
                undirGraph.Add(curr.val, new List<int>());
            }
            
            if (curr.left != null)
            {
                if (!undirGraph.ContainsKey(curr.left.val))
                {
                    undirGraph.Add(curr.left.val, new List<int>(){curr.val});
                }
                undirGraph[curr.val].Add(curr.left.val);
                queue.Enqueue(curr.left);
            }
            
            if (curr.right != null)
            {
                if (!undirGraph.ContainsKey(curr.right.val))
                {
                    undirGraph.Add(curr.right.val, new List<int>(){curr.val});
                }
                undirGraph[curr.val].Add(curr.right.val);
                queue.Enqueue(curr.right);
            }
        }

        var maxPath = 0;
        
        
        // go through graph starting from start
        var visited = new bool[100000];

        var nextQueue = new Queue<(int node, int path)>();
        nextQueue.Enqueue((start, 0));

        while (nextQueue.Count != 0)
        {
            var curr = nextQueue.Dequeue();
            var currPath = curr.path;

            if (visited[curr.node])
            {
                continue;
            }
            visited[curr.node] = true;
            maxPath = Math.Max(maxPath, currPath);
            foreach (var path in undirGraph[curr.node])
            {
                nextQueue.Enqueue((path, currPath + 1));
            }
        }

        return maxPath;
    }
   
    
    
    public int GetDepth(TreeNode node, int start)
    {
        if (node == null)
        {
            return 0;
        }

        var leftDepth = GetDepth(node.left, start);
        var rightDepth = GetDepth(node.right, start);

        if (node.val == start)
        {
            result = Math.Max(leftDepth, rightDepth);
            return -1; // found infected, return
        }

        if (leftDepth >= 0 && rightDepth >= 0)
        {
            return Math.Max(rightDepth, leftDepth) + 1;
        }
        else
        {
            result = Math.Max(result, Math.Abs(leftDepth - rightDepth)); // one of them is zero
            return -1; // exit branch
        }
        
        
    }
    
}