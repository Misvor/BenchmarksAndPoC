namespace ParallelThread.Services
{
    public interface IHybridLockCache
    {
        void Set(string data);
        string Get();
    }
}
