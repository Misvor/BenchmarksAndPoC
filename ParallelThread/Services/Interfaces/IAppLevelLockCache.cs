namespace ParallelThread.Services
{
    public interface IAppLevelLockCache
    {
        void Set(string data);
        string Get();
    }
}
