using System;
using System.Threading;
using System.Threading.Tasks;

namespace TopCoderSingles.Practice_Problems
{
    public interface IDisplayableProblem
    {
        string Name { get; }
        string Link { get; }
        string CodeAsString { get; }
        Task<string> TestExamplesOnceTask(CancellationToken token, IProgress<int> progress = null);
        Task<string> TestExamplesForAverageTask(CancellationToken token, IProgress<int> progress = null);
    }
}
