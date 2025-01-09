namespace ParallelThread.Services
{
    public class DatabaseMock : IDatabase
    {
        public string GetBigData()
        {
            Thread.Sleep(3000);
            return Guid.NewGuid().ToString();
        }
    }
}
