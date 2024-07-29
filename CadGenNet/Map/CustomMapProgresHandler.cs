namespace CadGenNet.Map
{
    using DotSpatial.Data;
    using System.Diagnostics;
    using System.Windows.Forms;

    public class CustomMapProgresHandler : IProgressHandler
    {
        private readonly ProgressBar _progressBar;

        public CustomMapProgresHandler(ProgressBar progressBar)
        {
            _progressBar = progressBar;
        }

        public void Progress(string key, int percent, string message)
        {
            // Actualizează progress bar-ul
            _progressBar.Value = percent;
            _progressBar.Refresh();
        }

        public void Progress(int percent, string message)
        {
            Debug.WriteLine(message);
        }

        public void Reset()
        {
            Debug.WriteLine("Proggres reset.");
        }
    }

}
