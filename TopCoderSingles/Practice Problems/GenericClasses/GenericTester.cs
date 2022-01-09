using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TopCoderSingles.Practice_Problems
{
    public class GenericTester<Tinput, Toutput>
    {
        #region Public Tasks

        public async Task<string> TestExamplesOnceTask<T>(T problem, CancellationToken token, IProgress<int> progress = null)
            where T : IDisplayableProblem, ITestableExamples<Tinput, Toutput>
        {
            return await Task.FromResult(TestExamplesOnce(problem, token, progress));
        }

        public async Task<string> TestExamplesForAverageTask<T>(T problem, CancellationToken token, IProgress<int> progress = null)
            where T : IDisplayableProblem, ITestableExamples<Tinput, Toutput>
        {
            return await Task.FromResult(TestExamplesForAverage(problem, token, progress));
        }

        #endregion

        #region Private Methods

        private string TestExamplesOnce<T>(T problem, CancellationToken token, IProgress<int> progress = null)
            where T : IDisplayableProblem, ITestableExamples<Tinput, Toutput>
        {
            string Answer = "";

            List<bool> passesForEachExample = new List<bool>();
            List<long> timesElapsedForEachExample = new List<long>();

            for (int i = 0; i < problem.Examples.Length; i++)
            {
                // Stop if cancelled
                if (token.IsCancellationRequested)
                {
                    return $"{problem.Name} cancelled\r\n";
                }

                // Report Progress
                ReportProgress(i, problem.Examples.Length, progress);

                // Perform code
                Stopwatch watch = new Stopwatch();
                watch.Start();
                bool Pass = problem.TestExample(problem.Examples.ElementAt(i));
                watch.Stop();

                Answer += $"Example {i}: {(Pass ? "Pass" : "Fail")} in {watch.ElapsedMilliseconds} ms\r\n";
                passesForEachExample.Add(Pass);
                timesElapsedForEachExample.Add(watch.ElapsedMilliseconds);
            }
            ReportProgress(100, progress);
            Answer += $"\r\n{passesForEachExample.Count(c => c == true)} passes and {passesForEachExample.Count(c => c == false)} fails in a total of {timesElapsedForEachExample.Sum()} ms\r\n\r\n";
            return Answer;
        }

        private string TestExamplesForAverage<T>(T problem, CancellationToken token, IProgress<int> progress = null)
            where T : IDisplayableProblem, ITestableExamples<Tinput, Toutput>
        {
            string Answer = "";

            List<bool> overallPasses = new List<bool>();
            List<double> overallTimesElapsed = new List<double>();

            for (int i = 0; i < problem.Examples.Length; i++)
            {
                // Stop if cancelled
                if (token.IsCancellationRequested)
                {
                    return $"{problem.Name} cancelled\r\n";
                }

                //Report Progress
                ReportProgress(i, problem.Examples.Length, progress);

                // Perform code
                List<bool> repeatedPasses = new List<bool>();
                List<long> repeatedTimesElapsed = new List<long>();

                for (int j = 0; j < 5; j++)
                {
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    bool Pass = problem.TestExample(problem.Examples.ElementAt(i));
                    watch.Stop();

                    repeatedPasses.Add(Pass);
                    overallPasses.Add(Pass);
                    repeatedTimesElapsed.Add(watch.ElapsedMilliseconds);
                    overallTimesElapsed.Add(watch.ElapsedMilliseconds);
                }
                Answer += $"Example {i}: {repeatedPasses.Count(c => c == true)} passes and {repeatedPasses.Count(c => c == false)} fails in an average of {repeatedTimesElapsed.Average()} ms per run\r\n";
            }
            ReportProgress(100, progress);
            Answer += $"\r\n{overallPasses.Count(c => c == true)} passes and {overallPasses.Count(c => c == false)} fails in a total of {overallTimesElapsed.Sum()} ms for {problem.Examples.Length * 5} runs\r\n\r\n";
            return Answer;
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

    }
}