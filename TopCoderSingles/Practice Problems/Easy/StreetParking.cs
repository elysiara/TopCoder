using System;
using System.Threading;
using System.Threading.Tasks;

namespace TopCoderSingles.Practice_Problems
{
    public class StreetParking : IDisplayableProblem, ITestableExamples<string, int>
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

        private GenericTester<string, int> StreetParkingTester = new GenericTester<string, int>();
        public async Task<string> TestExamplesOnceTask(CancellationToken token, IProgress<int> progress = null)
        {
            return await StreetParkingTester.TestExamplesOnceTask(this, token, progress);
        }
        public async Task<string> TestExamplesForAverageTask(CancellationToken token, IProgress<int> progress = null)
        {
            return await StreetParkingTester.TestExamplesForAverageTask(this, token, progress);
        }

        public IExample<string, int>[] Examples => new GenericExample<string, int>[]
{
            new GenericExample<string, int>("---B--S-D--S--",4),
            new GenericExample<string, int>("DDBDDBDDBDD",0),
            new GenericExample<string, int>("--S--S--S--S--",2),
            new GenericExample<string, int>("SSD-B---BD-DDSB-----S-S--------S-B----BSB-S--B-S-D",14)
};
        public bool TestExample(IExample<string, int> example)
        {
            return example.Output.Equals(FreeParks(example.Inputs));
        }
        private int FreeParks(string street)
        {
            int freeParks = 0;

            for (int i = 0; i < street.Length; i++)
            {
                if (i == 0)
                {
                    if (TestPosition(street, i) && TestAhead5m(street, i) && TestAhead10m(street, i))
                    {
                        freeParks++;
                    }
                }
                else if (i == street.Length - 2)
                {
                    if (TestBehind5m(street, i) && TestPosition(street, i) && TestAhead5m(street, i))
                    {
                        freeParks++;
                    }

                }
                else if (i == street.Length - 1)
                {
                    if (TestBehind5m(street, i) && TestPosition(street, i))
                    {
                        freeParks++;
                    }
                }
                else
                {
                    if (TestBehind5m(street, i) && TestPosition(street, i) && TestAhead5m(street, i) && TestAhead10m(street, i))
                    {
                        freeParks++;
                    }
                }
            }
            return freeParks;
        }
        private bool TestPosition(string street, int i)
        {
            return street.Substring(i, 1) == "-";
        }
        private bool TestBehind5m(string street, int i)
        {
            return street.Substring(i - 1, 1) != "S";
        }
        private bool TestAhead5m(string street, int i)
        {
            return street.Substring(i + 1, 1) != "S" && street.Substring(i + 1, 1) != "B";
        }
        private bool TestAhead10m(string street, int i)
        {
            return street.Substring(i + 2, 1) != "B";
        }
    }
}