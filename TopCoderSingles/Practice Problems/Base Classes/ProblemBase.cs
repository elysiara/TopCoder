using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TopCoderSingles.Practice_Problems
{
    public abstract class ProblemBase
    {
        #region Template
        #endregion

        #region Public Fields

        public string answer = "\r\nYou need to run a test method before this is available.";

        #endregion

        #region Public Tasks

        public async Task TestExamplesOnceTask(CancellationToken token, IProgress<int> progress = null)
        {
            Task task = Task.Run(() => TestExamplesOnce(token, progress));
            await task;
        }

        public async Task TestExamplesForAverageTask(CancellationToken token, IProgress<int> progress = null)
        {
            Task task = Task.Run(() => TestExamplesForAverage(token, progress));
            await task;
        }

        #endregion

        #region Private Methods

        private void TestExamplesOnce(CancellationToken token, IProgress<int> progress = null)
        {
            answer = "";

            List<bool> passesForEachExample = new List<bool>();
            List<long> timesElapsedForEachExample = new List<long>();

            for (int i = 0; i < Examples.Length; i++)
            {
                // Stop if cancelled
                if (token.IsCancellationRequested)
                {
                    answer = $"{Name} cancelled\r\n";
                    return;
                }

                // Report Progress
                ReportProgress(i, Examples.Length, progress);

                // Perform code
                Stopwatch watch = new Stopwatch();
                watch.Start();
                bool Pass = Examples.ElementAt(i).TestExample();
                watch.Stop();

                answer += $"Example {i}: {((Pass == true) ? "Pass" : "Fail")} in {watch.ElapsedMilliseconds} ms\r\n";
                passesForEachExample.Add(Pass);
                timesElapsedForEachExample.Add(watch.ElapsedMilliseconds);
            }
            ReportProgress(100, progress);
            answer += $"\r\n{passesForEachExample.Count(c => c == true)} passes and {passesForEachExample.Count(c => c == false)} fails in a total of {timesElapsedForEachExample.Sum()} ms\r\n\r\n";
        }

        private void TestExamplesForAverage(CancellationToken token, IProgress<int> progress = null)
        {
            answer = "";

            List<bool> overallPasses = new List<bool>();
            List<double> overallTimesElapsed = new List<double>();

            for (int i = 0; i < Examples.Length; i++)
            {
                // Stop if cancelled
                if (token.IsCancellationRequested)
                {
                    answer = $"{Name} cancelled\r\n";
                    return;
                }

                //Report Progress
                ReportProgress(i, Examples.Length, progress);

                // Perform code
                List<bool> repeatedPasses = new List<bool>();
                List<long> repeatedTimesElapsed = new List<long>();

                for (int j = 0; j < 5; j++)
                {
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    bool Pass = Examples.ElementAt(i).TestExample();
                    watch.Stop();

                    repeatedPasses.Add(Pass);
                    overallPasses.Add(Pass);
                    repeatedTimesElapsed.Add(watch.ElapsedMilliseconds);
                    overallTimesElapsed.Add(watch.ElapsedMilliseconds);
                }
                answer += $"Example {i}: {repeatedPasses.Count(c => c == true)} passes and {repeatedPasses.Count(c => c == false)} fails in an average of {repeatedTimesElapsed.Average()} ms per run\r\n";
            }
            ReportProgress(100, progress);
            answer += $"\r\n{overallPasses.Count(c => c == true)} passes and {overallPasses.Count(c => c == false)} fails in a total of {overallTimesElapsed.Sum()} ms for {Examples.Length * 5} runs\r\n\r\n";
        }

        private void ReportProgress(int currentValue, int maxValue, IProgress<int> progress = null)
        {
            if (progress != null)
            {
                double percent = 100 * (double)currentValue / maxValue;
                int nearestPercent = (int)Math.Floor(percent);
                progress.Report(nearestPercent);
            }
        }

        private void ReportProgress(int progressValue, IProgress<int> progress = null)
        {
            if (progress != null)
            {
                progress.Report(progressValue);
            }
        }

        #endregion

        #region Abstract Fields
        public abstract string Name { get; }
        public abstract string Link { get; }

        public abstract string CodeAsString { get; }

        protected abstract IExample[] Examples { get; }

        #endregion
    }
}