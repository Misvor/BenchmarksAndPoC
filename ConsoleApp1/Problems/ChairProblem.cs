namespace ConsoleApp1.Problems;

public class ChairProblem
{
    public void Solution()
    {
        int[][] times = new[] { new[] {4,5}, new []{12,13}, new []{5,6}, new []{1,2}, new []{8,9}, new []{9,10}, new []{6,7}, new []{3,4}, new []{7,8}, new []{13,14}
            , new []{15,16} , new []{14,15} , new []{10,11} , new []{11,12} , new []{2,3} , new []{16,17} };

        //var bookedChairs = new Dictionary<int, int>();
        int[] chairs = new int[100000];
        Array.Fill(chairs, 0);
        var bookedChair = chairs.ToList();
        var alreadyLeft = 0;
        var targetFriend = 15;
        var targetArr = times[targetFriend][0];
        Array.Sort(times, (a, b) => a[0] - b[0]);
        for (var i = 0; i < times.Length; i++)
        {
            var freeSlot = bookedChair.IndexOf(bookedChair.First(x => x < times[i][0]));
            bookedChair[freeSlot] = times[i][1];
            if (times[i][0] == targetArr)
            {
                var free = bookedChair.First(x => x <= targetArr);
                Console.WriteLine(freeSlot);
            }
        }
        Console.WriteLine(bookedChair.IndexOf(0));

    }
}