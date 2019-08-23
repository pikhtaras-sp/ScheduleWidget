
using System;
using ScheduleWidget.Enums;

namespace ScheduleWidget.ScheduledEvents
{

    [Serializable]
    public class FloatAnniversary
    {
        public DayOfWeekEnum DayOfWeek { get; set; }
        public int Month { get; set; }
        public MonthlyIntervalEnum Week { get; set; }
    }
}
