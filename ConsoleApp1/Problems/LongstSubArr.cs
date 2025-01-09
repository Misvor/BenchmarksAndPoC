namespace ConsoleApp1.Problems;

public class LongstSubArr
{
    public int LongestSubarray(int[] nums) {
        
        var firstGroup = 0;
        var currLen = 0;
        var maxLen = 0;
        bool hasJunk = false;

        for(var i = 0; i < nums.Length; i++)
        {
            if(nums[i] == 1)
            {
                currLen++;
            }
            else
            {
                hasJunk = true;
            }
            
            if(nums[i] == 0 || i == (nums.Length - 1))
            {
                
                if(currLen != 0)
                {                    
                    if(firstGroup != 0)
                    {
                        if(firstGroup + currLen > maxLen )
                        {
                            maxLen = firstGroup + currLen;
                        }
                        firstGroup = currLen;                        
                    }
                    else
                    {
                        if (hasJunk)
                        {
                            if(currLen > maxLen)
                            {
                                maxLen = currLen;
                            }
                        }
                        else if(currLen - 1 > maxLen)
                        {
                            maxLen = currLen -1;
                        }
                        firstGroup = currLen;                        
                    }

                    currLen = 0;
                }
                else
                {
                    firstGroup = 0;
                }                
            }
        }
        
        return maxLen;
    }
}