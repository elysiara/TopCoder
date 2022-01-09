using System.Linq;
using TopCoderSingles.Helpers;
using TopCoderSingles.Practice_Problems;

namespace TopCoderSingles.ViewModels
{
    public class ProblemSelectionVM : ObservableProperty
    {
        private readonly Problems problems = new Problems();

        private string[] _PracticeProblems;
        private int _SelectedProblemIndex;
        private IDisplayableProblem _SelectedProblem;

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

                    SelectedProblem = problems.GetProblemFromIndex(value);
                }
            }
        }
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

        public ProblemSelectionVM()
        {
            PracticeProblems = EnumerationExtension.GetEnumDescriptions(typeof(Problems.ProblemsList)).ToArray();

            SelectedProblemIndex = 0;
            SelectedProblem = problems.GetProblemFromIndex(0);
        }
    }
}
