using System;
using System.Threading;
using System.Threading.Tasks;

namespace TopCoderSingles.Practice_Problems
{
    public class WidgetRepairs : IDisplayableProblem, ITestableExamples<(int[] arrivals, int numPerDay), int>
    {
        public string Name => "Widget Repairs";
        public string Link => "https://arena.topcoder.com/#/u/practiceCode/1262/1270/1346/2/1262";
        public string CodeAsString => @"            public int days(int[] arrivals, int numPerDay)
            {
                // Initialise the counters
                int days = 0;
                int backlog = 0;

                // Check whether the shop is working on each day that they recieve widgets
                foreach (int repair in arrivals)
                {
                    if (repair != 0 || backlog != 0)
                    {
                        backlog += repair - numPerDay;
                        // Do not allow a negative backlog - you can't be repairing what hasn't arrived!
                        if (backlog < 0) { backlog = 0; }
                        days++;
                    }
                }
                // Once all widgets are recieved, calculate the number of days required to work through the backlog
                while (backlog > 0)
                {
                    backlog -= numPerDay;
                    days++;
                }
                return days;
            }
";

        public GenericTester<(int[] arrivals, int numPerDay), int> WidgetRepairsTester = new GenericTester<(int[] arrivals, int numPerDay), int>();
        public async Task<string> TestExamplesOnceTask(CancellationToken token, IProgress<int> progress = null)
        {
            return await WidgetRepairsTester.TestExamplesOnceTask(this, token, progress);
        }
        public async Task<string> TestExamplesForAverageTask(CancellationToken token, IProgress<int> progress = null)
        {
            return await WidgetRepairsTester.TestExamplesForAverageTask(this, token, progress);
        }

        public IExample<(int[] arrivals, int numPerDay), int>[] Examples => new GenericExample<(int[] arrivals, int numPerDay), int>[]
        {
            new GenericExample<(int[] arrivals, int numPerDay), int>((new int[]{ 10, 0, 0, 4, 20 },8),6),
            new GenericExample<(int[] arrivals, int numPerDay), int>((new int[]{ 0, 0, 0 },10),0),
            new GenericExample<(int[] arrivals, int numPerDay), int>((new int[]{ 100, 100 },10),20),
            new GenericExample<(int[] arrivals, int numPerDay), int>((new int[]{ 27, 0, 0, 0, 0, 9 },9),4),
            new GenericExample<(int[] arrivals, int numPerDay), int>((new int[]{ 6, 5, 4, 3, 2, 1, 0, 0, 1, 2, 3, 4, 5, 6 },3),15)
        };
        public bool TestExample(IExample<(int[] arrivals, int numPerDay), int> example)
        {
            return example.Output.Equals(Days(example.Inputs.arrivals, example.Inputs.numPerDay));
        }
        public int Days(int[] arrivals, int numPerDay)
        {
            // Initialise the counters
            int days = 0;
            int backlog = 0;

            // Check whether the shop is working on each day that they recieve widgets
            foreach (int repair in arrivals)
            {
                if (repair != 0 || backlog != 0)
                {
                    backlog += repair - numPerDay;
                    // Do not allow a negative backlog - you can't be repairing what hasn't arrived!
                    if (backlog < 0) { backlog = 0; }
                    days++;
                }
            }
            // Once all widgets are recieved, calculate the number of days required to work through the backlog
            while (backlog > 0)
            {
                backlog -= numPerDay;
                days++;
            }
            return days;
        }
    }
}