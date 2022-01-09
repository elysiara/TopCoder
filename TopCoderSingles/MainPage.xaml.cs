using Windows.UI.Xaml.Controls;
using TopCoderSingles.ViewModels;

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

            MainPageVM VM = new MainPageVM();
            this.DataContext = VM;
        }
    }
}