using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
    using System;

    using NUnit.Framework;

    using Sisyphus.Core;

    [Binding]
    public class DateTimeSteps
    {
        [Given(@"I have set SisyphusDateTime to TestDateTime")]
        public void GivenIHaveSetSisyphusDateTimeToTestDateTime()
        {
            SisyphusDateTime.DateTimeAdapter = new TestDateTimeAdapter();
        }

        [Given(
            @"I have set the date to year ""(.*)"" Month ""(.*)"" Day ""(.*)"" hour ""(.*)"" minute ""(.*)"" second ""(.*)"" millisecond ""(.*)"""
            )]
        [When(
            @"I have set the date to year ""(.*)"" Month ""(.*)"" Day ""(.*)"" hour ""(.*)"" minute ""(.*)"" second ""(.*)"" millisecond ""(.*)"""
            )]
        public void GivenIHaveSetTheDatetoYearMonthDayHourMinuteSecondMillisecond(
            int year,
            int month,
            int day,
            int hour,
            int min,
            int sec,
            int mili)
        {
            var adapter = (TestDateTimeAdapter)SisyphusDateTime.DateTimeAdapter;
            var date = new DateTime(year, month, day, hour, min, sec, mili);
            adapter.Now = date;
        }

        [When(
            @"I increment THe datetime by year ""(.*)"" month ""(.*)"" day ""(.*)"" hour ""(.*)"" minute ""(.*)"" second ""(.*)"" millisecond ""(.*)"""
            )]
        public void WhenIIncrementTHeDatetimeByYearMonthDayHourMinuteSecondMillisecond(
            int year,
            int month,
            int day,
            int hour,
            int min,
            int sec,
            int mili)
        {
            var adapter = (TestDateTimeAdapter)SisyphusDateTime.DateTimeAdapter;
            var newval =
                adapter.Now.AddYears(year)
                    .AddMonths(month)
                    .AddDays(day)
                    .AddHours(hour)
                    .AddMinutes(min)
                    .AddSeconds(sec)
                    .AddMilliseconds(mili);

            adapter.Now = newval;
        }

        [Then(
            @"I expect the date to be year ""(.*)"" Month ""(.*)"" Day ""(.*)"" hour ""(.*)"" minute ""(.*)"" second ""(.*)"" millisecond ""(.*)"""
            )]
        public void ThenIExpectTheDateToBeYearMonthDayHourMinuteSecondMillisecond(
            int year,
            int month,
            int day,
            int hour,
            int min,
            int sec,
            int mili)
        {
            var adapter = (TestDateTimeAdapter)SisyphusDateTime.DateTimeAdapter;
            var date = new DateTime(year, month, day, hour, min, sec, mili);
            Assert.AreEqual(date, adapter.Now);
        }
    }
}
