namespace ConsoleApp1.Problems;

public class CountDaysProblem
{
    public int CountDays(int days, int[][] meetings) {
        if(days == 0){
            return 0;
        }
        if(meetings.Length == 0){
            return days;
        }

        var listArr = new List<int[]>();
        var sortedArr = meetings.OrderBy(x => x[0]).ToArray();
        var concatArr = sortedArr[0];
        
        foreach (var pair in sortedArr)
        {
            if (pair[0] > concatArr[1])
            {
                listArr.Add(concatArr);
                concatArr = pair;
            }
            else
            {
                if (pair[1] >= concatArr[1])
                {
                    concatArr[1] = pair[1];
                }
            }
        }
        listArr.Add(concatArr);

        var freeDays = listArr.First()[0] - 1;
        if(listArr.Count > 1)
        {
            for (var i = 0; i < listArr.Count - 1; i++)
            {
                freeDays += listArr[i + 1][0] - listArr[i][1] - 1;
            }
        }

        freeDays += days - listArr.Last()[1]; 

        return freeDays;

    }
    
    public long MostPoints(int[][] questions)
    {
        var val = new long[questions.Length];
        var max = new long[questions.Length];
        max[questions.Length - 1] = questions[questions.Length - 1][0];
        val[questions.Length - 1] = questions[questions.Length - 1][0];
        val[questions.Length - 1] = questions[questions.Length - 1][0];

        long result = questions[questions.Length - 1][0]; 
            
        for (var i = questions.Length - 2; i >= 0; i--)
        {
            if (questions[i][1] + i + 1 >= questions.Length)
            {
                val[i] = questions[i][0];
            }
            else
            {
                val[i] = questions[i][0] + max[questions[i][1] + i + 1];
            }
            max[i] = Math.Max(max[i + 1], val[i]);
            
            var something = questions[^i..^0].Max();
        }
        return result;
    }
    public long MaximumTripletValue(int[] nums) {
        
        var prefixMax = new long[nums.Length];
        var suffixMax = new long[nums.Length];
        var max = 0;
        for(var i = 0; i < nums.Length; i++)
        {
            if(nums[i] > max){
                max = nums[i];
            }
            prefixMax[i] = max;
            suffixMax[i] = nums[^(nums.Length-i)..^0].Max();
        }
        long result = 0;
        for(var j = 1; j < nums.Length - 1; j++)
        {    
            var calc = (prefixMax[j - 1] - nums[j]) * suffixMax[j+1];
            if(calc > result)
            {
                result = calc;
            }   
        }
        return result;
    }
}