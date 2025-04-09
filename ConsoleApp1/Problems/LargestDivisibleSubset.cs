namespace ConsoleApp1.Problems;

public class LargestDivisibleSubsetProblem
{
    public IList<int> LargestDivisibleSubset(int[] nums) {
        Array.Sort(nums);
        
        int[] dp = new int[nums.Length];
        int[] prev = new int[nums.Length];
        Array.Fill(dp, 1);
        Array.Fill(prev, -1);

        int maxIndex = 0;

        for (var i = 1; i < nums.Length; i++)
        {
            for (var j = 0; j < i; j++)
            {
                if (nums[i] % nums[j] == 0 
                    && dp[j] + 1 > dp[i]
                    )
                {
                    dp[i] = dp[j] + 1;
                    prev[i] = j;
                }
            }

            if (dp[i] > dp[maxIndex])
            {
                maxIndex = i;
            }
        }
        
        var result = new List<int>();
        var k = maxIndex;
        while (k != -1)
        {
            result.Add(nums[k]);
            k = prev[k];
        }
        result.Reverse();
        return result;
    }
}