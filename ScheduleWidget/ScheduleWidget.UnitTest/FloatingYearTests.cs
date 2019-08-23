using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ScheduleWidget.Enums;
using ScheduleWidget.ScheduledEvents;

namespace ScheduleWidget.UnitTest
{
    [TestFixture]
    public class FloatingYearTests
    {
        [Test]
        public void Test1()
        {
            var aEvent = new Event()
            {
                ID = 1,
                Title = "Event 1",
                FrequencyTypeOptions = FrequencyTypeEnum.FloatingYearly,
                FloatingAnniversary = new FloatAnniversary()
                {
                    Month = 9,
                    Week = MonthlyIntervalEnum.Second,
                    DayOfWeek = DayOfWeekEnum.Fri
                }
            };

            var schedule = new Schedule(aEvent);

            Assert.IsTrue(schedule.IsOccurring(new DateTime(2019, 9, 13)));
        }
    }
}
