using System.Text;

namespace ConsoleApp1.Problems;

public class StepDirectionsTree
{
    public string GetDirections(TreeNode root, int startValue, int destValue) {
        var pathToStart = DFS(root, startValue);
        var pathToEnd = DFS(root, destValue);

        var result = CombinePaths(pathToStart, pathToEnd);
        return result;
    }

    private string DFS(TreeNode root, int searchValue)
    {
        var visited = new bool[100001];
        var path = new List<char>();
        var result = DFSUtil(root, visited, path, searchValue).Reverse().SkipLast(1);
        return new string(result.ToArray());
    }

    private IEnumerable<char> DFSUtil(TreeNode node, bool[] visited, List<char> path, int searchValue)
    {
        if(visited[node.val])
        {
            return Enumerable.Empty<char>();
        }
        
        if(node.val == searchValue)
        {
            path.Add('#');
            return path;
            // start building result path
        }

        if(node.left != null)
        {
            var left = DFSUtil(node.left, visited, path, searchValue);
            if(left.Count() != 0)
            {
                path.Add('L');
                return path;
            }
        }
        if(node.right != null)
        {
            var right = DFSUtil(node.right, visited, path, searchValue);
            if(right.Count() != 0)
            {
                path.Add('R');
                return path;
            }
        }
        visited[node.val] = true;
        return Enumerable.Empty<char>();
    }

    private string CombinePaths(string start, string end)
    {
        var sb = new StringBuilder();
        // start is root? 
        // end is root?

        var pos = 0;
        var samePath = true;

        if(start.Length == 0 && end.Length == 0)
        {
            return string.Empty;
        }

        if(start.Length == 0)
        {            
            return end;
        }

        if(end.Length == 0)
        {
            return sb.Append('U', start.Length).ToString();
        }

        while(samePath)
        {   
            if((start.Length >= 1 && end.Length >= 1) && start[pos] == end[pos]) 
            {
                start = start[1..];
                end = end[1..];
                // paths are similar, skip
            }else
            {
                samePath = false;
                // paths are different                
            }            
        }
        
        // if not same - add move up
        sb.Append('U', start.Length);      
        
        foreach(var step in end)
        {
            // path to end from node is same
            // as path to end from start past the highest ancestor
            sb.Append(step);
        }
        return sb.ToString();
    }
}