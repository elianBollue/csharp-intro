namespace FormattingExercise
{
    public static class Formatter
    {
        public static string Greet(string name)
        {
            return $"Hello, {name}";
        }
        public static string FormatDate(int day, int month, int year)
        {
            return $"{day.ToString("D2")}/{month.ToString("D2")}/{year}";
        }
    }
}
