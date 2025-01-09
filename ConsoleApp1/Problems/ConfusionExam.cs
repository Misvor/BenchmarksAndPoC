using System.Text;

namespace ConsoleApp1.Problems;
using System.Linq;

public class ConfusionExam
{
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        var completed = 0;
        var keys = new List<int>(){-1};        
        var allDoors = new Dictionary<int, int[]>();
        for (var i = 0; i < numCourses; i++)
        {
            allDoors.Add(i, NeedKey(prerequisites, i));
        }

        var length = prerequisites.Length;


        bool[] visitedDoors = new bool[numCourses];
        bool[] recursionStack = new bool[numCourses];
        
        for(var i = 0; i < numCourses; i++)
        {
            if(HasCycle(i, visitedDoors, recursionStack, allDoors))
            {
                return false;
            }
        }
        return true;
    }
    private bool HasCycle(int door, bool[] visitedDoors, bool[] recursionStack, Dictionary<int, int[]> doors)
    {
        recursionStack[door] = true;
        visitedDoors[door] = true;
        if(doors[door].Any())
        {
            foreach(var NestedDoor in doors[door])
            {
                if(recursionStack[NestedDoor] == true)
                {
                    return true;
                }
                if (visitedDoors[NestedDoor])
                {
                    continue;
                }
                {
                    visitedDoors[NestedDoor] = true;
                    if (HasCycle(NestedDoor, visitedDoors, recursionStack, doors))
                    {
                        return true;
                    }
                }
            }
        }

        recursionStack[door] = false;
        return false;
    }
    private int[] NeedKey(int[][] locks, int door)
    {
        return locks.Where(x=> x[0] == door).Select(x=> x[1]).ToArray();
    }

}