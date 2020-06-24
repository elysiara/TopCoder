namespace TopCoderSingles.Practice_Problems
{
    public abstract class ExampleBase<T1, T2> : IExample
    {
        public T1 Inputs;
        public T2 CorrectOutput;

        public ExampleBase(T1 inputs, T2 correctOutput)
        {
            this.Inputs = inputs;
            this.CorrectOutput = correctOutput;
        }

        public abstract bool TestExample();
    }

    public interface IExample
    {
        bool TestExample();
    }
}