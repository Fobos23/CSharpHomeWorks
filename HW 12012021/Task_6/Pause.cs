using System.Threading;

namespace HW_12012021.Task_6
{
    public static class Pause
    {
        private const int MillisecondsToSecond = 1000;
        private const int MillisecondsToMinute = 60 * MillisecondsToSecond;
        
        public static void SecondsTimeout(int seconds)
        {
            Thread.Sleep(seconds * MillisecondsToSecond);
        }
        
        public static void MinutesTimeout(int minutes)
        {
            Thread.Sleep(minutes * MillisecondsToMinute);
        }
    }
}