using System.ComponentModel;

namespace TopCoderSingles.Practice_Problems
{
    public class Problems
    {
        public enum ProblemsList
        {
            // Easy

            [Description("Bullets")]
            Bullets,
            [Description("Iditarod")]
            Iditarod,
            [Description("Interesting Digits")]
            InterestingDigits,
            [Description("Lexer")]
            Lexer,
            [Description("Street Parking")]
            StreetParking,
            [Description("Substitute")]
            Substitute,
            [Description("Turret Defense")]
            TurretDefense,
            [Description("Whisper")]
            Whisper,
            [Description("Widget Repairs")]
            WidgetRepairs,

            // Medium

            [Description("Abacus")]
            Abacus,
            [Description("ABBA")]
            ABBA,
            [Description("A Tale Of Three Cities")]
            ATaleOfThreeCities,

            // Hard

            [Description("A Tough Game")]
            AToughGame
        }

        public IDisplayableProblem GetProblemFromIndex(int index)
        {
            return GetProblemFromEnum((ProblemsList)index);
        }

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