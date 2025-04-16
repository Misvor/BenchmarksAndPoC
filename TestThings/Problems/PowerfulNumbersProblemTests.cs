using ConsoleApp1.Problems;

namespace TestThings.Problems;
[TestClass]
public class PowerfulNumbersProblemTests
{
    [TestMethod]
    [DataRow(1, 6000, 4, "124", 5)]
    [DataRow(15, 215, 6, "10", 2)]
    [DataRow(1000, 2000, 4, "3000", 0)]
    [DataRow(20, 1159, 5, "20", 8)]
    [DataRow(1, 971, 9, "72", 9)]
    [DataRow(15398, 1424153842, 8, "101", 783790)]
    [DataRow(1, 2000, 8, "1", 162)]
    [DataRow(1, 971, 9, "71", 10)]
    [DataRow(697662853, 11109609599885, 6, "5", 16135677999)]
    [DataRow(1, 1000000000000000, 5, "1000000000000000", 1)]
    public void TestNumberOfPowerfulInt(long start, long end, int limit, string suffix, long result)
    {
        var executor = new PowerfulNumbersProblem();

        var actual = executor.NumberOfPowerfulInt(start, end, limit, suffix);

        Assert.AreEqual(result, actual);
    }

    private long FastPower(long number, long power)
    {
        long result = 1;
        var multiplier = 1;
        while (power > 0)
        {
            if ((power & 1) == 1)
            {
                result *= multiplier;
            }
            multiplier *= multiplier;
            power >>= 1;
        }
        return result;
    }

}