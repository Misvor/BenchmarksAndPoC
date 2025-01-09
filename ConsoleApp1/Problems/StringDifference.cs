namespace ConsoleApp1.Problems;

public class StringDifference
{
    public int MinSteps(string s, string t)
    {

        var charS = s.ToCharArray();
        var charT = t.ToCharArray();
       
        var dict = new Dictionary<char, int>();
        var stepsCount = 0;
        for(var i = 0; i < s.Length; i++){

            if (!dict.ContainsKey(charS[i]))
            {
                dict.Add(charS[i], 1);
            }
            else
            {
                dict[charS[i]]++;
            }
            
            if (!dict.ContainsKey(charS[i]))
            {
                dict.Add(charT[i], -1);
            }
            else
            {
                dict[charT[i]]--;
            }
        }

        return dict.Sum(x => Math.Abs(x.Value))/2;

    }
    public int MinSteps1(string s, string t) {  

        var charS = s.ToCharArray().ToList();
        for(var i = 0; i < t.Length; i++)
        {
            charS.Remove(t[i]);
        }

        return charS.Count;
    }
    public bool CloseStrings(string word1, string word2) {
        if (word1.Length != word2.Length)
        {
            return false;
        }
        
        var dict = new int[26];
        var dict1 = new int[26];
        
        for(var i = 0; i < word1.Length; i++)
        {
            dict[word1[i] - 'a']++;
            dict1[word2[i] - 'a']++;
        }

        for (var j = 0; j < 26; j++)
        {
            if (dict[j] != 0 ^ dict1[j] != 0)
            {
                return false;
            }
        }
        
        if (dict1.OrderByDescending(x=> x).SequenceEqual(dict.OrderByDescending(x => x)))
        {
            return true;
        }
        return false;
    }
    
}