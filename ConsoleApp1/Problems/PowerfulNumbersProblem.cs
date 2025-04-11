namespace ConsoleApp1.Problems;

public class PowerfulNumbersProblem
{
    public long NumberOfPowerfulInt(long start, long finish, int limit, string s) {
        
        var result = CountPowerful(finish, limit, s) - CountPowerful(start -1, limit, s);
        return result;
    }

    private long CountPowerful(long end, int limit, string s)
    {
        if(end <= 0)
        {
            return 0;
        }
        var suffix = long.Parse(s);
        if(suffix > end)
        {
            return 0;
        } 
        var countToPlay = end.ToString().Length - s.Length;
        if(countToPlay == 0){
            return 1;
        }

        long count = 0;
        for (var i = 0; i < countToPlay; i++)
        {
            long first = end.ToString()[i] - '0';
            if (first > limit)
            {
                count += (long)Math.Pow(limit + 1, countToPlay - i);
                return count;
            }
            {
                count += first * (long)Math.Pow(limit + 1, countToPlay - 1 - i);
            }
        }
        var suffixLengthEnd = long.Parse(new string(end.ToString().TakeLast(s.Length).ToArray()));
        
        if (suffix <= suffixLengthEnd)
        {
            count++;
        }
       
        return count;
    }
}