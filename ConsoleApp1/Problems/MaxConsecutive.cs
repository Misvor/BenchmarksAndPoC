namespace ConsoleApp1.Problems;

public class MaxConsecutive
{
    public int MaxConsecutiveAnswers(string answerKey, int k) {
        
        var firstGroup = 0;
        var maxTrue = 0;
        var maxFalse = 0;
        var longest = 0;
        var lastEncounteredKey = ' ';
        var errCount = 0;
        
        for(var i = 0; i < answerKey.Length; i++)
        {
            if (i == 0)
            {
                lastEncounteredKey = answerKey[i];
                continue;
            }

            if (answerKey[i] != lastEncounteredKey)
            {
                
            }

        }

        return longest;
    }
}