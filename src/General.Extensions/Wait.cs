using System;
using System.Diagnostics;
using System.Threading;

namespace General.Extensions
{
    public static class Wait
    {
        public static void For(Func<bool> action, string message = "Time is out!", long timeout = 10000, int interval = 100)
        {
            Exception exception = null;
            var stopwatch = Stopwatch.StartNew();
            while (stopwatch.ElapsedMilliseconds < timeout)
            {
                try
                {
                    if (action())
                    {
                        break;
                    }
                }
                catch (Exception lastException)
                {
                    exception = lastException;
                }
                Thread.Sleep(interval);
            }

            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > timeout)
            {
                throw new TimeoutException($"{message}. Inner Exception: {exception?.Message}", exception);
            }
        }
    }
}