namespace ConsoleApp1.Problems;

public class PartitionEqualSubsetSumProblem
{
    public bool CanPartition(int[] nums) {
        
        var sum = nums.Sum();
        if (sum % 2 != 0)
        {
            return false;
        }

        var target = sum / 2;
        var dp = new bool[target + 1];
        dp[0] = true;
        
        foreach (var n in nums)
        {
            for (var w = target; w > 0; w--)
            {
                if (w >= n)
                {
                    dp[w] = dp[w] || dp[w - n];
                }
            }
        }
        return dp[target];
    }
}