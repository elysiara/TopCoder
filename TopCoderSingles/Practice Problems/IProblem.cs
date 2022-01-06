using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCoderSingles.Practice_Problems
{
    public interface IProblem
    {
        string Name { get; }
        string Link { get; }
        string CodeAsString { get; }
        IExample[] Examples { get; }
    }
}
