using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TopCoderSingles.Practice_Problems
{
    public class Iditarod : ProblemBase
    {
        public override string Name => "Iditarod";

        public override string Link => "https://arena.topcoder.com/#/u/practiceCode/1281/1536/1647/1/1281";

        public override string CodeAsString => @"        public int avgMinutes(string[] times)
        {
            DateTime startDateTime = DateTime.ParseExact(\""08:00 AM, DAY 1"",""hh:mm tt, 'DAY' d"", CultureInfo.CurrentCulture);

            List<double> timesMinutes = new List<double>();

            foreach (string time in times)
            {
                DateTime finishDateTime = DateTime.ParseExact(time, ""hh:mm tt, 'DAY' d"", CultureInfo.CurrentCulture);
        TimeSpan elapsedTime = finishDateTime - startDateTime;
        timesMinutes.Add(elapsedTime.TotalMinutes);
            }

    double averageMinutes = timesMinutes.Average();

    // Rounding was forbidden (lol?) so have this instead
    int averageMinutesInt = (int)averageMinutes;
    double fractional = averageMinutes - averageMinutesInt;
            if(fractional >= 0.5) { averageMinutesInt++; }

            return averageMinutesInt;
        }
";

        protected override IExample[] Examples => new IditarodExample[]
        {
            new IditarodExample(new string[]{"12:00 PM, DAY 1","12:01 PM, DAY 1"},241),
            new IditarodExample(new string[]{"12:00 AM, DAY 2"},960),
            new IditarodExample(new string[]{"02:00 PM, DAY 19","02:00 PM, DAY 20", "01:58 PM, DAY 20"},27239)
        };

        protected class IditarodExample : ExampleBase<string[], int>
        {
            public IditarodExample(string[] inputs, int correctOutput) : base(inputs, correctOutput)
            {
            }

            public override bool TestExample()
            {
                int output = avgMinutes(Inputs);
                return (output.Equals(CorrectOutput));
            }

            public int avgMinutes(string[] times)
            {
                DateTime startDateTime = DateTime.ParseExact("08:00 AM, DAY 1", "hh:mm tt, 'DAY' d", CultureInfo.CurrentCulture);

                List<double> timesMinutes = new List<double>();

                foreach (string time in times)
                {
                    DateTime finishDateTime = DateTime.ParseExact(time, "hh:mm tt, 'DAY' d", CultureInfo.CurrentCulture);
                    TimeSpan elapsedTime = finishDateTime - startDateTime;
                    timesMinutes.Add(elapsedTime.TotalMinutes);
                }

                double averageMinutes = timesMinutes.Average();

                // Rounding was forbidden (lol?) so have this instead
                int averageMinutesInt = (int)averageMinutes;
                double fractional = averageMinutes - averageMinutesInt;
                if (fractional >= 0.5) { averageMinutesInt++; }

                return averageMinutesInt;
            }

        }
    }
}