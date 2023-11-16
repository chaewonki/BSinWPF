using Python.Runtime;
using System.Windows;

namespace BSinWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Runtime.PythonDLL = "python311.dll";

            PythonEngine.Initialize();

            using (Py.GIL())
            {
                dynamic module = Py.Import("script");

                dynamic headlines = module.scrape_news_headlines();

                foreach (string headline in headlines)
                {
                    lstBox.Items.Add(headline);
                }

            }

            PythonEngine.Shutdown();
        }
    }
}