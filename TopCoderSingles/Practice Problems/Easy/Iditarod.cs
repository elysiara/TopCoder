using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TopCoderSingles.Practice_Problems
{
    public class Iditarod : IDisplayableProblem, ITestableExamples<string[], int>
    {
        public string Name => "Iditarod";
        public string Link => "https://arena.topcoder.com/#/u/practiceCode/1281/1536/1647/1/1281";
        public string CodeAsString => @"        public int avgMinutes(string[] times)
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

        public GenericTester<string[], int> IditarodTester = new GenericTester<string[], int>();
        public async Task<string> TestExamplesOnceTask(CancellationToken token, IProgress<int> progress = null)
        {
            return await IditarodTester.TestExamplesOnceTask(this, token, progress);
        }
        public async Task<string> TestExamplesForAverageTask(CancellationToken token, IProgress<int> progress = null)
        {
            return await IditarodTester.TestExamplesForAverageTask(this, token, progress);
        }

        public IExample<string[], int>[] Examples => new GenericExample<string[], int>[]
        {
            new GenericExample<string[], int>(new string[]{"12:00 PM, DAY 1","12:01 PM, DAY 1"},241),
            new GenericExample<string[], int>(new string[]{"12:00 AM, DAY 2"},960),
            new GenericExample<string[], int>(new string[]{"02:00 PM, DAY 19","02:00 PM, DAY 20", "01:58 PM, DAY 20"},27239)
        };
        public bool TestExample(IExample<string[], int> example)
        {
            return example.Output.Equals(AvgMinutes(example.Inputs));
        }
        public int AvgMinutes(string[] times)
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