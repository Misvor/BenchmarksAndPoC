using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace ConsoleApp1.Problems;

public class MaxDiffBinary
{
    public int maxDiff = 0;

    public int MaxAncestorDiff(TreeNode root)
    {
        GetMaxDif(root);
        return maxDiff;
    }


    public void GetMaxDif(TreeNode node, int rootMax = int.MinValue, int rootMin = int.MaxValue)
    {
        if (node == null)
        {
            return;
        }

        rootMax = node.val > rootMax ? node.val : rootMax;
        rootMin = node.val < rootMin ? node.val : rootMin;

        GetMaxDif(node.left, rootMax, rootMin); // they should not intesect
        GetMaxDif(node.right, rootMax, rootMin);

        if (rootMax - rootMin > maxDiff)
        {
            maxDiff = rootMax - rootMin;
        }

    }

    public bool UniqueOccurrences(int[] arr)
    {
        var occCount = Array.CreateInstance(typeof(int), new int[] { 2000 }, new[] { -1000 });

        for (var i = 0; i < arr.Length; i++)
        {
            var oldVal = (int)occCount.GetValue(arr[i]);
            occCount.SetValue(++oldVal, arr[i]);
        }

        var result = occCount.Cast<int>().Where(x => x != 0);
        if (result.Distinct().Count() != result.Count())
        {
            return false;
        }

        return true;
    }

    public int MinFallingPathSum(int[][] matrix)
    {
        if (matrix.Length == 1)
        {
            return matrix[0].Min();
        }

        for (var i = 0; i < matrix.Length; i++)
        {
            if (i == 0)
            {
                continue;
            }

            for (var j = 0; j < matrix[i].Length; j++)
            {
                if (j == 0 && j != matrix[i].Length - 1)
                {
                    matrix[i][j] = matrix[i][j] + Math.Min(matrix[i - 1][j], matrix[i - 1][j + 1]);
                }
                else if (j == matrix[i].Length - 1)
                {
                    matrix[i][j] = matrix[i][j] + Math.Min(matrix[i - 1][j - 1], matrix[i - 1][j]);
                }
                else
                {
                    var minNeighboor = Math.Min(matrix[i - 1][j - 1], Math.Min(matrix[i - 1][j], matrix[i - 1][j + 1]));
                    matrix[i][j] = matrix[i][j] + minNeighboor;
                }
            }
        }

        return matrix[matrix.Length - 1].Min();
    }
    
    public int MaxLength(IList<string> arr) {
        
        var combinations = Enumerable.Range(0, 1 << arr.Count).Select(index => arr.Where((v, i) => (index & (1 << i)) != 0).ToArray());
        if (arr.Any(x => x.Length == 26))
        {
            return 26;
        }
        var resultingSet = new List<string>();
        var chars = new bool[26];
        
        for (var i = 0; i < arr.Count; i++)
        {
            var canAdd = true;
            var length = arr[i].Length;
            var occured = 0;
            foreach (var item in arr[i])
            {
                if (chars[item - 'a'])
                {
                    canAdd = false;
                    occured++;
                }
            }
            if (canAdd)
            {
                foreach (var item in arr[i])
                {
                    chars[item - 'a'] = true;
                }
                resultingSet.Add(arr[i]);
            }
            else
            {
                if (length > occured) // has new characters
                {
                    foreach (var character in arr[i])
                    {
                        if (chars[character - 'a'])
                        {
                            var original = resultingSet.First(x => x.Contains(character));
                            resultingSet.Remove(original);
                            foreach (var item in original)
                            {
                                chars[item - 'a'] = false;
                            }
                        }
                        chars[character - 'a'] = true;
                    }
                    resultingSet.Add(arr[i]);
                }
            }
        }
        
        return chars.Count(x => x);
    }

    private int paths = 0;
    public int PseudoPalindromicPaths (TreeNode root)
    {
        var startingPath = new int[10];
        AllPaths(root, startingPath);
        return paths;
    }

    private void AllPaths(TreeNode root, int[] start)
    {
        start[root.val]++;
        
        if(root.left != null)
        {
            AllPaths(root.left, start);
        }
        
        if(root.right != null)
        {
            AllPaths(root.right, start);
        }
        
        if(root.left == null && root.right == null)
        {
            //found leave
            if (CanPalyndrome(start))
            {
                paths++;
                start[root.val]--;
                return;
            }
        }

        start[root.val]--;
    }

    private static bool CanPalyndrome(int[] arr)
    {
        if (arr.Sum() % 2 == 0)
        {
            for (var i = 1; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
        }
        else
        {
            var alreadyOneOdd = false;
            for (var i = 1; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    continue;
                }
                else
                {
                    if (!alreadyOneOdd)
                    {
                        alreadyOneOdd = true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }
    
     public int LongestCommonSubsequence(string text1, string text2)
     {
         var dp = new int[text1.Length + 1, text2.Length + 1];

         for (var i = 1; i < text1.Length; i++)
         {
             for (var j = 1; j < text2.Length; j++)
             {
                 if (text1[i] == text2[j])
                 {
                     dp[i, j] = dp[i - 1, j - 1] + 1;
                 }
                 else
                 {
                     dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                 }
             }
         }

         return dp[text1.Length, text2.Length];
     }

     public int FromString(string source)
     {
         var result = 0;
         var decimalPart = 0;
         for (var i = source.Length - 1; i >= 0; i--)
         {
             result += (int)(source[i] - '0') * (int)Math.Pow(10, decimalPart);
             decimalPart++;
         }

         return result;
     }
    
    public int SumSubarrayMins(int[] arr)
    {
        long sum = arr[0];
        int minPos = 0;
        var minimum = arr[0];
        long prevSum = arr[0];

        for (var i = 1; i < arr.Length; i++)
        {
            long addition = 0;
            if (arr[i] >= arr[i - 1])
            {
                prevSum += arr[i];
            }
            else
            {
                if (minimum >= arr[i])
                {
                    minimum = arr[i];
                    minPos = i;
                    prevSum = minimum * (i+1);
                }
                else
                {
                    prevSum += arr[i];
                    prevSum = prevSum + arr[i] - arr[i - 1];
                    var localMin = 0;
                    for(var j = i - 1; j > minPos; j--)
                    {
                        if (localMin != 0)
                        {
                            if (arr[j] < localMin)
                            {
                                localMin = arr[j];
                                if (localMin < arr[i])
                                {
                                    break;
                                }
                            }
                            prevSum = prevSum - localMin + arr[i];
                        }else
                        if (arr[j] < arr[j - 1])
                        {
                            localMin = arr[j];
                        } else
                        if(arr[i] < arr[j-1])
                        {
                            prevSum = prevSum - arr[j-1] + arr[i];
                        } else
                        {
                            break;
                        }
                    }   
                }
            }

            sum += prevSum;
        }

        int result = (int)(sum % 1000000007);
        
        return result;
    }
    
    public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
    {
        
        var cache = new long[m, n, maxMove + 1];
        var result = Paths(startRow, startColumn, maxMove, cache , m, n);
        return (int)result % 1000000007;
    }
    
    private int mod = 1000000007;
    public int KInversePairs(int n, int k) { 
        var dp = new int[n+1,k+1];
        MultidimensionalSseFill(n+1, k+1, dp);
        
        return Pairs(n,k, dp);
    }

    private int Pairs(int n, int k, int[,] dp)
    {
        if( n == 1){
            if(k == 0)
            {
                return 1;
            }
            {
                return 0;
            }
        }
        
        if(k < 0)
        {
            return 0;
        }

        if(dp[n,k] != -1)
        {
            return dp[n,k];
        }        

        dp[n,k] = (Pairs(n-1, k, dp) + Pairs(n, k-1, dp)) % mod;      
        dp[n,k] = (dp[n,k] - Pairs(n-1, k - n, dp)) % mod;  

        if(dp[n,k] < 0){
            dp[n,k] = dp[n,k] += mod;
        }
        return dp[n,k];
    }
    public unsafe void MultidimensionalSseFill(int length1, int length2, int[,] arr)
    {
        var vectorMinusOne = Vector128.Create(-1);

        fixed (int* a = &arr[0, 0])
        {
            int* b = a;

            int i = 0;
            int size = Vector128<double>.Count;

            int length = length1 * length2;
            for (; i < (length & ~(int)15); i += 16)
            {
                Sse2.Store(b+size*0, vectorMinusOne);
                Sse2.Store(b+size*1, vectorMinusOne);
                Sse2.Store(b+size*2, vectorMinusOne);
                Sse2.Store(b+size*3, vectorMinusOne);
                Sse2.Store(b+size*4, vectorMinusOne);
                Sse2.Store(b+size*5, vectorMinusOne);
                Sse2.Store(b+size*6, vectorMinusOne);
                Sse2.Store(b+size*7, vectorMinusOne);
                b += size*8;
            }
            for (; i < (length & ~7); i += 8)
            {
                Sse2.Store(b+size*0, vectorMinusOne);
                Sse2.Store(b+size*1, vectorMinusOne);
                Sse2.Store(b+size*2, vectorMinusOne);
                Sse2.Store(b+size*3, vectorMinusOne);
                b += size*4;
            }
            for (; i < (length & ~3); i += 4)
            {
                Sse2.Store(b+size*0, vectorMinusOne);
                Sse2.Store(b+size*1, vectorMinusOne);
                b += size*2;
            }
            for (; i < length; i++)
            {
                *b++ = -1;
            }
        }
    }

    private long Paths(int x, int y, int remainingMoves, long[,,] cache, int maxX, int maxY)
    {
        if (x < 0 || y < 0 || x == maxX || y == maxY)
        {
            return 1; // the end
        }

        if (remainingMoves < x && remainingMoves < y && x + remainingMoves < maxX && y + remainingMoves < maxY)
        {
            return 0; //stuck
        }

        if (remainingMoves == 0)
        {
             return cache[x, y, remainingMoves];
        }

        if (cache[x, y, remainingMoves] == 0)
        {
            var down =  Paths(x + 1, y,remainingMoves - 1, cache, maxX, maxY);
            var up = Paths(x - 1, y,remainingMoves - 1, cache, maxX, maxY);
            var right =  Paths(x, y + 1,remainingMoves - 1, cache, maxX, maxY);
            var left =  Paths(x, y - 1,remainingMoves - 1, cache, maxX, maxY);
            cache[x, y, remainingMoves] += up + down + right + left;
        }

        return cache[x, y, remainingMoves];
    }
    
}
