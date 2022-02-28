using System;

namespace TimeExercise
{
    public class Time
    {
        private int minutes;
        private int seconds;
        public Time(int hours, int minutes, int seconds)
        {
            this.Hours = hours;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public int TotalSeconds
        {
            get
            {
                return Seconds + Minutes * 60 + Hours * 60 * 60;
            }
        }

        public int Seconds
        {
            get { return seconds; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException();
                }
                seconds = value;
            }
        }

        public int Minutes
        {
            get { return minutes; }
            set
            {
                if (value > 59 || value < 0)
                {
                    throw new ArgumentException();
                }
                minutes = value;
            }
        }

        public int Hours { get; set; }
    }
}
