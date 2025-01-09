using Microsoft.Diagnostics.Tracing.Parsers.IIS_Trace;

namespace ConsoleApp1.Problems;

public class BuddyStringsProblem
{
    public bool BuddyStrings(string s, string goal) {
        
        if(s.Length != goal.Length)
        {
            return false;
        }
        var errIndx = -1;
        var errorEngaged = false;

        for(var i = 0; i < s.Length; i++)
        {
            if (s[i] != goal[i])
            {
                if (errIndx == -1)
                {
                    errIndx = i;
                    continue;
                }

                if (s[errIndx] == goal[i] && goal[errIndx] == s[i])
                {
                    if (errorEngaged)
                    {
                        return false;
                    }
                    // it's ok for the 1st time
                    errorEngaged = true;
                    continue;
                }
                
                return false;
            }
        }

        if (errIndx == -1)
        {
            if (goal.Distinct().Count() < goal.Length)
            {
                return true;
            }

            return false;
        }

        return errorEngaged;
    }
}