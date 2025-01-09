using ConsoleApp1;
using ConsoleApp1.Problems;

namespace TestThings.Problems;

[TestClass]
public class Schedule
{
    [TestMethod]
    [DynamicData(nameof(TestData), DynamicDataSourceType.Method)]
    public void CheckSchedule(int numDoors, int[][] locks, bool expResult)
    {
        //Arrange
        var worker = new ConfusionExam();

        //Act
        var result = worker.CanFinish(numDoors, locks);
        //Assert
        
        Assert.AreEqual(result, expResult);
    }

    static IEnumerable<object[]> TestData()
    {
        return new[]
        {
            new object[] { 4, new int[][] { new[] { 1, 0 }, new[] { 0, 1 }, new[] { 2, 0 }, new[] { 3, 0 } }, false },
            new object[] { 20, new int[][] { new[] { 0, 10 }, new[] { 3, 18 }, new[] { 5, 5 }, new[] { 6, 11 }
                , new[] { 11, 14 }, new[] { 13, 1 }, new[] { 15, 1 }, new[] { 17, 4 } }, false },
            new object[] { 4, new int[][] { new[] { 1, 0 }, new[] { 3, 2 }, new[] { 2, 0 }, new[] { 3, 0 } }, true },
            new object[] { 2, new int[][] { new[] { 1, 0 }, new[] { 0, 1 }}, false},
            new object[] { 1, new int[][] { new[] { 1, 0 }}, true}
        };

    }
    
}