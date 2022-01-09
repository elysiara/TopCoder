using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TopCoderSingles.Helpers;
using TopCoderSingles.Practice_Problems;

namespace TopCoderSingles
{
    public class ViewModel : ObservableProperty
    {
        #region Template
        #endregion

        private ProblemFactory pf = new ProblemFactory();

        #region Fields

        private IDisplayableProblem _SelectedProblem;

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

        public IDisplayableProblem SelectedProblem
        {
            get { return _SelectedProblem; }
            set
            {
                if (_SelectedProblem != value)
                {
                    _SelectedProblem = value;
                    OnPropertyChanged(nameof(SelectedProblem));
                }
            }
        }
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

                    SelectedProblem = pf.GetProblemFromEnum((ProblemsList)value);
                }
            }
        }
        public bool ProgressVisibility
        {
            get { return _progressVisibility; }
            set
            {
                if (_progressVisibility != value)
                {
                    _progressVisibility = value;
                    OnPropertyChanged(nameof(ProgressVisibility));
                }
            }
        }
        public int ProgressPercent
        {
            get { return _progressPercent; }
            set
            {
                if (_progressPercent != value)
                {
                    _progressPercent = value;
                    OnPropertyChanged(nameof(ProgressPercent));
                }
            }
        }

        #endregion

        #region Constructor

        public ViewModel()
        {
            DisplayText = "Welcome to my TopCoder Arena Practice Problems solutions!\r\nSelect a problem and click run to test.\r\n\r\n";

            PracticeProblems = EnumerationExtension.GetEnumDescriptions(typeof(ProblemsList)).ToArray();

            SelectedProblemIndex = 0;
            SelectedProblem = pf.GetProblemFromEnum(0);

            canDoSomething = true;
            canCancel = false;
            ProgressVisibility = false;

            progress = new Progress<int>(percent =>
            {
                ProgressPercent = percent;
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
            DisplayText = $"{SelectedProblem.Name}\r\n\r\nOpening page {SelectedProblem.Link}\r\n\r\n";
            await Windows.System.Launcher.LaunchUriAsync(new Uri(SelectedProblem.Link));
        }

        private void ShowProblemCode()
        {
            DisplayText = $"{SelectedProblem.Name}\r\n\r\n{SelectedProblem.CodeAsString}";
        }

        private async void RunProblemOnce()
        {
            canDoSomething = false;
            canCancel = true;
            ProgressVisibility = true;

            tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            DisplayText = $"{SelectedProblem.Name}\r\n\r\nRunning each example once:\r\n\r\n";

            try
            {
                DisplayText += await Task.Run(() => SelectedProblem.TestExamplesOnceTask(token, progress));
            }

            catch (OperationCanceledException oce)
            {
                DisplayText += $"{oce.Message}\r\n";
            }

            canDoSomething = true;
            canCancel = false;
            ProgressVisibility = false;
        }

        private async void RunProblemforAverage()
        {
            canDoSomething = false;
            canCancel = true;
            ProgressVisibility = true;

            tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            DisplayText = $"{SelectedProblem.Name}\r\n\r\nRunning each example multiple times to average:\r\n\r\n";

            try
            {
                DisplayText += await Task.Run(() => SelectedProblem.TestExamplesForAverageTask(token, progress));
            }

            catch (OperationCanceledException oce)
            {
                DisplayText += $"{oce.Message}\r\n";
            }

            canDoSomething = true;
            canCancel = false;
            ProgressVisibility = false;
        }

        private void CancelProblem()
        {
            if (tokenSource != null)
            {
                tokenSource.Cancel();
            }
        }

        #endregion
    }
}