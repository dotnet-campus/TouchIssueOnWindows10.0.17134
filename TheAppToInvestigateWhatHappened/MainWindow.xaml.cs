using System.Windows;
using System.Windows.Input;

namespace TheAppToInvestigateWhatHappened
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnStylusDown(object sender, StylusDownEventArgs e)
        {
            // Set a breakpoint here.
        }
    }
}
