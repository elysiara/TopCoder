namespace TopCoderSingles.Practice_Problems
{
    public interface ITestableExamples<Tinput, Toutput>
    {
        IExample<Tinput, Toutput>[] Examples { get; }
        bool TestExample(IExample<Tinput, Toutput> example);
    }
}