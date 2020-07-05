using System;
using System.Threading;
using TopCoderSingles.Helper;
using TopCoderSingles.Practice_Problems;

namespace TopCoderSingles
{
    public class ViewModel : ObservableProperty
    {
        #region Template
        #endregion

        #region Fields

        private string _DisplayText;
        private string[] _PracticeProblems;
        private int _SelectedProblemIndex;
        private bool _progressVisibility;
        private int _progressPercent;

        private bool canDoSomething;
        private bool canCancel;

        private Progress<int> progress;
        private CancellationTokenSource tokenSource = null;

        #endregion

        #region ObservableProperties

        public string DisplayText
        {
            get { return _DisplayText; }
            set
            {
                if (_DisplayText != value)
                {
                    _DisplayText = value;
                    OnPropertyChanged(nameof(DisplayText));
                }
            }
        }

        public string[] PracticeProblems
        {
            get { return _PracticeProblems; }
            set
            {
                if (_PracticeProblems != value)
                {
                    _PracticeProblems = value;
                    OnPropertyChanged(nameof(PracticeProblems));
                }
            }
        }

        public int SelectedProblemIndex
        {
            get { return _SelectedProblemIndex; }
            set
            {
                if (_SelectedProblemIndex != value)
                {
                    _SelectedProblemIndex = value;
                    OnPropertyChanged(nameof(SelectedProblemIndex));
                }
            }
        }

        public bool progressVisibility
        {
            get { return _progressVisibility; }
            set
            {
                if (_progressVisibility != value)
                {
                    _progressVisibility = value;
                    OnPropertyChanged(nameof(progressVisibility));
                }
            }
        }
        public int progressPercent
        {
            get { return _progressPercent; }
            set
            {
                if (_progressPercent != value)
                {
                    _progressPercent = value;
                    OnPropertyChanged(nameof(progressPercent));
                }
            }
        }

        #endregion

        #region Constructor

        public ViewModel()
        {
            DisplayText = "Welcome to my TopCoder Arena Practice Problems solutions!\r\nSelect a problem and click run to test.\r\n\r\n";
            PracticeProblems = new string[]
            {
                "Subsitute",
                "Turret Defense",
                "Lexer",
                "Widget Repairs",
                "Interesting Digits",
                "Whisper",
                "Iditarod",
                "Bullets",
                "Street Parking",
                "ABBA"
            };
            SelectedProblemIndex = 0;

            canDoSomething = true;
            canCancel = false;
            progressVisibility = false;

            progress = new Progress<int>(percent =>
            {
                progressPercent = percent;
            });

            ShowDefinition = new Command(ShowProblemDefinition, () => { return canDoSomething; });
            ShowCode = new Command(ShowProblemCode, () => { return canDoSomething; });
            RunOnce = new Command(RunProblemOnce, () => { return canDoSomething; });
            RunforAverage = new Command(RunProblemforAverage, () => { return canDoSomething; });
            Cancel = new Command(CancelProblem, () => { return canCancel; });
        }

        #endregion

        #region Public Commands

        public Command ShowDefinition { get; private set; }
        public Command ShowCode { get; private set; }
        public Command RunOnce { get; private set; }
        public Command RunforAverage { get; private set; }
        public Command Cancel { get; private set; }

        #endregion

        #region Private Methods

        private async void ShowProblemDefinition()
        {
            ProblemBase problem = GetProblemFromIndex(SelectedProblemIndex);
            DisplayText = $"{problem.Name}\r\n\r\nOpening page {problem.Link}\r\n\r\n";
            await Windows.System.Launcher.LaunchUriAsync(new Uri(problem.Link));
        }

        private void ShowProblemCode()
        {
            ProblemBase problem = GetProblemFromIndex(SelectedProblemIndex);
            DisplayText = $"{problem.Name}\r\n\r\n{problem.CodeAsString}";
        }

        private async void RunProblemOnce()
        {
            canDoSomething = false;
            canCancel = true;
            progressVisibility = true;

            tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            ProblemBase problem = GetProblemFromIndex(SelectedProblemIndex);
            DisplayText = $"{problem.Name}\r\n\r\nRunning each example once:\r\n\r\n";

            try
            {
                await problem.TestExamplesOnceTask(token, progress);
                DisplayText += problem.answer;
            }

            catch (OperationCanceledException oce)
            {
                DisplayText += $"{oce.Message}\r\n";
            }

            canDoSomething = true;
            canCancel = false;
            progressVisibility = false;
        }

        private async void RunProblemforAverage()
        {
            canDoSomething = false;
            canCancel = true;
            progressVisibility = true;

            tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            ProblemBase problem = GetProblemFromIndex(SelectedProblemIndex);
            DisplayText = $"{problem.Name}\r\n\r\nRunning each example multiple times to average:\r\n\r\n";

            try
            {
                await problem.TestExamplesForAverageTask(token, progress);
                DisplayText += problem.answer;
            }

            catch (OperationCanceledException oce)
            {
                DisplayText += $"{oce.Message}\r\n";
            }

            canDoSomething = true;
            canCancel = false;
            progressVisibility = false;
        }

        private void CancelProblem()
        {
            if (tokenSource != null)
            {
                tokenSource.Cancel();
            }
        }

        private ProblemBase GetProblemFromIndex(int Index)
        {
            switch (Index)
            {
                case 0:
                    return new Substitute();
                case 1:
                    return new TurretDefense();
                case 2:
                    return new Lexer();
                case 3:
                    return new WidgetRepairs();
                case 4:
                    return new InterestingDigits();
                case 5:
                    return new Whisper();
                case 6:
                    return new Iditarod();
                case 7:
                    return new Bullets();
                case 8:
                    return new StreetParking();
                case 9:
                    return new ABBA();
                default:
                    DisplayText += "How did you get here? This problem doesn't exist!";
                    DisplayText += "\r\n";
                    return null;
            }
        }

        #endregion
    }
}