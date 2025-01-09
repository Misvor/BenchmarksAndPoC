namespace ConsoleApp1.Problems;

public class ZeroLossOrOnce
{
    public IList<IList<int>> FindWinners(int[][] matches)
    {

        var winnerList = new int[100001];
        var looserList = new int[100001];
        var winners = new List<int>();
        var oncers = new List<int>();
        
        
        for (var i = 0; i < matches.Length; i++)
        {
            winnerList[matches[i][0]]++;
            looserList[matches[i][1]]++;
        }

        for (int i = 0; i < winnerList.Length; i++)
        {
            if (winnerList[i] > 0 && looserList[i] == 0)
            {
                winners.Add(i);
                continue;
            }

            if (looserList[i] == 1)
            {
                oncers.Add(i);
            }
            
        }

        return new List<IList<int>>()
        {
            winners.OrderBy(x=> x).ToList(), oncers.OrderBy(x=> x).ToList()
        };
    } 
}