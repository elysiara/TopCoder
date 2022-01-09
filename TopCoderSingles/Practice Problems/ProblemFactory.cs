using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TopCoderSingles.Practice_Problems
{
    public class ProblemFactory
    {
        public IDisplayableProblem GetProblemFromIndex(int Index)
        {
            switch (Index)
            {
                case 0:
                    return new Bullets();
                case 1:
                    return new Iditarod();
                case 2:
                    return new InterestingDigits();
                case 3:
                    return new Lexer();
                case 4:
                    return new StreetParking();
                case 5:
                    return new Substitute();
                case 6:
                    return new TurretDefense();
                case 7:
                    return new Whisper();
                case 8:
                    return new WidgetRepairs();
                case 9:
                    return new Abacus();
                case 10:
                    return new ABBA();
                case 11:
                    return new ATaleOfThreeCities();
                case 12:
                    return new AToughGame();
                default:
                    return null;
            }
        }
    }
}
