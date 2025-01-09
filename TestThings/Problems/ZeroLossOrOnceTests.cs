using ConsoleApp1.Problems;

namespace TestThings.Problems;

[TestClass]
public class ZeroLossOrOnceTests
{
        [TestMethod]
        [DynamicData(nameof(AdditionalData), DynamicDataSourceType.Method)]
        public void ZeroOrOneLossTest(int[][] matches, List<List<int>> expResult)
        {
            //Arrange
            var worker = new ZeroLossOrOnce();
    
            //Act
            var result = worker.FindWinners(matches);
            //Assert
            Assert.IsTrue(expResult.SequenceEqual(result));
        }
    
        public static IEnumerable<object[]> AdditionalData()
        {
            yield return new object[]
            {
                new int[][]{ new []{1,3}, new []{2,3}, new []{3,6}, new []{5,6}, new []{5,7}, new []{4,5}, new []{4,8}, new []{4,9}, new []{10,4}, new []{10,9}}
                , new List<List<int>>{ new(){1,2,10}, new(){4,5,7,8}}
            };
            
        }
}