using ConsoleApp1.Problems;

namespace TestThings.Problems;

[TestClass]
public class HalvesAlikeTests
{
    [TestMethod]
    [DynamicData(nameof(AdditionalData), DynamicDataSourceType.Method)]
    public void TestHalvesAlike(string source, bool result)
    {
        var executor = new StringHalvesAlike();
        

        var actual = executor.HalvesAreAlike(source);

        Assert.AreEqual(result, actual);
    }

    public static IEnumerable<object[]> AdditionalData()
    {
        yield return new object[]
        {
           "SOAAOS", true
        };
        
        yield return new object[]
        {
           "SOAAOA", false
        };
       
    }
}