namespace DesignPattern.Utility
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// 获取UNIX（秒）
        /// </summary>
        /// <returns></returns>
        public static long GetUnixTimeStamp(this DateTime datetime)
        {
            return (long)(datetime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }

        /// <summary>
        /// 获取UNIX（毫秒）
        /// </summary>
        /// <returns></returns>
        public static long GetUnixMilTimeStamp(this DateTime datetime)
        {
            return (long)(datetime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }
    }
}
