using System.Diagnostics.CodeAnalysis;

namespace TestThings.Problems;

using ConsoleApp1.Problems;

[TestClass]
public class MaxDiffTreeTests
{
    [TestMethod]
    [DynamicData(nameof(AdditionalData), DynamicDataSourceType.Method)]
    public void TestMaxDiff(int?[] firstNode, int diff)
    {
        var executor = new MaxDiffBinary();

        var Node = CreateNode(firstNode, 0);

        var result = executor.MaxAncestorDiff(Node);

        Assert.AreEqual(result, diff);
    }
    
    [TestMethod]
    [DynamicData(nameof(PseudoPal), DynamicDataSourceType.Method)]
    public void TestPseudoPal(int?[] firstNode, int diff)
    {
        var executor = new MaxDiffBinary();

        var Node = CreateNode(firstNode, 0);

        var result = executor.PseudoPalindromicPaths(Node);

        Assert.AreEqual(result, diff);
    }
    
    [TestMethod]
    [DynamicData(nameof(NonZeroData), DynamicDataSourceType.Method)]
    public void TestNonZeroArr(int[] arr, bool result)
    {
        var executor = new MaxDiffBinary();

        var actual = executor.UniqueOccurrences(arr);

        Assert.AreEqual(actual, result);
    }
[TestMethod]
    [DynamicData(nameof(SeamData), DynamicDataSourceType.Method)]
    public void TestImageSeam(int[][] arr, int result)
    {
        var executor = new MaxDiffBinary();

        var actual = executor.MinFallingPathSum(arr);

        Assert.AreEqual(actual, result);
    }
    
    [TestMethod]
    [DynamicData(nameof(FromStringData), DynamicDataSourceType.Method)]
    public void TestFromString(string source, int result)
    {
        var executor = new MaxDiffBinary();

        var actual = executor.FromString(source);

        Assert.AreEqual(actual, result);
    }
    public static IEnumerable<object[]> FromStringData()
    {
        yield return new object[]
        {
            "12345",
            12345,
        };
       
    }
    
    [TestMethod]
    [DynamicData(nameof(kInverseData), DynamicDataSourceType.Method)]
    public void TestInversePairs(int n, int k, int result)
    {
        var executor = new MaxDiffBinary();

        var actual = executor.KInversePairs(n, k);

        Assert.AreEqual(actual, result);
    }
    public static IEnumerable<object[]> kInverseData()
    {
        yield return new object[]
        {
            3,1,2
        };
        
        yield return new object[]
        {
            10,10,21670
        };
        yield return new object[]
        {
            20,20,106447125
        };
        
        yield return new object[]
        {
            25,25,940454223
        };
        
        yield return new object[]
        {
            1000,1000,663677020
        };
       
    }
    
     [TestMethod]
    [DynamicData(nameof(FootballData), DynamicDataSourceType.Method)]
    public void TestOutOfBoundPaths(int m, int n, int maxMove, int startRow, int startCol, int result)
    {
        var executor = new MaxDiffBinary();

        var actual = executor.FindPaths(m,n,maxMove, startRow, startCol);

        Assert.AreEqual(actual, result);
    }
    public static IEnumerable<object[]> FootballData()
    {
        yield return new object[]
        {
            2,2,2,0,0,
            6,
        };
       
    }

    
    [TestMethod]
    [DynamicData(nameof(MaxLengthData), DynamicDataSourceType.Method)]
    public void TestMaxLength(IList<string> arr, int result)
    {
        var executor = new MaxDiffBinary();

        var actual = executor.MaxLength(arr);

        Assert.AreEqual(actual, result);
    }
    public static IEnumerable<object[]> MaxLengthData()
    {
        yield return new object[]
        {
            new string[] {"un", "iq", "ue"}.ToList(), 4
        };
        
        yield return new object[]
        {
            new string[] {"ab", "abc", "cd"}.ToList(), 4
        }; 
        
        yield return new object[]
        {
            new string[] {"abcdefghijklmnopqrstuvwxyz", "abc", "cd"}.ToList(), 26
        };
        
        yield return new object[]
        {
            new string[] {"dw", "q", "ux", "j", "he", "ev", "ly", "zix", "tth", "x", "t", "r", "ty", "n", "sei", "mb"}.ToList(), 16
        };
        
        yield return new object[]
        {
            new string[] {"fui", "lo", "yr", "i", "hxo", "rou", "q", "spu", "d", "lo", "p", "xjb", "idm", "bwj", "s", "ec"}.ToList(), 17
        };
       
    }
    
    [TestMethod]
    [DynamicData(nameof(MinSubData), DynamicDataSourceType.Method)]
    public void TestMinSub(int[] arr, int result)
    {
        var executor = new MaxDiffBinary();

        var actual = executor.SumSubarrayMins(arr);

        Assert.AreEqual(actual, result);
    }
    public static IEnumerable<object[]> MinSubData()
    {
        yield return new object[]
        {
            new int[] {3,1,2,4}, 17,
        };
        yield return new object[]
        {
            new int[] {11,81,94,43,3}, 444,
        };
        
        yield return new object[]
        {
            new int[] {2,8,9,4,1}, 50,
        };
        
        yield return new object[]
        {
            new int[] {92,80,9,62,49}, 493,
        };
       
        
        yield return new object[]
        {
            new int[] {19,51,4,11,99,20}, 309,
        };
        
        yield return new object[]
        {
            new int[] {1,2,3,10,4}, 40,
        };
        
        yield return new object[]
        {
            new int[] {35,26,60,45,18,48,41,57,51,32}, 1494,
        };
        
        yield return new object[]
        {
            new int[] {1,4,2,5,3,2}, 43,
        };
        
        yield return new object[]
        {
            new int[] {1,4,3,5,2}, 34,
        };
       yield return new object[]
        {
            new int[] {1,4,3,2}, 20,
        };
       
       yield return new object[]
        {
            new int[] {96,36,29,36,95,64,63,72,39,42}, 2221,
        };
       
    }
    
    public int[] FindErrorNums(int[] nums) {
        var sum = new int[nums.Length];
        for(var i = 0; i < nums.Length; i++)
        {
            sum[nums[i]]++; 
        }

        var first = sum.ToList().IndexOf(0);
        var second = sum.ToList().IndexOf(2);
        return new[] { second, first };
    }
    
   

    public static IEnumerable<object[]> AdditionalData()
    {
        yield return new object[]
        {
            new int?[] { 8,3,10,1,6,null,14,null,null,4,7,13 }.ToArray(),
            7,
        };
       
    }
    
    public static IEnumerable<object[]> PseudoPal()
    {
        yield return new object[]
        {
            new int?[] { 2,3,1,3,1,null,1}.ToArray(),
            2,
        };
        
        yield return new object[]
        {
            new int?[] { 9}.ToArray(),
            1,
        };
       
    }
    public static IEnumerable<object[]> NonZeroData()
    {
        yield return new object[]
        {
            new int[] {1,2,2,1,1,3 }, true,
        };
       
    }
    public static IEnumerable<object[]> SeamData()
    {
        yield return new object[]
        {
            new int[][] {new []{2,1,3}, new []{6,5,4}, new []{7,8,9}}, 13,
        };
       
    }
    


    public static TreeNode CreateNode(int?[] source, int nodeValPos)
    {
        var rootNode = new TreeNode();
        rootNode.val = source[nodeValPos].Value;

        while (true)
        {
            var leftNodePos = (nodeValPos) * 2+1;
            if (source.Length > leftNodePos && source[leftNodePos].HasValue)
            {
                rootNode.left = CreateNode(source, leftNodePos);
            }

            var rightNodePos = (nodeValPos + 1) * 2;
            if (source.Length > rightNodePos && source[rightNodePos].HasValue)
            {
                rootNode.right = CreateNode(source, rightNodePos);
            }

            return rootNode;
        }
    } 
    
}