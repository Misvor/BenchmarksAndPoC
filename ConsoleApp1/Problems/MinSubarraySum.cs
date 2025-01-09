namespace ConsoleApp1.Problems;

public class MinSubarraySum
{
    public int MinSubArrayLen(int target, int[] nums)
    {
        var sum = nums.Sum();
        if (sum < target)
        {
            return 0;
        }
        
        var shortest = int.MaxValue;
        var currSum = 0;
        var slowPtr = 0;
        var fastPtr = 0;
        var length = 0;

        while (slowPtr < nums.Length)
        {
            while (currSum < target)
            {
                if (fastPtr == nums.Length)
                {
                    return shortest;
                }
                currSum += nums[fastPtr];
                length++;
                fastPtr++;
            }
            
            if (currSum >= target)
            {
                if (length < shortest)
                {
                    shortest = length;
                }
            }
            
            currSum -= nums[slowPtr];
            length--;

            slowPtr++;
        }
        
        return shortest;
    }

    
}