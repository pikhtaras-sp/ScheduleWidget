using System;
using ScheduleWidget.Enums;
using ScheduleWidget.TemporalExpressions;

namespace ScheduleWidget.ScheduledEvents.FrequencyBuilder.ConcreteBuilders
{
    public class FloatingYearlyEventBuilder : IEventFrequencyBuilder
    {
        private readonly Event _event;

        public FloatingYearlyEventBuilder(Event aEvent)
        {
            //Assigning default value to year interval if the value is 0.
            if (aEvent.RepeatInterval == 0)
                aEvent.RepeatInterval = 1;

            _event = aEvent;
        }

        /// <summary>
        /// On yearly frequency build an anniversary temporal expression
        /// </summary>
        /// <returns></returns>
        public UnionTE Create()
        {
            var union = new UnionTE();
            if (_event.FrequencyTypeOptions == FrequencyTypeEnum.FloatingYearly)
            {
                if (_event.FloatingAnniversary == null)
                {
                    throw new ApplicationException("Events with a floating yearly frequency requires a floating anniversary.");
                }

                if (_event.FloatingAnniversary.Month < 1 || _event.FloatingAnniversary.Month > 12)
                    throw new ApplicationException("The anniversary month is invalid.");


                if (_event.RepeatInterval > 1 && _event.StartDateTime == null)
                    throw new ApplicationException("Events with a floating yearly repeat interval greater than one, require a start date.");



                union.Add(new FloatingHolidayTE(_event.FloatingAnniversary.Month, _event.FloatingAnniversary.DayOfWeek, _event.FloatingAnniversary.Week));
            }
            return union;
        }
    }
}
