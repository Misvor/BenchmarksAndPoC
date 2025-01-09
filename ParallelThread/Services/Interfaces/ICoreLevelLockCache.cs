namespace ParallelThread.Services
{
    public interface ICoreLevelLockCache
    {
        void Set(string data);
        string Get();
    }
}
