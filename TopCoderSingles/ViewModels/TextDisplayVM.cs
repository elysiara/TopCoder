using TopCoderSingles.Helpers;

namespace TopCoderSingles.ViewModels
{
    public class TextDisplayVM : ObservableProperty
    {
        private string _Text;

        public string Text
        {
            get { return _Text; }
            set
            {
                if (_Text != value)
                {
                    _Text = value;
                    OnPropertyChanged(nameof(Text));
                }
            }
        }

        public TextDisplayVM()
        {
            Text = "Welcome to my TopCoder Arena Practice Problems solutions!\r\nSelect a problem and click run to test.\r\n\r\n";
        }
    }
}