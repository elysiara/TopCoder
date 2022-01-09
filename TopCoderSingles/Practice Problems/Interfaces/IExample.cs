namespace TopCoderSingles.Practice_Problems
{
    public interface IExample<Tinputs, Toutput>
    {
        Tinputs Inputs { get; set; }
        Toutput Output { get; set; }
    }
}