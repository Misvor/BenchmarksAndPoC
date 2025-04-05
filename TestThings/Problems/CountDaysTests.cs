using ConsoleApp1.Problems;

namespace TestThings.Problems;

[TestClass]
public class CountDaysTests
{
    [TestMethod]
    [DynamicData(nameof(AdditionalData), DynamicDataSourceType.Method)]
    public void TestCountDays(int days, int[][] meetings, int result)
    {
        var executor = new CountDaysProblem();
        

        var actual = executor.CountDays(days, meetings);

        Assert.AreEqual(result, actual);
    }

    public static IEnumerable<object[]> AdditionalData()
    {
        yield return new object[]
        {
            10,
            new int[][]
            {
                new []{5,7},
                new []{1,3},
                new []{9,10},
            }, 2
        };
        
        yield return new object[]
        {
            5,
            new int[][]
            {
                new []{2,4},
                new []{1,3},
            }, 1
        }; 
        yield return new object[]
        {
            8,
            new int[][]
            {
                new []{2,3},
                new []{3,5},
                new []{8,8},
            }, 3
        }; 
        yield return new object[]
        {
            519058,
            new int[][]
            {
                new int[]{356831,464237}
                ,new int[] {223514,231054}
                ,new int[] {96523,343641}
                ,new int[] {268562,424875}
                ,new int[] {326127,373583}
                ,new int[] {188237,434756}
                ,new int[] {43513,470790}
                ,new int[] {175810,401109}
                ,new int[] {77811,420784}
                ,new int[] {240781,502808}
                ,new int[] {106265,218104}
                ,new int[] {131272,234230}
                ,new int[] {36860,463755}
                ,new int[] {104169,471814}
                ,new int[] {14515,142438}
                ,new int[] {95915,164209}
                ,new int[] {379103,448682}
                ,new int[] {356386,495618}
                ,new int[] {197542,280585}
                ,new int[] {131693,221958}
                ,new int[] {196787,267642}
                ,new int[] {359941,404618}
                ,new int[] {300273,503490}
                ,new int[] {121638,410936}
                ,new int[] {312432,477376}
                ,new int[] {224415,327704}
                ,new int[] {216348,284348}
                ,new int[] {124805,443137}
                ,new int[] {190232,479226}
                ,new int[] {221114,471952}
                ,new int[] {61049,461116}
                ,new int[] {210661,469585}
                ,new int[] {426001,496194}
                ,new int[] {324278,369762}
                ,new int[] {43958,500214}
                ,new int[] {75619,497716}
                ,new int[] {143018,420516}
                ,new int[] {201628,417338}
                ,new int[] {3301,30471}
                ,new int[] {148169,486045}
                ,new int[] {128899,213620}
                ,new int[] {436267,479577}
                ,new int[] {248215,386675}
                ,new int[] {117746,303464}
                ,new int[] {336439,479824}
                ,new int[] {186105,223363}
                ,new int[] {99652,329184}
                ,new int[] {174768,227370}
                ,new int[] {92364,173577}
                ,new int[] {75588,78602}
                ,new int[] {113276,373747}
                ,new int[] {193801,518316}
                ,new int[] {213351,333025}
                ,new int[] {105075,173001}
                ,new int[] {237566,396809}
                ,new int[] {319467,386398}
                ,new int[] {17667,187308}
                ,new int[] {352446,473595}
                ,new int[] {25205,49239}
                ,new int[] {25817,192938}
                ,new int[] {90881,428903}
                ,new int[] {55151,80455}
                ,new int[] {172723,218763}
                ,new int[] {393992,460329}
                ,new int[] {271118,377804}
                ,new int[] {312094,406742}
                ,new int[] {102271,370994}
            }, 4042
        };
       
    }
}