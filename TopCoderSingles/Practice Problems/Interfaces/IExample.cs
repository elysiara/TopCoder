namespace TopCoderSingles.Practice_Problems
{
    public interface IExample<Tinput, Toutput>
    {
        Tinput Inputs { get; set; }
        Toutput Output { get; set; }
    }
}