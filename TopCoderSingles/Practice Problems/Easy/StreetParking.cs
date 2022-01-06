namespace TopCoderSingles.Practice_Problems
{
    public class StreetParking : IProblem
    {
        public string Name => "Street Parking";
        public string Link => "https://arena.topcoder.com/#/u/practiceCode/1280/1635/1753/2/1280";
        public string CodeAsString => @"            public int freeParks(string street)
            {
                int freeParks = 0;

                for (int i = 0; i < street.Length; i++)
                {
                    if (i == 0)
                    {
                        if (testPosition(street, i) && testAhead5m(street, i) && testAhead10m(street, i))
                        {
                            freeParks++;
                        }
                    }
                    else if (i == street.Length - 2)
                    {
                        if (testBehind5m(street, i) && testPosition(street, i) && testAhead5m(street, i))
                        {
                            freeParks++;
                        }

                    }
                    else if (i == street.Length - 1)
                    {
                        if (testBehind5m(street, i) && testPosition(street, i))
                        {
                            freeParks++;
                        }
                    }
                    else
                    {
                        if (testBehind5m(street, i) && testPosition(street, i) && testAhead5m(street, i) && testAhead10m(street, i))
                        {
                            freeParks++;
                        }
                    }
                }
                return freeParks;
            }

            public bool testPosition(string street, int i)
            {
                return street.Substring(i, 1) == "" - "";
            }

    public bool testBehind5m(string street, int i)
    {
        return street.Substring(i - 1, 1) != ""S"";
    }

    public bool testAhead5m(string street, int i)
    {
        return street.Substring(i + 1, 1) != ""S"" && street.Substring(i + 1, 1) != ""B"";
    }

    public bool testAhead10m(string street, int i)
    {
        return street.Substring(i + 2, 1) != ""B"";
    }
";
        public IExample[] Examples => new StreetParkingExample[]
{
            new StreetParkingExample("---B--S-D--S--",4),
            new StreetParkingExample("DDBDDBDDBDD",0),
            new StreetParkingExample("--S--S--S--S--",2),
            new StreetParkingExample("SSD-B---BD-DDSB-----S-S--------S-B----BSB-S--B-S-D",14)
};
        protected class StreetParkingExample : ExampleBase<string, int>
        {
            public StreetParkingExample(string inputs, int correctOutput) : base(inputs, correctOutput)
            {
            }

            public override bool TestExample()
            {
                int output = freeParks(Inputs);
                return (output.Equals(CorrectOutput));
            }

            public int freeParks(string street)
            {
                int freeParks = 0;

                for (int i = 0; i < street.Length; i++)
                {
                    if (i == 0)
                    {
                        if (testPosition(street, i) && testAhead5m(street, i) && testAhead10m(street, i))
                        {
                            freeParks++;
                        }
                    }
                    else if (i == street.Length - 2)
                    {
                        if (testBehind5m(street, i) && testPosition(street, i) && testAhead5m(street, i))
                        {
                            freeParks++;
                        }

                    }
                    else if (i == street.Length - 1)
                    {
                        if (testBehind5m(street, i) && testPosition(street, i))
                        {
                            freeParks++;
                        }
                    }
                    else
                    {
                        if (testBehind5m(street, i) && testPosition(street, i) && testAhead5m(street, i) && testAhead10m(street, i))
                        {
                            freeParks++;
                        }
                    }
                }
                return freeParks;
            }

            public bool testPosition(string street, int i)
            {
                return street.Substring(i, 1) == "-";
            }

            public bool testBehind5m(string street, int i)
            {
                return street.Substring(i - 1, 1) != "S";
            }

            public bool testAhead5m(string street, int i)
            {
                return street.Substring(i + 1, 1) != "S" && street.Substring(i + 1, 1) != "B";
            }

            public bool testAhead10m(string street, int i)
            {
                return street.Substring(i + 2, 1) != "B";
            }

        }
    }
}