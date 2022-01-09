using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TopCoderSingles.Helpers;
using TopCoderSingles.Practice_Problems;

namespace TopCoderSingles.ViewModels
{
    public class MainPageVM : ObservableProperty
    {
        #region Template
        #endregion

        #region Fields

        private TextDisplayVM _TextDisplayVM;
        private ProgressBarVM _ProgressBarVM;
        private ProblemSelectionVM _ProblemSelectionVM;

        private bool canDoSomething;
        private bool canCancel;

        private CancellationTokenSource tokenSource = null;

        #endregion

        #region ObservableProperties

        public TextDisplayVM TextDisplayViewModel
        {
            get { return _TextDisplayVM; }
            private set
            {
                if (_TextDisplayVM != value)
                {
                    _TextDisplayVM = value;
                    OnPropertyChanged(nameof(TextDisplayViewModel));
                }
            }
        }
        public ProgressBarVM ProgressBarViewModel
        {
            get { return _ProgressBarVM; }
            private set
            {
                if (_ProgressBarVM != value)
                {
                    _ProgressBarVM = value;
                    OnPropertyChanged(nameof(ProgressBarViewModel));
                }
            }
        }
        public ProblemSelectionVM ProblemSelectionViewModel
        {
            get { return _ProblemSelectionVM; }
            private set
            {
                if (_ProblemSelectionVM != value)
                {
                    _ProblemSelectionVM = value;
                    OnPropertyChanged(nameof(ProblemSelectionViewModel));
                }
            }
        }

        #endregion

        #region Constructor

        public MainPageVM()
        {
            TextDisplayViewModel = new TextDisplayVM();
            ProgressBarViewModel = new ProgressBarVM();
            ProblemSelectionViewModel = new ProblemSelectionVM();

            canDoSomething = true;
            canCancel = false;

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
            TextDisplayViewModel.Text = $"{ProblemSelectionViewModel.SelectedProblem.Name}\r\n\r\nOpening page {ProblemSelectionViewModel.SelectedProblem.Link}\r\n\r\n";
            await Windows.System.Launcher.LaunchUriAsync(new Uri(ProblemSelectionViewModel.SelectedProblem.Link));
        }

        private void ShowProblemCode()
        {
            TextDisplayViewModel.Text = $"{ProblemSelectionViewModel.SelectedProblem.Name}\r\n\r\n{ProblemSelectionViewModel.SelectedProblem.CodeAsString}";
        }

        private async void RunProblemOnce()
        {
            canDoSomething = false;
            canCancel = true;
            ProgressBarViewModel.ProgressVisibility = true;

            tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            TextDisplayViewModel.Text = $"{ProblemSelectionViewModel.SelectedProblem.Name}\r\n\r\nRunning each example once:\r\n\r\n";

            try
            {
                TextDisplayViewModel.Text += await Task.Run(() => ProblemSelectionViewModel.SelectedProblem.TestExamplesOnceTask(token, ProgressBarViewModel.Progress));
            }

            catch (OperationCanceledException oce)
            {
                TextDisplayViewModel.Text += $"{oce.Message}\r\n";
            }

            canDoSomething = true;
            canCancel = false;
            ProgressBarViewModel.ProgressVisibility = false;
        }

        private async void RunProblemforAverage()
        {
            canDoSomething = false;
            canCancel = true;
            ProgressBarViewModel.ProgressVisibility = true;

            tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            TextDisplayViewModel.Text = $"{ProblemSelectionViewModel.SelectedProblem.Name}\r\n\r\nRunning each example multiple times to average:\r\n\r\n";

            try
            {
                TextDisplayViewModel.Text += await Task.Run(() => ProblemSelectionViewModel.SelectedProblem.TestExamplesForAverageTask(token, ProgressBarViewModel.Progress));
            }

            catch (OperationCanceledException oce)
            {
                TextDisplayViewModel.Text += $"{oce.Message}\r\n";
            }

            canDoSomething = true;
            canCancel = false;
            ProgressBarViewModel.ProgressVisibility = false;
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