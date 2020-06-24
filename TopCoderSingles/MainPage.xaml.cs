using Windows.UI.Xaml.Controls;

namespace TopCoderSingles
{
    /// <summary>
    /// The main page of this application displaying problem statements, code and results.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            ViewModel VM = new ViewModel();
            this.DataContext = VM;
        }
    }
}