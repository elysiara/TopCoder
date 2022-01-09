namespace TopCoderSingles.Practice_Problems
{
    internal class GenericExample<Tinputs, Toutput> : IExample<Tinputs, Toutput>
    {
        private Tinputs _input;
        private Toutput _output;

        public Tinputs Inputs
        {
            get => _input;
            set => _input = value;
        }
        public Toutput Output
        {
            get => _output;
            set => _output = value;
        }

        public GenericExample(Tinputs inputs, Toutput output)
        {
            Inputs = inputs;
            Output = output;
        }
    }
}