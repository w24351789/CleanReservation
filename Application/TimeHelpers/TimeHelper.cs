using System;

namespace Application.TimeHelpers
{
    public class TimeHelper
    {
        public static int TimeConflict(TimePeriod newAdd, TimePeriod orign)
        {
            int conflict = 0;
            var newStar = TimeInDay(newAdd.StartTime);
            var newEnd = TimeInDay(newAdd.EndTime);
            var orignStar = TimeInDay(orign.StartTime);
            var orignEnd = TimeInDay(orign.EndTime);

            if((newStar >= orignStar && newStar <= orignEnd) || (newEnd >= orignStar && newEnd <= orignEnd))
            {
                conflict++;
            }

            return conflict;
        }
        public static int TimeInDay(DateTime time)
        {
            return time.Hour * 60 + time.Minute;
        }
        
    }
    
}
