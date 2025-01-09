namespace ConsoleApp1.Problems;

public class DivIntervals
{
    public int MinGroups(int[][] intervals)
    {
        var occ = new int [intervals.Length];
        Array.Fill(occ, 0);
        
        for(var i = 0; i < intervals.Length; i++)
        {
            for (var j = i + 1; j < intervals.Length; j++)
            {
                if (intervals[i][1] >= intervals[j][0] && intervals[i][0] <= intervals[j][1])
                {
                    occ[i]++;
                    occ[j]++;
                }
            }
        }

        return occ.Max();
    }
}