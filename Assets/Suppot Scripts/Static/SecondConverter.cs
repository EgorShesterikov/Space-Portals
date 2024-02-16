namespace SupportScipts
{
    public static class SecondConverter
    {
        public static string ConvertSecondInTimeFormat(int second)
        {
            int hour = 0;
            int minute = 0;

            for (; second >= 3600; second -= 3600)
                hour++;

            for (; second >= 60; second -= 60)
                minute++;

            return $"{hour:00}:{minute:00}:{second:00}";
        }
    }
}
