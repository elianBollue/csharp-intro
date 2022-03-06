using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockExercise
{
    public class Clock
    {
        private int totalSeconds;
        public Clock(ITimerService ts)
        {
            ts.Tick += OnTick;
        }

        public void OnTick()
        {
            totalSeconds++;

            SecondPassed?.Invoke(totalSeconds);
            HasMinutePassed();
            HasHourPassed();
            HasDayPassed();
        }

        private void HasMinutePassed()
        {
            if(totalSeconds % 60 == 0)
            {
                MinutePassed?.Invoke(totalSeconds / 60);
            }
        }
        private void HasHourPassed()
        {
            if(totalSeconds % (60 * 60) == 0)
            {
                HourPassed?.Invoke(totalSeconds / (60 * 60));
            }
        }
        private void HasDayPassed()
        {
            if (totalSeconds % (60 * 60 * 24) == 0)
            {
                DayPassed?.Invoke(totalSeconds / (60 * 60 * 24));
            }
        }

        public Action<int> SecondPassed;
        public Action<int> MinutePassed;
        public Action<int> HourPassed;
        public Action<int> DayPassed;
    }
}
