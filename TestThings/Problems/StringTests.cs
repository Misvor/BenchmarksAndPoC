using ConsoleApp1.Problems;

namespace TestThings.Problems;


[TestClass]
public class StringTests
{
    [TestMethod]
    [DynamicData(nameof(AdditionalData), DynamicDataSourceType.Method)]
    public void TestStringsClose(string word1, string word2, bool result)
    {
        var executor = new StringDifference();

        var actual = executor.CloseStrings(word1, word2);

        Assert.AreEqual(result, actual);
    }

    public static IEnumerable<object[]> AdditionalData()
    {
        yield return new object[]
        {
            "cabbba", "caabbb", true
        };
        yield return new object[]
        {
            "a", "aa", false
        };
        yield return new object[]
        {
            "abc", "bca", true
        };
        yield return new object[]
        {
            "uau", "ssx", false
        };
        yield return new object[]
        {
            "ssx", "uau", false
        };

    }
}