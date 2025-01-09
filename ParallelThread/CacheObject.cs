namespace ParallelThread
{
    public record CacheObject
    {
        public CacheObject(string value)
        {
            ExpireTime = DateTime.Now.AddMinutes(5);
            Value = value;
        }

        public DateTime ExpireTime { get; internal set; }
        public string Value { get; internal set; }
    }
}
