using ConsoleApp1.Problems;

namespace TestThings;

[TestClass]
public class TestBuddyStrings
{
    [TestMethod]
    [DataRow("ab","ab", false)]
    [DataRow("aa","aa", true)]
    [DataRow("aba","aab", true)]
    [DataRow("abb","aba", false)]
    [DataRow("ab","ba", true)]
    [DataRow("abcd","badc", false)]
    [DataRow("abaaa","abaaa", true)]
    [DataRow("ab","ca", false)]
    [DataRow("ca","ab", false)]
    public void TestBuddySolution(string goal, string source, bool expResult)
    {
        //Arrange
        var calc = new BuddyStringsProblem();


        //Act
        var result = calc.BuddyStrings(source, goal);

        //Assert
        Assert.AreEqual(result, expResult);
    }
    
}