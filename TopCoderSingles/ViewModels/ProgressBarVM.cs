using System;
using TopCoderSingles.Helpers;

namespace TopCoderSingles.ViewModels
{
    public class ProgressBarVM : ObservableProperty
    {
        private bool _progressVisibility;
        private int _progressPercent;
        public Progress<int> Progress;


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

        public ProgressBarVM()
        {
            ProgressVisibility = false;

            Progress = new Progress<int>(percent =>
            {
                ProgressPercent = percent;
            });
        }
    }
}
