namespace TopCoderSingles.Practice_Problems
{
    public class ProblemFactory
    {
        public IDisplayableProblem GetProblemFromEnum(ProblemsList selectedValue)
        {
            switch (selectedValue)
            {
                case ProblemsList.Bullets:
                    return new Bullets();
                case ProblemsList.Iditarod:
                    return new Iditarod();
                case ProblemsList.InterestingDigits:
                    return new InterestingDigits();
                case ProblemsList.Lexer:
                    return new Lexer();
                case ProblemsList.StreetParking:
                    return new StreetParking();
                case ProblemsList.Substitute:
                    return new Substitute();
                case ProblemsList.TurretDefense:
                    return new TurretDefense();
                case ProblemsList.Whisper:
                    return new Whisper();
                case ProblemsList.WidgetRepairs:
                    return new WidgetRepairs();
                case ProblemsList.Abacus:
                    return new Abacus();
                case ProblemsList.ABBA:
                    return new ABBA();
                case ProblemsList.ATaleOfThreeCities:
                    return new ATaleOfThreeCities();
                case ProblemsList.AToughGame:
                    return new AToughGame();
                default:
                    return null;
            }
        }

    }
}